using Moodify.Helpers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Moodify.ViewModel
{
	/// <summary>
	/// Interface for MyPlaylist
	/// </summary>
	/// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
	public interface IMyPlaylistsVM : INotifyPropertyChanged
	{
        IDictionary<int, Playlist> VM_PlaylistsDic { get; }
        ObservableCollection<Playlist> VM_Playlists { get; }
    }
}
