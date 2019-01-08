using System.Collections.ObjectModel;
using System.ComponentModel;
using Moodify.Containers;

namespace Moodify.ViewModel.ShowSongs
{
    public interface IShowSongsViewModel : INotifyPropertyChanged
    {
        void NotifyPropertyChanged(string propName);
        ObservableCollection<Song> VM_SongList { get; set; }
        string VM_PlaylistName { get; set; }
        int VM_PlaylistID { get; set; }

        /// <summary>
        /// Gets or sets the if the adding of the playlist was succesful.
        /// </summary>
        /// <value>
        /// The adding succesful "SUCCESS"\"FAILURE".
        /// </value>
        string VM_AddingSuccesful { get; set; }
    }
}