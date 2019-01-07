using Moodify.Helpers;
using Moodify.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
	/// Interaction logic for ExploreView.xaml
	/// </summary>
	public partial class ExploreView : UserControl
	{
        private IExploreVM viewModel;
		ConnectionStatus connection = ConnectionStatus.Instance;

		public ExploreView()
		{
			connection.PropertyChanged += HandleEvent;
			IsEnabled = false;
			InitializeComponent();
		}

		public void HandleEvent(object sender, PropertyChangedEventArgs args)
		{
			this.viewModel = new ExploreViewModel();
            this.DataContext = viewModel;
			this.IsEnabled = connection.IsConnected;
		}


        private void Custom_Button_Click(object sender, RoutedEventArgs e)
        {
            CreatePlaylistView view = new CreatePlaylistView();
            view.ShowDialog();
        }

        private void Show_Songs(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int playlistId = (int)button.CommandParameter;
            ShowSongsView view = new ShowSongsView(playlistId);
            view.ShowDialog();
        }

		private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
		{
			ScrollViewer svc = (ScrollViewer)sender;
			svc.ScrollToVerticalOffset(svc.VerticalOffset - e.Delta);
			e.Handled = true;
		}

		public void OnTabItemSelecting(object sender, CurrentChangingEventArgs e)
		{
			//this.IsEnabled = false;
			//ConnectionStatus connection = ConnectionStatus.Instance;
			//if (!connection.IsConnected)
			//{
			//	int prevIdx = this.tab.Items.IndexOf(this.OnTabItemSelecting.
			//}
		}
	}
}
