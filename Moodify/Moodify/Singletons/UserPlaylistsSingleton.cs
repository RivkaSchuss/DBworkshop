using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Moodify.Containers;
using Moodify.DB;
using Newtonsoft.Json.Linq;

namespace Moodify.Singletons
{
	/// <summary>
	/// Singleton to deal with UserPlaylist
	/// </summary>
	public class UserPlaylistsSingleton
    {
        private const string INSERT_SONGS_TO_PLAYLIST_FAILURE = "1";
        private const string INSERT_PLAYLIST_TO_USER_FAILURE = "2";
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
			int userID = ConnectionStatus.Instance.UserDetails.UserID;
            DBHandler handler = DBHandler.Instance;
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
            // Calculating the total duration time of the playlist songs
            foreach (KeyValuePair<int, Playlist> entry in playlists)
            {
                Playlist playlist = entry.Value;
                string query = string.Format(DBQueryManager.Instance.QueryDictionary["SqlSumTotalDurationPlaylist"], playlist.PlaylistId);
                JArray result = DBHandler.Instance.ExecuteWithResults(query);
                float totalSeconds = float.Parse((string)result[0]["total_duration"]);
                playlist.TotalDuration = TimeSpan.FromSeconds(Convert.ToInt32(totalSeconds)).ToString(@"hh\.mm\:ss");
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
                RealDuration = float.Parse((string)token["Duration"])
                
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
            int playlistID = -1;
            DBHandler handler = DBHandler.Instance;
			try
			{
                playlistID = InsertNewPlaylistToDB(playlist.PlaylistName, handler);
                List<int> songsID = playlist.Songs.Select(song => song.SongId).ToList();
                InsertSongsWithPlaylistID(songsID, playlistID, handler);
                InsertPlaylistIDToUser(playlistID, handler);
				return true;
			}
			catch (Exception e)
			{
                HandleAddPlaylistException(e.Message, playlistID);
                return false;
            }
        }

        /// <summary>
        /// Handles the add playlist exception.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="playlistID">The playlist identifier.</param>
        private void HandleAddPlaylistException(string message, int playlistID)
        {
            switch (message)
            {
                case INSERT_SONGS_TO_PLAYLIST_FAILURE:
                    DeleteQuery(playlistID, "SqlDeletePlaylistInfoEntity");
                    break;
                case INSERT_PLAYLIST_TO_USER_FAILURE:
                    DeleteQuery(playlistID, "SqlDeleteSongsFromPlaylist");
                    DeleteQuery(playlistID, "SqlDeletePlaylistInfoEntity");
                    break;
                default: break;
            }
        }

        /// <summary>
        /// Deletes the query.
        /// </summary>
        /// <param name="playlistID">The playlist identifier.</param>
        /// <param name="sqlQueryKey">The SQL query key.</param>
        private void DeleteQuery(int playlistID, string sqlQueryKey)
        {
            string query = string.Format(DBQueryManager.Instance.QueryDictionary[sqlQueryKey], playlistID);
            DBHandler.Instance.ExecuteNoResult(query);
        }

        /// <summary>
        /// Inserts the new playlist to database.
        /// </summary>
        /// <param name="playlistName">Name of the playlist.</param>
        /// <param name="handler">The handler.</param>
        /// <returns></returns>
        private int InsertNewPlaylistToDB(string playlistName, DBHandler handler)
        {
            string query = string.Format(DBQueryManager.Instance.QueryDictionary["SqlInsertNewPlaylist"], playlistName);

            JArray result = handler.ExecuteWithResults(query);
            return int.Parse((string)result[0]["LAST_INSERT_ID()"]);
        }

		/// <summary>
		/// Inserts the songs with playlist identifier.
		/// </summary>
		/// <param name="songsID">The songs identifier.</param>
		/// <param name="playlistID">The playlist identifier.</param>
		/// <param name="handler">The handler.</param>
		/// <returns></returns>
		private void InsertSongsWithPlaylistID(List<int> songsID, int playlistID, DBHandler handler)
        {
            string songsTuples = string.Empty;
            foreach (int songID in songsID)
            {
                songsTuples += "(" + playlistID + "," + "'" + songID + "'), "; 
            }
            songsTuples = songsTuples.Substring(0, songsTuples.Length - 2);
            string query = string.Format(DBQueryManager.Instance.QueryDictionary["SqlInsertSongsWithPlaylistID"], songsTuples);
            if (!handler.ExecuteNoResult(query))
            {
                throw new Exception(INSERT_SONGS_TO_PLAYLIST_FAILURE);
            }
        }

		/// <summary>
		/// Inserts the playlist identifier to user.
		/// </summary>
		/// <param name="playlistID">The playlist identifier.</param>
		/// <param name="handler">The handler.</param>
		/// <returns></returns>
		private void InsertPlaylistIDToUser(int playlistID, DBHandler handler)
        {
            User user = ConnectionStatus.Instance.UserDetails;
            var d = DBQueryManager.Instance;
            string query = string.Format(DBQueryManager.Instance.QueryDictionary["SqlInsertPlaylistIDToUser"], playlistID, user.UserName);
            if (!handler.ExecuteNoResult(query))
            {
                throw new Exception(INSERT_PLAYLIST_TO_USER_FAILURE);
            }
        }
    }
}
