using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moodify.Model
{
    /// <summary>
    /// Model definition for the Home Screen view.
    /// </summary>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    interface IHomeScreenModel : INotifyPropertyChanged
    {
        bool UserConnected { get; set; }
    }
}
