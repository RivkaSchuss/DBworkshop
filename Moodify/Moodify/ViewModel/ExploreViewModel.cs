using Moodify.Helpers;
using Moodify.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moodify.ViewModel
{
    class ExploreViewModel : IExploreVM
    {
        private IExploreModel model;

        public event PropertyChangedEventHandler PropertyChanged;

        public ExploreViewModel()
        {
            this.model = new ExploreModel();
            this.model.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                this.NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }

        /*
        public void NotifyPropertyChanged(string propName)
        {
            this.model.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                this.NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }
        */

        public void NotifyPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public ObservableCollection<Playlist> VM_PlaylistOptions
        {
            get
            {
                return this.model.PlaylistOptions;
            } 
            set
            {
                this.model.PlaylistOptions = value;
            }
        }

        public Dictionary<Mood, ObservableCollection<Playlist>> VM_MoodDictionary
        {
            get
            {
                return this.model.MoodDictionary;
            }

        }

        public Mood VM_MoodChosen
        {
            get
            {
                return this.model.MoodChosen;
            }
            set
            {
                this.model.MoodChosen = value;
            }
        }

        public Playlist VM_PlaylistSelected
        {
            get
            {
                return this.model.PlaylistSelected;
            }
            set
            {
                this.model.PlaylistSelected = value;
            }
        }
    }
}
