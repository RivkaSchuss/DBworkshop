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
    /// Interaction logic for WelcomeScreen.xaml
    /// </summary>
    public partial class WelcomeScreen : UserControl
    {
		private IWelcomeScreenVM viewModel;

		public string userName = "";
		public string password = "";

        public WelcomeScreen()
        {
            InitializeComponent();
			viewModel = new WelcomeScreenViewModel();
			this.DataContext = this.viewModel;
        }

		public void OnRegister(object sender, RoutedEventArgs e)
		{
			LoginWindowView loginWindow = new LoginWindowView(this.viewModel);
			//loginWindow.DataContext = this.DataContext;
			loginWindow.Show();
		}

		public void OnSignIn(object sender, RoutedEventArgs e)
		{
			//LoginWindowView loginWindow = new LoginWindowView();
			//loginWindow.Show();
			SignInView signInView = new SignInView(this);
			//SignIn.DataContext = this.DataContext;
			signInView.Show();
		}

		public void TrySignIn()
		{
			this.viewModel.TrySignIn(this.userName, this.password);
		}
	}
}
