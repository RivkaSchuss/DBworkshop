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
    class MyPlaylistsModel : IMyPlaylistsModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Dictionary<int, Playlist> playlistsDic;
        private ObservableCollection<Playlist> playlists;
        private int userId;

        public MyPlaylistsModel(int userId)
        {
            this.UserId = userId;
            this.playlistsDic = AddPlaylist();
           
        }

        public int UserId
        {
            get
            {
                return this.userId;
            }
            set
            {
                this.userId = value;
                this.NotifyPropertyChanged("UserId");
            }
        }

        public Dictionary<int, Playlist> AddPlaylist()
        {
            int id = this.UserId; 

            Dictionary<int, Playlist> playlists = new Dictionary<int, Playlist>();

            Playlist test = new Playlist();
            test.PlaylistName = "Rivka's playlist";
            Song song1 = new Song();
            song1.SongName = "lalala";
            Song song2 = new Song();
            song2.SongName = "jdjdjd";
            test.Songs = new ObservableCollection<Song>();
            test.Songs.Add(song1);
            test.Songs.Add(song2);
            playlists[1] = test;

            Playlist test2 = new Playlist();
            test2.PlaylistName = "Avihay's playlist";
            Song song3 = new Song();
            song3.SongName = "lalala";
            Song song4 = new Song();
            song4.SongName = "jdjdjd";
            test2.Songs = new ObservableCollection<Song>();
            test2.Songs.Add(song3);
            test2.Songs.Add(song4);
            playlists[2] = test2;

            return playlists;
        }

        public void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
            }
        }

        public ObservableCollection<Playlist> Playlists
        {
            set
            {
                this.playlists = value;
                this.NotifyPropertyChanged("Playlists");
            }
            get
            {
                return this.playlists;
            }
        }

        public Dictionary<int, Playlist> PlaylistsDic
        {
            set
            {
                this.playlistsDic = value;
                this.NotifyPropertyChanged("PlaylistsDic");
            }
            get
            {
                return this.playlistsDic;
            }
        }
    }
}
