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

		public WelcomeScreenViewModel()
		{
			this.model = new WelcomeScreenModel();
            this.model.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                this.NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }

		//public string VM_UserName
		//{
		//	get
		//	{
		//		return this.model.UserName;
		//	}
		//	set
		//	{
		//		this.model.UserName = value;
		//	}
		//}

		public void NotifyPropertyChanged(string propName)
		{
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

		public bool TryAddUser(string userName, string email, string Password)
		{
			return model.TryAddUser(userName, email, Password);
		}

		public bool TrySignIn(string userName, string password)
		{
			return model.TrySignIn(userName, password);
		}

	}
}
