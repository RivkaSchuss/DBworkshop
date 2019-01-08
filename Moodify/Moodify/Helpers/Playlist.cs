using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moodify.Helpers
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
