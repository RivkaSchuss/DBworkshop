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
            this.MoodDictionary = CreateDictionary();
        }

        public Dictionary<Mood, ObservableCollection<Playlist>> MoodDictionary
        {
            get; set;
        }

 

        public Dictionary<Mood, ObservableCollection<Playlist>> CreateDictionary()
        {
            Dictionary<Mood, ObservableCollection<Playlist>> dic = new Dictionary<Mood, ObservableCollection<Playlist>>();
            ObservableCollection<Mood> generics = new ObservableCollection<Mood>();
            int lowTempo = 40;
            int mediumTempo = 100;
            int highTempo = 140;
            Mood fun = new Mood("Fun", new Genre(), highTempo);
            Mood chill = new Mood("Chill", new Genre(), lowTempo);
            Mood party = new Mood("Party", new Genre(), highTempo);
            Mood romantic = new Mood("Romantic", new Genre(), mediumTempo);
            Mood sad = new Mood("Sad", new Genre(), lowTempo);
            dic[fun] = AddExamplePlaylists();
            dic[chill] = new ObservableCollection<Playlist>();
            dic[party] = new ObservableCollection<Playlist>();
            dic[romantic] = new ObservableCollection<Playlist>();
            dic[sad] = new ObservableCollection<Playlist>();

            return dic;
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

        public ObservableCollection<Playlist> AddExamplePlaylists()
        {
            ObservableCollection<Playlist> playlists = new ObservableCollection<Playlist>();

            Playlist test = new Playlist();
            test.PlaylistName = "Rivka's playlist";
            test.PlaylistId = 12;
            Song song1 = new Song();
            song1.SongName = "lalala";
            Song song2 = new Song();
            song2.SongName = "jdjdjd";
            test.Songs = new ObservableCollection<Song>();
            test.Songs.Add(song1);
            test.Songs.Add(song2);
            playlists.Add(test);

            Playlist test2 = new Playlist();
            test2.PlaylistName = "Avihay's playlist";
            test2.PlaylistId = 15;
            Song song3 = new Song();
            song3.SongName = "lalala";
            Song song4 = new Song();
            song4.SongName = "jdjdjd";
            test2.Songs = new ObservableCollection<Song>();
            test2.Songs.Add(song3);
            test2.Songs.Add(song4);
            playlists.Add(test2);

            return playlists;
        }
    }
}
