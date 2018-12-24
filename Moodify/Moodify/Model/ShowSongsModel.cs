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
        private string playlistName;

        public ShowSongsModel(int playlistId)
        {
            //TODO:
            //SET THE SONGSLIST PROPERTY USING THE PLAYLIST ID
            //GET THE NAME OF THE PLAYLIST AND SET THE PLAYLIST NAME
        }

        public void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
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
