using System.ComponentModel;
using Moodify.Containers;

namespace Moodify.ViewModel.PlaylistVM
{
    interface IPlaylistViewModel : INotifyPropertyChanged
    {
        Playlist VM_Playlist { get; }
        void NotifyPropertyChanged(string propName);
    }
}