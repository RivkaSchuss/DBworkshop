using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moodify.ViewModel
{
	class MyPlaylistsViewModel : INotifyPropertyChanged, IMyPlaylistsVM
	{
		public event PropertyChangedEventHandler PropertyChanged;
	}
}
