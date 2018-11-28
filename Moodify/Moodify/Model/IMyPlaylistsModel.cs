using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moodify.Model
{
    interface IMyPlaylistsModel : INotifyPropertyChanged
    {
        string PlaylistName { get; set; }
    }
}
