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
                return this.playlists;
            }
            set
            {
                this.playlists = value;
            }
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
