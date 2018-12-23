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
    class CreatePlaylistVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private CreatePlaylistModel model;

        public CreatePlaylistVM()
        {
            this.model = new CreatePlaylistModel();
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
            set
            {
                this.model.PlaylistOptions = value;
            }
        }

        public Boolean VM_PlaylistSelected
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
