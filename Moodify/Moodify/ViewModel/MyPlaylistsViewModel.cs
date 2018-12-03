using Moodify.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moodify.ViewModel
{
	class MyPlaylistsViewModel : IMyPlaylistsVM
	{
        private IMyPlaylistsModel model;

        public string VM_PlaylistName
        {
            get { return this.model.PlaylistName; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            this.model = new MyPlaylistsModel();
            this.model.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                this.NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }
    }
}
