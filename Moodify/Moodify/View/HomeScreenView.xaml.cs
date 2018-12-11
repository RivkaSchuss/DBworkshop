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

namespace Moodify.View
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class HomeScreenView : Window
	{
		public HomeScreenView()
		{
			InitializeComponent();
			this.DataContext = new HomeScreenViewModel();

			LoginWindowView loginWindow = new LoginWindowView();
			//loginWindow.
		}

		public void OnRegister(object sender, RoutedEventArgs e)
		{
			LoginWindowView loginWindow = new LoginWindowView();
			loginWindow.Show();
		}

		public void OnSignIn(object sender, RoutedEventArgs e)
		{
			//LoginWindowView loginWindow = new LoginWindowView();
			//loginWindow.Show();
			SignInView signInView = new SignInView();
			signInView.Show();
		}
	}
}
