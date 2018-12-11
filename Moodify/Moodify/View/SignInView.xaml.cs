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
		public SignInView()
		{
			InitializeComponent();
		}


		public void Submit_Click(object sender, RoutedEventArgs e)
		{

		}

		//public void Login_Click(object sender, RoutedEventArgs e)
		//{

		//}

		public void Cancel_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
			//Window current = (Window)sender;
			//current.Close();
		}
		//public void Reset_Click(object sender, RoutedEventArgs e)
		//{

		//}
	}
}
