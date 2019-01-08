using System.ComponentModel;

namespace Moodify.Model.HomeScreen
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
