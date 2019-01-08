using System.Collections.ObjectModel;

namespace Moodify.Containers
{
	/// <summary>
	/// Define a playlist for the program
	/// </summary>
	public class Playlist
    {
        public string PlaylistName { set; get; }

        public ObservableCollection<Song> Songs { set; get; }

        public int PlaylistId
        {
            get; set;
        }

        public string TotalDuration
        {
            get; set;
        }
    }
}
