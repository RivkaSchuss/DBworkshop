using System.Windows;
using System.Windows.Controls;

namespace Moodify.View
{
	/// <summary>
	/// This class link between each button to github site.
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
