using Moodify.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Moodify.Helpers
{
    public class UserPlaylistsSingleton
    {
        private static UserPlaylistsSingleton instance = null;
        private Dictionary<int, Playlist> playlists;

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

        public UserPlaylistsSingleton()
        {
            this.playlists = new Dictionary<int, Playlist>();
        }

        public Dictionary<int, Playlist> UserPlaylists
        {
            get
            {
                this.GetPlaylistsFromDB();
                return this.playlists;
            }
            set
            {
                this.playlists = value;
            }
        }

        private void GetPlaylistsFromDB()
        {
            DBHandler handler = DBHandler.Instance;
            int userID = 4;
            string query = string.Format(@"SELECT playlist_affiliation.playlist_id as PlaylistId, playlist_name as PlaylistName, playlist_songs.song_id as SongId, title as SongName, artist_name as ArtisName, duration as Duration
                            from playlist_info, playlist_affiliation, playlist_songs, song_info, artists, song_analysis
                            where playlist_affiliation.user_id = '{0}' and playlist_affiliation.playlist_id = playlist_info.playlist_id
                             and playlist_info.playlist_id = playlist_songs.playlist_id
                             and song_info.song_id = playlist_songs.song_id
                             and song_info.artist_id = artists.artist_id
                             and song_analysis.song_id = song_info.song_id", userID);
            JArray result = handler.ExecuteWithResults(query);
            this.playlists = new Dictionary<int, Playlist>();
            // TODO: Parse JSON Array.
            foreach (var entry in result)
            {
                var artist = new Artist()
                {
                    ArtistName = (string)entry["ArtistName"]
                };
                var song = new Song()
                {
                    SongId = int.Parse((string)entry["SongId"]),
                    SongName = (string)entry["SongName"],
                    SongArtist = artist,
                    Duration = float.Parse((string)entry["Duration"])
                };
                int playlistId = int.Parse((string)entry["PlaylistId"]);
                Playlist playlist = null;
                if (this.playlists.ContainsKey(playlistId))
                {
                    playlist = this.playlists[playlistId];
                }
                if (playlist == null)
                {
                    playlist = new Playlist()
                    {
                        PlaylistId = int.Parse((string)entry["PlaylistId"]),
                        PlaylistName = (string)entry["PlaylistName"],
                        Songs = new ObservableCollection<Song>()
                    };
                    playlists[playlistId] = playlist;
                }
                playlist.Songs.Add(song);
            }
            int b = 5;
        }

        public bool AddToPlaylists(Playlist playlist)
        {
			try
			{
				this.playlists.Add(playlist.PlaylistId, playlist);
				return true;
			}
			catch (ArgumentException e)
			{
				return false;
			}
			
        }
    }
}
