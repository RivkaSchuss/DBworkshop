using Moodify.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moodify.Model
{
	class MyPlaylistsModel : IMyPlaylistsModel
	{
		public event PropertyChangedEventHandler PropertyChanged;
		private IDictionary<int, Playlist> playlistsDic;
		private ObservableCollection<Playlist> playlists;
		//private int userId;

		public MyPlaylistsModel()
		{
			//this.UserId = userId;
			if (ConnectionStatus.Instance.IsConnected)
			{
				UserPlaylistsSingleton userPlaylists = UserPlaylistsSingleton.Instance;
				this.playlistsDic = userPlaylists.UserPlaylists;
			}
		}

		public void NotifyPropertyChanged(string propName)
		{
			if (PropertyChanged != null)
			{
				this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
			}
		}

		public ObservableCollection<Playlist> Playlists
		{
			set
			{
				this.playlists = value;
				this.NotifyPropertyChanged("Playlists");
			}
			get
			{
				return this.playlists;
			}
		}

		public IDictionary<int, Playlist> PlaylistsDic
		{
			set
			{
				this.playlistsDic = value;
				this.NotifyPropertyChanged("PlaylistsDic");
			}
			get
			{
				return this.playlistsDic;
			}
		}
	}
}
