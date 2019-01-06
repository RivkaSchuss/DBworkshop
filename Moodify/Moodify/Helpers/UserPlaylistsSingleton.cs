using Moodify.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Moodify.Helpers
{
    public class UserPlaylistsSingleton
    {
        private static UserPlaylistsSingleton instance = null;

        public static UserPlaylistsSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserPlaylistsSingleton();
                }
                return instance;
            }
        }

        private UserPlaylistsSingleton()
        {
            this.UserPlaylists = new Dictionary<int, Playlist>();
        }

        private IDictionary<int, Playlist> playlists;

        public IDictionary<int, Playlist> UserPlaylists {
            get
            {
                GetPlaylistsFromDB();
                return this.playlists;
            }
            set
            {
                playlists = value;
            }
        }

        /// <summary>
        /// Gets the users playlists from database.
        /// </summary>
        private void GetPlaylistsFromDB()
        {
            DBHandler handler = DBHandler.Instance;
            int userID = 4;
            string query = string.Format(DBQueryManager.Instance.QueryDictionary["SqlGetUserPlaylistsQuery"], userID);
            JArray result = handler.ExecuteWithResults(query);
            ParseUserPlaylistsFromJSON(result);
        }

        /// <summary>
        /// Parses the user playlists from the json array given.
        /// </summary>
        /// <param name="playlistsJson">The playlist json array.</param>
        private void ParseUserPlaylistsFromJSON(JArray playlistsJson)
        {
            this.playlists = new Dictionary<int, Playlist>();
            foreach (var entry in playlistsJson)
            {
                InsertPlaylistFromJSON(entry);
            }
        }

        /// <summary>
        /// Inserts the playlist to the playlist dictionary from the json token given.
        /// </summary>
        /// <param name="token">A json token representing the playlist entry in the DB.</param>
        private void InsertPlaylistFromJSON(JToken token)
        {
            Song song = ParseSongFromJSON(token);
            int playlistId = int.Parse((string)token["PlaylistId"]);
            Playlist playlist = null;
            if (this.playlists.ContainsKey(playlistId))
            {
                playlist = this.playlists[playlistId];
            }
            if (playlist == null)
            {
                playlist = new Playlist()
                {
                    PlaylistId = int.Parse((string)token["PlaylistId"]),
                    PlaylistName = (string)token["PlaylistName"],
                    Songs = new ObservableCollection<Song>()
                };
                this.playlists[playlistId] = playlist;
            }
            playlist.Songs.Add(song);
        }

        /// <summary>
        /// Parses the song from json token given.
        /// </summary>
        /// <param name="token">A json token.</param>
        /// <returns>A song object populated by the values in the json token.</returns>
        private Song ParseSongFromJSON(JToken token)
        {
            var artist = new Artist()
            {
                ArtistName = (string)token["ArtistName"]
            };
            return new Song()
            {
                SongId = int.Parse((string)token["SongId"]),
                SongName = (string)token["SongName"],
                SongArtist = artist,
                Duration = float.Parse((string)token["Duration"])
            };
        }

        /// <summary>
        /// Adds playlist to the user's playlists and store it in the DB.
        /// </summary>
        /// <param name="playlist">The playlist.</param>
        /// <returns></returns>
        public bool AddToPlaylists(Playlist playlist)
        {
            DBHandler handler = DBHandler.Instance;
			try
			{
                int playlistID = InsertNewPlaylistToDB(playlist.PlaylistName, handler);
                List<int> songsID = playlist.Songs.Select(song => song.SongId).ToList();
                InsertSongsWithPlaylistID(songsID, playlistID, handler);
                InsertPlaylistIDToUser(playlistID, handler);
                //Playlist userPlaylist = new Playlist()
                //{
                //    PlaylistId = playlistID,
                //    Songs = playlist.Songs,
                //    PlaylistName = playlist.PlaylistName + "'s " + ConnectionStatus.Instance.UserDetails.UserName
                //};
                //this.playlists.Add(playlistID, userPlaylist);
				return true;
			}
			catch (ArgumentException e)
			{
				return false;
			}
			
        }

        private int InsertNewPlaylistToDB(string playlistName, DBHandler handler)
        {
            string query = $"INSERT into playlist_info (playlist_name) VALUES ('{playlistName}');" +
               $"SELECT LAST_INSERT_ID();";

            JArray result = handler.ExecuteWithResults(query);
            return int.Parse((string)result[0]["LAST_INSERT_ID()"]);
        }

        private void InsertSongsWithPlaylistID(List<int> songsID, int playlistID, DBHandler handler)
        {
            string songsTuples = string.Empty;
            foreach (int songID in songsID)
            {
                songsTuples += "(" + playlistID + "," + "'" + songID + "'), "; 
            }
            songsTuples = songsTuples.Substring(0, songsTuples.Length - 2);
            string query = $"INSERT into playlist_songs (playlist_id, song_id) VALUES {songsTuples};";
            bool result = handler.ExecuteNoResult(query);
            result.Equals(true);
        }

        private bool InsertPlaylistIDToUser(int playlistID, DBHandler handler)
        {
            User user = ConnectionStatus.Instance.UserDetails;
            string query = $"INSERT INTO playlist_affiliation (playlist_id, user_id) SELECT {playlistID}, user_id from users where username = '{user.UserName}';";
            return handler.ExecuteNoResult(query);
        }
    }
}
