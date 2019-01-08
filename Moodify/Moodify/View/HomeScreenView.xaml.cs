using Moodify.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Moodify.ViewModel.HomeScreen;

namespace Moodify.View
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// This is the main View of the app.
	/// </summary>
	public partial class HomeScreenView : Window
	{
		public IHomeScreenVM homeScreenVM;

		public HomeScreenView()
		{
			InitializeComponent();
			this.homeScreenVM = new HomeScreenViewModel();
			this.DataContext = this.homeScreenVM;
		}
	}
}
