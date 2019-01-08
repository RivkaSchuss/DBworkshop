using Moodify.Model;
using System.ComponentModel;

namespace Moodify.ViewModel
{
	/// <summary>
	/// The VM of CreatePlaylist window
	/// </summary>
	/// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
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

		public float VM_TempoMax
		{
			get
			{
				return this.model.TempoMax;
			}
			set
			{
				this.model.TempoMax= value;
			}
		}

		public float VM_TempoMin
		{
			get
			{
				return this.model.TempoMin;
			}
			set
			{
				this.model.TempoMin = value;
			}
		}

		public float VM_PopularityMax
		{
			get
			{
				return this.model.PopularityMax;
			}
			set
			{
				this.model.PopularityMax = value;
			}
		}

		public float VM_PopularityMin
		{
			get
			{
				return this.model.PopularityMin;
			}
			set
			{
				this.model.PopularityMin = value;
			}
		}

		public float VM_LoudnessMax
		{
			get
			{
				return this.model.LoudnessMax;
			}
			set
			{
				this.model.LoudnessMax = value;
			}
		}

		public float VM_LoudnessMin
		{
			get
			{
				return this.model.LoudnessMin;
			}
			set
			{
				this.model.LoudnessMin = value;
			}
		}

		/// <summary>
		/// Generates the custom playlist using the model.
		/// </summary>
		public void GenerateCustomPlaylist()
		{
			this.model.GenerateCustomPlaylist();
		}
	}
}
