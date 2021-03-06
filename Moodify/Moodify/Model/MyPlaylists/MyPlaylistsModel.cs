﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Moodify.Containers;
using Moodify.Singletons;

namespace Moodify.Model.MyPlaylists
{
    /// <summary>
    /// Model class for the MyPlaylists window.
    /// </summary>
    /// <seealso cref="IMyPlaylistsModel" />
    class MyPlaylistsModel : IMyPlaylistsModel
	{
		public event PropertyChangedEventHandler PropertyChanged;
		private IDictionary<int, Playlist> playlistsDic;
		private ObservableCollection<Playlist> playlists;

		public MyPlaylistsModel()
		{
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
