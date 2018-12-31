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
		bool TryRegister(string userName, string Email, string Password);
		bool TrySignIn(string userName, string password);
		bool VM_IsConnectionFailed { get; set; }
		string VM_UserName { get; set; }
		string VM_Password { get; set; }
		string VM_Email { get; set; }
		bool VM_IsConnected { get; set; }
	}
}
