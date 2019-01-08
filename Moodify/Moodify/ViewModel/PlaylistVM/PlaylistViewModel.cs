using System.ComponentModel;
using Moodify.Containers;
using Moodify.Model.PlaylistModel;

namespace Moodify.ViewModel.PlaylistVM
{
	/// <summary>
	/// Playlist VM
	/// </summary>
	/// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
	public class PlaylistViewModel : IPlaylistViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private PlaylistModel model;

        public PlaylistViewModel(Playlist playlist)
        {
            this.model = new PlaylistModel(playlist);
            this.model.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                this.NotifyPropertyChanged("VM_" + e.PropertyName);
            };
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
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
