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
	/// Interaction logic for LoginWindowView.xaml
	/// </summary>
	public partial class LoginWindowView : Window
	{
		public LoginWindowView(IWelcomeScreenVM welcomeScreenVM)
		{
			InitializeComponent();
			this.DataContext = welcomeScreenVM;
		}

		public void Submit_Click(object sender, RoutedEventArgs e)
		{

		}

		//public void button2_Click(object sender, RoutedEventArgs e)
		//{

		//}
		public void Cancel_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}
