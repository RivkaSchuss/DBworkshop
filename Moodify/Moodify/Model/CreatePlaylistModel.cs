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
    class CreatePlaylistModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public CreatePlaylistModel()
        {
            this.PlaylistOptions = AddExamplePlaylists();
        }

        public void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
            }
        }

        public ObservableCollection<Playlist> PlaylistOptions
        {
            get; set;
        }

        public ObservableCollection<Playlist> AddExamplePlaylists()
        {
            ObservableCollection<Playlist> playlists = new ObservableCollection<Playlist>();

            Playlist test = new Playlist();
            test.PlaylistName = "Rivka's playlist";
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
