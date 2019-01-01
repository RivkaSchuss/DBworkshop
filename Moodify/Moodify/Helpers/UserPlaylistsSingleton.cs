using Moodify.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            int userID = 3;
            string query = string.Format(@"SELECT playlist_affiliation.playlist_id as playlistId, playlist_name, playlist_songs.song_id as songId, title, artist_name, duration
                            from playlist_info, playlist_affiliation, playlist_songs, song_info, artists, song_analysis
                            where playlist_affiliation.user_id = '{0}' and playlist_affiliation.playlist_id = playlist_info.playlist_id
                             and playlist_info.playlist_id = playlist_songs.playlist_id
                             and song_info.song_id = playlist_songs.song_id
                             and song_info.artist_id = artists.artist_id
                             and song_analysis.song_id = song_info.song_id", userID);
            JArray result = handler.ExecuteWithResults(query);
            // TODO: Parse JSON Array.
            List<Playlist> a = result.ToObject<List<Playlist>>();
            int b = 5;
        }

        public void AddToPlaylists(Playlist playlist)
        {
            this.playlists.Add(playlist.PlaylistId, playlist);

        }
    }
}
