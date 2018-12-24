using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moodify.Helpers
{
    public class Playlist
    {
        private string playlistName;
        private ObservableCollection<Song> songs;

        public string PlaylistName
        {
            set
            {
                this.playlistName = value;
            }
            get
            {
                return this.playlistName;
            }
        }

        public ObservableCollection<Song> Songs
        {
            set
            {
                this.songs = value;
            }
            get
            {
                return this.songs;
            }
        }

        public int PlaylistId
        {
            get; set;
        }
    }
}
