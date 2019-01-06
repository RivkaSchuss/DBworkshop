﻿using Moodify.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moodify.ViewModel
{
	public interface IMyPlaylistsVM : INotifyPropertyChanged
	{
        IDictionary<int, Playlist> VM_PlaylistsDic { get; }
        ObservableCollection<Playlist> VM_Playlists { get; }
    }
}
