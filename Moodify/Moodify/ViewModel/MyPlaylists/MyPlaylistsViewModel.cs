using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Moodify.Containers;
using Moodify.Model.MyPlaylists;

namespace Moodify.ViewModel.MyPlaylists
{
	/// <summary>
	/// MyPlaylists VM
	/// </summary>
	/// <seealso cref="IMyPlaylistsVM" />
	public class MyPlaylistsViewModel : IMyPlaylistsVM
	{
        private IMyPlaylistsModel model;

        public MyPlaylistsViewModel()
        {
            this.model = new MyPlaylistsModel();
            this.model.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                this.NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }

        public int VM_UserId
        {
            get;
            set;
        }

        public IDictionary<int, Playlist> VM_PlaylistsDic
        {
            get { return this.model.PlaylistsDic; }
        }

        public ObservableCollection<Playlist> VM_Playlists
        {
            get { return this.model.Playlists; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
