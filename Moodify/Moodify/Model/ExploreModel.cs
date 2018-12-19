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
        private string mood;
        private ObservableCollection<Mood> moodOptions;


        public ExploreModel()
        {
            this.MoodOptions = AddGenericMoods();
            this.MoodNames = new ObservableCollection<string>();
            foreach (Mood name in this.moodOptions)
            {
                this.MoodNames.Add(name.MoodName);
            }
            
        }

        public Playlist PlaylistChosen
        {
            get;
            set;
        }

        public void AddToUserPlaylist(string moodName)
        {
            Mood moodChosen = null;
            foreach (Mood mood in this.moodOptions)
            {
                if (moodName.Equals(mood.MoodName))
                {
                    moodChosen = mood;
                    break;
                }
            }
            Playlist playlist = new Playlist();
            playlist.Songs = moodChosen.Songs;

        }
        

        public void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
            }
        }

        public string MoodChosen
        {
            set
            {
                this.mood = value;
                AddToUserPlaylist(this.mood);
            }
            get
            {
                return this.mood;
            }
        }

        public ObservableCollection<string> MoodNames
        {
            get;
            set;
        }

        public ObservableCollection<Mood> MoodOptions
        {
            get
            {
                return this.moodOptions;
            }
            set
            {
                this.moodOptions = value;
            }
        }

        public ObservableCollection<Mood> AddGenericMoods()
        {
            ObservableCollection<Mood> generics = new ObservableCollection<Mood>();
            int lowTempo = 40;
            int mediumTempo = 100;
            int highTempo = 140;
            generics.Add(new Mood("Fun", new Genre(), highTempo));
            generics.Add(new Mood("Chill", new Genre(), lowTempo));
            generics.Add(new Mood("Party", new Genre(), highTempo));
            generics.Add(new Mood("Romantic", new Genre(), mediumTempo));
            generics.Add(new Mood("Sad", new Genre(), lowTempo));
            return generics;

        }
    }
}
