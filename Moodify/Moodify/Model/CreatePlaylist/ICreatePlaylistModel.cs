using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moodify.Model.CreatePlaylist
{
    /// <summary>
    /// The definition of the model for the Create Playlist window.
    /// </summary>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    interface ICreatePlaylistModel : INotifyPropertyChanged
    {
        string PlaylistName { get; set; }
        int NumOfSongs { get; set; }
        float TempoMax { get; set; }
        float TempoMin { get; set; }
        float PopularityMax { get; set; }
        float PopularityMin { get; set; }
        float LoudnessMax { get; set; }
        float LoudnessMin { get; set; }

    }
}
