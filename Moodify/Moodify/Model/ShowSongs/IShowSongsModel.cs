using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Moodify.Containers;

namespace Moodify.Model.ShowSongs
{
    interface IShowSongsModel : INotifyPropertyChanged
    {
        Dictionary<Mood, ObservableCollection<Playlist>> MoodDictionary { get; set; }
        int PlaylistID { get; set; }
        string AddingSuccesful { get; set; }
        ObservableCollection<Song> SongList { get; set; }
        string PlaylistName { get; set; }
    }
}
