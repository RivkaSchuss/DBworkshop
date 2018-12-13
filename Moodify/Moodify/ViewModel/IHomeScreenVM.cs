using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moodify.ViewModel
{
	public interface IHomeScreenVM : INotifyPropertyChanged
	{
		string VM_UserName { get; }
		
	}
}
