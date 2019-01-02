using Moodify.Helpers;
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
using System.Windows.Shapes;

namespace Moodify.View
{
	/// <summary>
	/// Interaction logic for SignInView.xaml
	/// </summary>
	public partial class SignInView : Window
	{
		private WelcomeScreen welcomeScreen;

		public SignInView(WelcomeScreen welcomeScreen)
		{
			InitializeComponent();
			this.welcomeScreen = welcomeScreen;
			this.DataContext = welcomeScreen.DataContext;
		}


		public void Submit_Click(object sender, RoutedEventArgs e)
		{
			this.welcomeScreen.TrySignIn();
			ConnectionStatus connection = ConnectionStatus.Instance;
			if(connection.IsConnected)
			{
				this.Close();
			}
		}


		public void Cancel_Click(object sender, RoutedEventArgs e)
		{
			this.welcomeScreen.UserName = "";
			this.welcomeScreen.Password = "";
			this.welcomeScreen.Email = "";
			this.Close();
		}
	}
}
