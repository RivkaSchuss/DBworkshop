﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moodify.Model
{
	interface ILoginWindowModel : INotifyPropertyChanged
	{
		bool ValidateUserName(string userName, string password);
		bool SignUp(string userName, string password);
		string UserName { set; get; }
		string Password { set; get; }
	}
}
