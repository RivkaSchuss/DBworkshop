using Moodify.Helpers;
using Newtonsoft.Json.Linq;
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
        private int numOfSongs = 5;
		private float tempoMax = 131;
		private float tempoMin = 131;
		//private float tempo;
		private float popularityMax = 0.7F;
		private float popularityMin = 0.7F;
		private float loudnessMax = -25;
		private float loudnessMin = -25;
		private string playlistName = "Playlist name example";

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

		public float TempoMax
		{
			get
			{
				return this.tempoMax;
			}
			set
			{
				this.tempoMax = value;
				this.NotifyPropertyChanged("TempoMax");
			}
		}

		public float TempoMin
		{
			get
			{
				return this.tempoMin;
			}
			set
			{
				this.tempoMin = value;
				this.NotifyPropertyChanged("TempoMin");
			}
		}

		public float PopularityMax
		{
			get
			{
				return this.popularityMax;
			}
			set
			{
				this.popularityMax = value;
				this.NotifyPropertyChanged("PopularityMax");
			}
		}

		public float PopularityMin
		{
			get
			{
				return this.popularityMin;
			}
			set
			{
				this.popularityMin = value;
				this.NotifyPropertyChanged("PopularityMin");
			}
		}

		public float LoudnessMax
		{
			get
			{
				return this.loudnessMax;
			}
			set
			{
				this.loudnessMax = value;
				this.NotifyPropertyChanged("LoudnessMax");
			}
		}

		public float LoudnessMin
		{
			get
			{
				return this.loudnessMin;
			}
			set
			{
				this.loudnessMin = value;
				this.NotifyPropertyChanged("LoudnessMin");
			}
		}

        public void GenerateCustomPlaylist()
        {
            DBHandler handler = DBHandler.Instance;
            string query = string.Format(DBQueryManager.Instance.QueryDictionary["SqlGenerateCustomePlaylist"],
                tempoMin, tempoMax, loudnessMin, loudnessMax, popularityMin/100, popularityMax/100, numOfSongs);
            JArray result = handler.ExecuteWithResults(query);
            CustomPlaylistSingleton.Instance.CustomPlaylist = PlaylistJSONParser.ParseJSONPlaylist(result, -1, PlaylistName);
        }

    }
}
