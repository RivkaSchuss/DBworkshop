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
    /// <summary>
    /// Defines the Explore componenet Model.
    /// </summary>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    interface IExploreModel : INotifyPropertyChanged
    {
        Mood MoodChosen { get; set; }
        Playlist PlaylistSelected { get; set; }
        Dictionary<Mood, ObservableCollection<Playlist>> MoodDictionary { get; set; }
        ObservableCollection<Playlist> PlaylistOptions { get; set; }
    }
}

