using System.ComponentModel;

namespace Moodify.Model.PlaylistModel
{
    public class PlaylistModel : IPlaylistModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Containers.Playlist playlist;

        public Containers.Playlist Playlist
        {
            get
            {
                return this.playlist;
            }
            set
            {
                this.playlist = value;
                this.NotifyPropertyChanged("Playlist");
            }
        }

        public PlaylistModel(Containers.Playlist playlist)
        {
            this.Playlist = playlist;
        }

        public void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
