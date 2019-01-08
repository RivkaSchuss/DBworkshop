using System.ComponentModel;

namespace Moodify.Model.PlaylistModel
{
    interface IPlaylistModel : INotifyPropertyChanged
    {
        Containers.Playlist Playlist { get; set; }
    }
}
