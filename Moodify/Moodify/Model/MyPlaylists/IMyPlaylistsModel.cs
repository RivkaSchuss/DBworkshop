using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Moodify.Containers;

namespace Moodify.Model.MyPlaylists
{
    /// <summary>
    /// Model definition for the MyPlaylists window.
    /// </summary>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    interface IMyPlaylistsModel : INotifyPropertyChanged
    {
        IDictionary<int, Playlist> PlaylistsDic { get; set; }
        ObservableCollection<Playlist> Playlists {get; set;}

    }
}
