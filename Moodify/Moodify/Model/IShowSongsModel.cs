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
    interface IShowSongsModel : INotifyPropertyChanged
    {
        Dictionary<Mood, ObservableCollection<Playlist>> MoodDictionary { get; set; }
        int PlaylistID { get; set; }
        string AddingSuccesful { get; set; }
        ObservableCollection<Song> SongList { get; set; }
        string PlaylistName { get; set; }
    }
}
