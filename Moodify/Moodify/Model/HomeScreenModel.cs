using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Moodify.Model
{
    /// <summary>
    /// Model component for the Home Screen.
    /// </summary>
    /// <seealso cref="Moodify.Model.IHomeScreenModel" />
    class HomeScreenModel : IHomeScreenModel
    {

        public bool UserConnected { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
            }
        }


    }
}
