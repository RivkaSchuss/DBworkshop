using Moodify.Helpers;
using Moodify.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moodify.ViewModel
{
    public class PlaylistViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private PlaylistModel model;

        public PlaylistViewModel(Playlist playlist)
        {
            this.model = new PlaylistModel(playlist);
        }

        public Playlist VM_Playlist
        {
            get
            {
                return this.model.Playlist;
            }
        }

        public void NotifyPropertyChanged(string propName)
        {
            this.model.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                this.NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }
    }
}
