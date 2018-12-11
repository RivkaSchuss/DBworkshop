using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moodify.Model
{
	class LoginWindowModel : ILoginWindowModel
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private string username;
		private string password;

		public void NotifyPropertyChanged(string propName)
		{
			if (PropertyChanged != null)
			{
				this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
			}
		}

		public bool ValidateUserName(string userName, string password)
		{
			return false;
		}

		public bool SignUp(string userName, string password)
		{
			return false;
		}

		public string UserName
		{
			set
			{
				this.username = value;
				this.NotifyPropertyChanged("UserName");
			}
			get
			{
				return this.username;
			}
		}

		public string Password
		{
			set
			{
				this.password = value;
				this.NotifyPropertyChanged("Password");
			}
			get
			{
				return this.password;
			}
		}
	}
}
