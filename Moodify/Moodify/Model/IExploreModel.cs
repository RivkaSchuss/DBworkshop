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
    interface IExploreModel : INotifyPropertyChanged
    {
        string MoodChosen { get; set; }
        ObservableCollection<Mood> MoodOptions { get; set; }
        ObservableCollection<string> MoodNames { get; set; }
    }
}

