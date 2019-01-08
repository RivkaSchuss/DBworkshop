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
	/// <summary>
	/// ShowSong VM class
	/// </summary>
	/// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
	public class ShowSongsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ShowSongsModel model;

        public ShowSongsViewModel(int playlistId)
        {
            this.model = new ShowSongsModel(playlistId);
            this.model.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                this.NotifyPropertyChanged("VM_" + e.PropertyName);
            };
            this.model.SetSongs();
        }

        public void NotifyPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public ObservableCollection<Song> VM_SongList
        {
            get
            {
                return this.model.SongList;
            }
            set
            {
                this.model.SongList = value;
            }
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

        public int VM_PlaylistID
        {
            get
            {
                return this.model.PlaylistID;
            }
            set
            {
                this.model.PlaylistID = value;
            }
        }

		/// <summary>
		/// Gets or sets the if the adding of the playlist was succesful.
		/// </summary>
		/// <value>
		/// The adding succesful "SUCCESS"\"FAILURE".
		/// </value>
		public string VM_AddingSuccesful
        {
            get
            {
                return this.model.AddingSuccesful;
            }
            set
            {
                this.model.AddingSuccesful = value;
            }
        }

    }
}
