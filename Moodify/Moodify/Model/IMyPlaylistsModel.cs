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
    interface IMyPlaylistsModel : INotifyPropertyChanged
    {
        IDictionary<int, Playlist> PlaylistsDic { get; set; }
        ObservableCollection<Playlist> Playlists {get; set;}

    }
}
