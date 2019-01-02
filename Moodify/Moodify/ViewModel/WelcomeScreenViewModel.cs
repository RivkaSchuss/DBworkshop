using Moodify.Helpers;
using Moodify.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moodify.ViewModel
{
	class WelcomeScreenViewModel : IWelcomeScreenVM
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private IWelcomeScreenModel model;
		private ConnectionStatus connection = ConnectionStatus.Instance;
		
		public string VM_UserName
		{
			get
			{
				return this.model.UserName;
			}
			set
			{
				this.model.UserName = value;
				this.NotifyPropertyChanged("VM_UserName");
			}
		}
		public string VM_Password
		{
			get
			{
				return this.model.Password;
			}
			set
			{
				this.model.Password = value;
				this.NotifyPropertyChanged("VM_Password");
			}
		}
		public string VM_Email
		{
			get
			{
				return this.model.Email;
			}
			set
			{
				this.model.Email = value;
				this.NotifyPropertyChanged("VM_Email");
			}
		}

		public WelcomeScreenViewModel()
		{
			this.model = new WelcomeScreenModel();
            this.model.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                this.NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }

		public bool VM_IsConnected
		{
			get
			{
				return this.model.IsConnected;
			}
			set
			{
				this.model.IsConnected = value;
				NotifyPropertyChanged("VM_IsConnected");
			}
		}

		public bool VM_IsConnectionFailed
		{
			get
			{
				return this.model.ConnectionFailed;
			}
			set
			{
				this.model.ConnectionFailed = value;
				NotifyPropertyChanged("VM_IsConnectionFailed");
			}
		}

		public void NotifyPropertyChanged(string propName)
		{
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

		public bool TryRegister(string userName, string email, string Password)
		{
			return model.TryRegister(userName, email, Password);
		}

		public bool TrySignIn(string userName, string password)
		{
			return model.TrySignIn(userName, password);
		}



	}
}
