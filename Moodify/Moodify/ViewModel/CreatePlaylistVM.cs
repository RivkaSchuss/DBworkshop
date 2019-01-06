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

		public string VM_PlaylistName
		{
			get
			{
				return this.model.PlaylistName;
			}
			set
			{
				this.model.PlaylistName = value;
			}
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

		public float VM_Tempo
		{
			get
			{
				return this.model.Tempo;
			}
			set
			{
				this.model.Tempo = value;
			}
		}

		public float VM_Popularity
		{
			get
			{
				return this.model.Popularity;
			}
			set
			{
				this.model.Popularity = value;
			}
		}

		public float VM_Loudness
		{
			get
			{
				return this.model.Loudness;
			}
			set
			{
				this.model.Loudness = value;
			}
		}
	}
}
