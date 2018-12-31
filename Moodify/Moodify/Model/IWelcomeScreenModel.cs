﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moodify.Model
{
    interface IWelcomeScreenModel : INotifyPropertyChanged
	{
		string UserName { get; set; }
		bool ConnectionFailed { get; set; }
		bool IsConnected { get; set; }
		bool TryRegister(string userName, string email, string Password);
		bool TrySignIn(string userName, string password);
	}
}
