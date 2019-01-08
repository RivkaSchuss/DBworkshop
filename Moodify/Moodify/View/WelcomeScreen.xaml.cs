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

		private ConnectionStatus connection = ConnectionStatus.Instance;

		public string UserName
		{
			get
			{
				return this.viewModel.VM_UserName;
			}
			set
			{
				this.viewModel.VM_UserName = value;
			}
		}

		public string Password
		{
			get
			{
				return this.viewModel.VM_Password;
			}
			set
			{
				this.viewModel.VM_Password = value;
			}
		}

		public string Email
		{
			get
			{
				return this.viewModel.VM_Email;
			}
			set
			{
				this.viewModel.VM_Email = value;
			}
		}
		/// <summary>
		/// Gets or sets a value indicating whether the last connection succeeeded or failed.
		/// </summary>
		/// <value>
		///   <c>true</c> if this instance is connection failed; otherwise, <c>false</c>.
		/// </value>
		public bool IsConnectionFailed
		{
			get
			{
				return this.viewModel.VM_IsConnectionFailed;
			}
			set
			{
				this.viewModel.VM_IsConnectionFailed = value;
			}
		}

		public WelcomeScreen()
		{
			InitializeComponent();
			viewModel = new WelcomeScreenViewModel();
			this.DataContext = this.viewModel;
		}

		/// <summary>
		/// Called when Register button is clicked.
		/// </summary>
		public void OnRegister(object sender, RoutedEventArgs e)
		{
			IsConnectionFailed = false;
			RegisterView RegisterWindow = new RegisterView(this);
			RegisterWindow.ShowDialog();
		}

		/// <summary>
		/// Called when Sign In button is clicked.
		/// </summary>
		public void OnSignIn(object sender, RoutedEventArgs e)
		{
			SignInView signInView = new SignInView(this);
			signInView.ShowDialog();
		}

		/// <summary>
		/// Called when Log off click is activated.
		/// </summary>
		public void OnLogOff(object sender, RoutedEventArgs e)
		{
			//Defualt values
			this.UserName = "";
			this.Password = "";
			this.Email = "";
			this.connection.IsConnected = false;
			this.viewModel.VM_IsConnectionFailed = false;
			this.viewModel.VM_IsConnected = false;
		}

		/// <summary>
		/// Try to activate sign in from the view model.
		/// </summary>
		public void TrySignIn()
		{
			bool result = this.viewModel.TrySignIn(this.UserName, this.Password);
			if (!result)
			{
				IsConnectionFailed = true;
			}
		}

		/// <summary>
		/// Try to register the user with the view model.
		/// </summary>
		public void TryRegister()
		{
			bool result = this.viewModel.TryRegister(this.UserName, this.Email, this.Password);
			if (!result)
			{
				IsConnectionFailed = true;
			}
		}
	}
}
