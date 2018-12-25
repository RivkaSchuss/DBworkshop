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
    class ExploreModel : IExploreModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Mood mood;
        private ObservableCollection<Playlist> playlistOptions;
        private Playlist playlistSelected;

        public ExploreModel()
        {
            BuiltInPlaylistsSingleton builtInPlaylists = BuiltInPlaylistsSingleton.Instance;
            this.MoodDictionary = builtInPlaylists.PlaylistDictionary;
        }

        public Dictionary<Mood, ObservableCollection<Playlist>> MoodDictionary
        {
            get; set;
        }

        public void SetPlaylists(Mood moodName)
        {
            this.PlaylistOptions = this.MoodDictionary[this.mood];
        }
        

        public void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
            }
        }

        public Mood MoodChosen
        {
            set
            {
                this.mood = value;
                SetPlaylists(this.mood);
                this.NotifyPropertyChanged("MoodChosen");
            }
            get
            {
                return this.mood;
            }
        }

        public ObservableCollection<Playlist> PlaylistOptions
        {
            get
            {
                return this.playlistOptions;
            }
            set
            {
                this.playlistOptions = value;
                this.NotifyPropertyChanged("PlaylistOptions");
            }
        }

        public Playlist PlaylistSelected
        {
            get
            {
                return this.playlistSelected;
            }
            set
            {
                this.playlistSelected = value;
                this.NotifyPropertyChanged("PlaylistSelected");
            }
        }

        
    }
}
