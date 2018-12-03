using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Moodify.Model
{
    class HomeScreenModel : IHomeScreenModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string username;

        public void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
            }
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
