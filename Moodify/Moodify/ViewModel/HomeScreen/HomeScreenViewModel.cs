using System.ComponentModel;
using Moodify.Model.HomeScreen;

namespace Moodify.ViewModel.HomeScreen
{
	/// <summary>
	/// The HomeScreen VM
	/// </summary>
	/// <seealso cref="IHomeScreenVM" />
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
