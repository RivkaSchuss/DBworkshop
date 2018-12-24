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
            this.model.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                this.NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }

        public void NotifyPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public int VM_NumOfSongs
        {
            get
            {
                return this.model.NumOfSongs;
            }
            set
            {
                this.model.NumOfSongs = value;
            }
        }
    }
}
