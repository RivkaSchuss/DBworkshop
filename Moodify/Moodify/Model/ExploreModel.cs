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
        private ObservableCollection<Mood> moodOptions;

        public ExploreModel()
        {
            addGenericMoods();
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
            }
            get
            {
                return this.mood;
            }
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

        public void addGenericMoods()
        {
            ObservableCollection<Mood> generics = new ObservableCollection<Mood>();
            Mood mood1 = new Mood();
            Mood mood2 = new Mood();
            Mood mood3 = new Mood();
            Mood mood4 = new Mood();
            mood1.MoodName = "Fun";
            mood2.MoodName = "Chilled";
            mood3.MoodName = "Party";
            mood4.MoodName = "Romantic";
            generics.Add(mood1);
            generics.Add(mood2);
            generics.Add(mood3);
            generics.Add(mood4);
            this.MoodOptions = generics;

        }
    }
}
