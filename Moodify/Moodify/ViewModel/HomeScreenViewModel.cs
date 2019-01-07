using Moodify.Helpers;
using Moodify.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Moodify.ViewModel
{
	class HomeScreenViewModel : IHomeScreenVM
	{
        private IHomeScreenModel model;

		public HomeScreenViewModel()
		{
			this.model = new HomeScreenModel();
            this.model.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                this.NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }
		

		public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }



    }
}
