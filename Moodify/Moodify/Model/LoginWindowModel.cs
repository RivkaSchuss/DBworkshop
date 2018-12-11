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

		public void NotifyPropertyChanged(string propName)
		{
			if (PropertyChanged != null)
			{
				this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
			}
		}

		public bool ValidateUserName(string userName, string password)
		{
			throw new NotImplementedException();
		}
	}
}
