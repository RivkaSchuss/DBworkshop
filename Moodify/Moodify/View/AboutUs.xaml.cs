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
	/// Interaction logic for AboutUs.xaml
	/// </summary>
	public partial class AboutUs : UserControl
	{
		public AboutUs()
		{
			InitializeComponent();
		}

		private void RivkaClick(object sender, RoutedEventArgs e)
		{
			System.Diagnostics.Process.Start("https://github.com/RivkaSchuss");
		}

		private void DanClick(object sender, RoutedEventArgs e)
		{
			System.Diagnostics.Process.Start("https://github.com/dantepli");
		}

		private void BarakClick(object sender, RoutedEventArgs e)
		{
			System.Diagnostics.Process.Start("https://github.com/barak1224");
		}

		private void AvihayClick(object sender, RoutedEventArgs e)
		{
			System.Diagnostics.Process.Start("https://github.com/avihayarzuan");
		}

		private void ProjectClick(object sender, RoutedEventArgs e)
		{
			System.Diagnostics.Process.Start("https://github.com/RivkaSchuss/DBworkshop");
		}

	}
}
