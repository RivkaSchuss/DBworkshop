using Moodify.Helpers;
using Moodify.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Moodify.View
{
	/// <summary>
	/// Interaction logic for RegisterWindowView.xaml
	/// </summary>
	public partial class RegisterView : Window
	{
		private WelcomeScreen welcomeScreen;

		public RegisterView(WelcomeScreen welcomeScreen)
		{
			InitializeComponent();
			this.welcomeScreen = welcomeScreen;
			this.DataContext = welcomeScreen.DataContext;
		}

		/// <summary>
		/// Handles the Click event of the Submit button.
		/// </summary>
		public void Submit_Click(object sender, RoutedEventArgs e)
		{
			this.welcomeScreen.TryRegister();
			ConnectionStatus connection = ConnectionStatus.Instance;
			if (connection.IsConnected)
			{
				this.Close();
			}
		}

		/// <summary>
		/// Handles the Click event of the Cancel button.
		/// </summary>
		public void Cancel_Click(object sender, RoutedEventArgs e)
		{
			this.welcomeScreen.UserName = "";
			this.welcomeScreen.Password = "";
			this.welcomeScreen.Email = "";
			this.Close();
		}
	}
}
