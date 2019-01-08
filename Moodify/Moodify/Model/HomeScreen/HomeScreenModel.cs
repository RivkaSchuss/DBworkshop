using System.ComponentModel;

namespace Moodify.Model.HomeScreen
{
    /// <summary>
    /// Model component for the Home Screen.
    /// </summary>
    /// <seealso cref="IHomeScreenModel" />
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
