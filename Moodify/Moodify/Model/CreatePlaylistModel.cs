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
        private int numOfSongs;

        public CreatePlaylistModel()
        {
            //this.PlaylistOptions = AddExamplePlaylists();
        }

        public void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
            }
        }

       public int NumOfSongs
        {
            get
            {
                return this.numOfSongs;
            }
            set
            {
                this.numOfSongs = value;
                this.NotifyPropertyChanged("NumOfSongs");
            }
        }
        
    }
}
