using Moodify.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moodify.ViewModel
{
	class LoginWindowViewModel : ILoginWindowViewModel
	{
		private ILoginWindowModel model;

		public event PropertyChangedEventHandler PropertyChanged;

		public void NotifyPropertyChanged(string propName)
		{
			this.model = new LoginWindowModel();
			this.model.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
			{
				this.NotifyPropertyChanged("VM_" + e.PropertyName);
			};
		}
	}
}
