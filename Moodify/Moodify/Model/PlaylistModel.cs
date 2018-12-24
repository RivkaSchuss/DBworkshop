using Moodify.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moodify.Model
{
    public class PlaylistModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Playlist playlist;

        public Playlist Playlist
        {
            get
            {
                return this.playlist;
            }
            set
            {
                this.playlist = value;
                this.NotifyPropertyChanged("Playlist");
            }
        }

        public PlaylistModel(Playlist playlist)
        {
            this.Playlist = playlist;
        }

        public void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
