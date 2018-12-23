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
        }

        public void NotifyPropertyChanged(string propName)
        {
            this.model.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                this.NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }

        public ObservableCollection<Playlist> VM_PlaylistOptions
        {
            get
            {
                return this.model.PlaylistOptions;
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
