using System.ComponentModel;

namespace Moodify.ViewModel.HomeScreen
{
    public interface IHomeScreenVM : INotifyPropertyChanged
    {
        void NotifyPropertyChanged(string propName);
    }
}
