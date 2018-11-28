using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moodify.ViewModel
{
	interface IMyPlaylistsVM : INotifyPropertyChanged
	{
        string VM_PlaylistName { get; }
	}
}
