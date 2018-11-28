using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moodify.Model
{
    class MyPlaylistsModel : IMyPlaylistsModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string playlistName;

        public MyPlaylistsModel()
        {

        }

        public void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
            }
        }

        public string PlaylistName
        {
            set
            {
                this.playlistName = value;
                this.NotifyPropertyChanged("PlaylistName");
            }
            get
            {
                return this.playlistName;
            }
        }
    }
}
