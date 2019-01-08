using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moodify.Model
{
    /// <summary>
    /// Model definition for the Welcome Screen window. (Regiser, LogIn).
    /// </summary>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    interface IWelcomeScreenModel : INotifyPropertyChanged
	{
		string UserName { get; set; }
		string Email { get; set; }
		string Password { get; set; }
		bool ConnectionFailed { get; set; }
		bool IsConnected { get; set; }
		bool TryRegister(string userName, string email, string Password);
		bool TrySignIn(string userName, string password);
	}
}
