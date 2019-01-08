using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Moodify.Containers;
using Moodify.Singletons;

namespace Moodify.Model.ShowSongs
{
    /// <summary>
    /// Model class for the Show Songs window. (Built-In and Custom playlist creation display 
    /// before adding to MyPlaylists).
    /// </summary>
    public class ShowSongsModel
	{
		public event PropertyChangedEventHandler PropertyChanged;
		private ObservableCollection<Song> songList;
		private Playlist playlist;
		private string playlistName;
		private int playlistID;
		private string addSuccess = null;


		public ShowSongsModel(int playlistId)
		{
			this.playlistID = playlistId;
			this.playlist = FindPlaylist();

		}


        /// <summary>
        /// Finds the playlist.
        /// </summary>
        /// <returns>The Playlist corresponding to the playlist id property.</returns>
        public Playlist FindPlaylist()
		{
			if (playlistID == -1)
			{
				return CustomPlaylistSingleton.Instance.CustomPlaylist;
			}
			BuiltInPlaylistsSingleton builtInPlaylists = BuiltInPlaylistsSingleton.Instance;
			this.MoodDictionary = builtInPlaylists.PlaylistDictionary;
			foreach (ObservableCollection<Playlist> collec in this.MoodDictionary.Values)
			{
				if (collec is null)
				{
					continue;
				}
				foreach (Playlist playlist in collec)
				{
					if (playlist.PlaylistId == this.playlistID)
					{
						return playlist;
					}
				}
			}
			return null;
		}

        /// <summary>
        /// Adds to user playlists (inserts to DB).
        /// </summary>
        public void AddToUserPlaylists()
        {
            UserPlaylistsSingleton userPlaylists = UserPlaylistsSingleton.Instance;
            bool result = userPlaylists.AddToPlaylists(this.playlist);
            if (result)
            {
                this.AddingSuccesful = "SUCCESS";
                ConnectionStatus.Instance.NotifyPropertyChanged("IsConnected");
            }
            else
            {
                this.AddingSuccesful = "FAIL";
            }
        }

        public void NotifyPropertyChanged(string propName)
		{
			if (PropertyChanged != null)
			{
				this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
			}
		}

		Dictionary<Mood, ObservableCollection<Playlist>> MoodDictionary
		{
			get;
			set;
		}

		public int PlaylistID
		{
			get
			{
				return this.playlistID;
			}
			set
			{
				this.playlistID = value;
				AddToUserPlaylists();
			}
		}

		public string AddingSuccesful
		{
			get
			{
				return this.addSuccess;
			}
			set
			{
				this.addSuccess = value;
				this.NotifyPropertyChanged("AddingSuccesful");
			}
		}

		public ObservableCollection<Song> SongList
		{
			get
			{
				return this.songList;
			}
			set
			{
				this.songList = value;
				this.NotifyPropertyChanged("SongList");
			}
		}


		public string PlaylistName
		{
			get
			{
				return this.playlistName;
			}
			set
			{
				this.playlistName = value;
				this.NotifyPropertyChanged("PlaylistName");
			}
		}

        public void SetSongs()
        {
            this.PlaylistName = this.playlist.PlaylistName;
            this.SongList = this.playlist.Songs;
        }
    }
}
