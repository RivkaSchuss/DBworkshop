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
    public class ShowSongsModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Song> songList;
        private Playlist playlist;
        private string playlistName;
        private int playlistID;
        private bool addSuccess;
        

        public ShowSongsModel(int playlistId)
        {
            this.playlistID = playlistId;
            this.playlist = FindPlaylist();
            
        }

        public void SetSongs()
        {
            this.PlaylistName = this.playlist.PlaylistName;
            this.SongList = this.playlist.Songs;
        }

        public Playlist FindPlaylist()
        {
            BuiltInPlaylistsSingleton builtInPlaylists = BuiltInPlaylistsSingleton.Instance;
            this.MoodDictionary = builtInPlaylists.PlaylistDictionary;
            foreach (ObservableCollection<Playlist> collec in this.MoodDictionary.Values)
            {
                foreach(Playlist playlist in collec)
                {
                    if (playlist.PlaylistId == this.playlistID)
                    {
                        return playlist;
                    }
                }
            }
            return null;
        }

        public void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
            }
        }

        Dictionary<Mood, ObservableCollection<Playlist>> MoodDictionary
        {
            get;
            set;
        }

        public int PlaylistID
        {
            get
            {
                return this.playlistID;
            }
            set
            {
                this.playlistID = value;
                AddToUserPlaylists();
            }
        }

        public void AddToUserPlaylists()
        {
            UserPlaylistsSingleton userPlaylists = UserPlaylistsSingleton.Instance;
            userPlaylists.AddToPlaylists(this.playlist);
            this.AddingSuccesful = true;
        }

        public bool AddingSuccesful
        {
            get
            {
                return this.addSuccess;
            }
            set
            {
                this.addSuccess = value;
                this.NotifyPropertyChanged("AddingSuccesful");
            }
        }

        public ObservableCollection<Song> SongList
        {
            get
            {
                return this.songList;
            }
            set
            {
                this.songList = value;
                this.NotifyPropertyChanged("SongList");
            }
        }


        public string PlaylistName
        {
            get
            {
                return this.playlistName;
            }
            set
            {
                this.playlistName = value;
                this.NotifyPropertyChanged("PlaylistName");
            }
        }
    }
}
