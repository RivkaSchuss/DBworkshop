﻿using Moodify.Helpers;
using Moodify.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moodify.ViewModel
{
	public class MyPlaylistsViewModel : IMyPlaylistsVM
	{
        private IMyPlaylistsModel model;


        public MyPlaylistsViewModel(int userId)
        {
            this.model = new MyPlaylistsModel(userId);
        }

        public int VM_UserId
        {
            get;
            set;
        }

        public Dictionary<int, Playlist> VM_PlaylistsDic
        {
            get { return this.model.PlaylistsDic; }
        }

        public ObservableCollection<Playlist> VM_Playlists
        {
            get { return this.model.Playlists; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            this.model.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                this.NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }
    }
}
