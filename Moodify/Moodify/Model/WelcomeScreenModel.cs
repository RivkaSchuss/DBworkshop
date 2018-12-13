using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moodify.Model
{
	class WelcomeScreenModel : IWelcomeScreenModel
	{
		public event PropertyChangedEventHandler PropertyChanged;
		private string username = "asd";

		public void NotifyPropertyChanged(string propName)
		{
			if (PropertyChanged != null)
			{
				this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
			}
		}

		public bool TryAddUser(string userName, string email, string Password)
		{
			return true;
		}

		public bool TrySignIn(string userName, string password)
		{
			return true;
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
	}
}
