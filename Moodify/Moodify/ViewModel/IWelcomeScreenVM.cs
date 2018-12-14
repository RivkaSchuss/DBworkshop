using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moodify.ViewModel
{
    public interface IWelcomeScreenVM : INotifyPropertyChanged
	{
		//string VM_UserName { get; }
		bool TryAddUser(string userName, string Email, string Password);
		bool TrySignIn(string userName, string password);
	}
}
