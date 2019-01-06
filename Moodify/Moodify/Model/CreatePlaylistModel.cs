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
		private float tempo;
		private float popularity;
		private float loudness;
		private string playlistName = "";

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

		public float Tempo
		{
			get
			{
				return this.tempo;
			}
			set
			{
				this.tempo = value;
				this.NotifyPropertyChanged("Tempo");
			}
		}

		public float Popularity
		{
			get
			{
				return this.popularity;
			}
			set
			{
				this.popularity = value;
				this.NotifyPropertyChanged("Popularity");
			}
		}

		public float Loudness
		{
			get
			{
				return this.loudness;
			}
			set
			{
				this.loudness = value;
				this.NotifyPropertyChanged("Loudness");
			}
		}

	}
}
