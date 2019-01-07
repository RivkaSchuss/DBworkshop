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
            int userID = 4;
            DBHandler handler = DBHandler.Instance;
            //User user = ConnectionStatus.Instance.UserDetails;
            //if (user == null)
            //{
            //    userID = 100;
            //} else
            //{
            //    userID = user.UserID;
            //}
            string query = string.Format(DBQueryManager.Instance.QueryDictionary["SqlGetUserPlaylistsQuery"], userID);
            JArray result = handler.ExecuteWithResults(query);
            if (result != null)
            {
                ParseUserPlaylistsFromJSON(result);
            }
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
                    Songs = new ObservableCollection<Song>(),                    
                };
                //string query = string.Format(DBQueryManager.Instance.QueryDictionary["SqlInsertSongsWithPlaylistID"], playlist.PlaylistId);
                //JArray result = DBHandler.Instance.ExecuteWithResults(query);
                //playlist.TotalDuration = float.Parse((string)DBHandler.Instance.ExecuteWithResults(query));
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
                ArtistName = (string)token["ArtistName"],
                Genre = (string)token["Genre"]
            };
            return new Song()
            {
                SongId = int.Parse((string)token["SongId"]),
                SongName = (string)token["SongName"],
                SongArtist = artist,
                AlbumName = (string)token["AlbumName"],
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
            if (ConnectionStatus.Instance.UserDetails == null)
            {
                return false;
            }

            DBHandler handler = DBHandler.Instance;
			try
			{
                //TODO: CHECK HOW TO HANDLE FAILURE.
                int playlistID = InsertNewPlaylistToDB(playlist.PlaylistName, handler);
                List<int> songsID = playlist.Songs.Select(song => song.SongId).ToList();
                InsertSongsWithPlaylistID(songsID, playlistID, handler);
                InsertPlaylistIDToUser(playlistID, handler);
				return true;
			}
			catch (ArgumentException)
			{
				return false;
			}
        }

        private int InsertNewPlaylistToDB(string playlistName, DBHandler handler)
        {
            string query = string.Format(DBQueryManager.Instance.QueryDictionary["SqlInsertNewPlaylist"], playlistName);

            JArray result = handler.ExecuteWithResults(query);
            return int.Parse((string)result[0]["LAST_INSERT_ID()"]);
        }

        private bool InsertSongsWithPlaylistID(List<int> songsID, int playlistID, DBHandler handler)
        {
            string songsTuples = string.Empty;
            foreach (int songID in songsID)
            {
                songsTuples += "(" + playlistID + "," + "'" + songID + "'), "; 
            }
            songsTuples = songsTuples.Substring(0, songsTuples.Length - 2);
            string query = string.Format(DBQueryManager.Instance.QueryDictionary["SqlInsertSongsWithPlaylistID"], songsTuples);
            return handler.ExecuteNoResult(query);
        }

        private bool InsertPlaylistIDToUser(int playlistID, DBHandler handler)
        {
            User user = ConnectionStatus.Instance.UserDetails;
            var d = DBQueryManager.Instance;
            string query = string.Format(DBQueryManager.Instance.QueryDictionary["SqlInsertPlaylistIDToUser"], playlistID, user.UserName);
            return handler.ExecuteNoResult(query);
        }
    }
}
