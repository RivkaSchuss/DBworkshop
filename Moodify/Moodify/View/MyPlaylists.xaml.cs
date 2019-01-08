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
using Moodify.Containers;
using Moodify.ViewModel.MyPlaylists;

namespace Moodify.View
{
	/// <summary>
	/// Interaction logic for MyPlaylists.xaml
	/// </summary>
	public partial class MyPlaylists : UserControl
	{
        public IMyPlaylistsVM viewModel;
		ConnectionStatus connection = ConnectionStatus.Instance;

		public MyPlaylists()
		{
			InitializeComponent();
			// Sign to the event of the connection status
			connection.PropertyChanged += HandleEvent;
			IsEnabled = false;
        }

		/// <summary>
		/// Handles the event of connection status changed.
		/// </summary>
		public void HandleEvent(object sender, PropertyChangedEventArgs args)
		{
			InitializeComponent();
			this.viewModel = new MyPlaylistsViewModel();
            this.DataContext = this.viewModel;
			this.IsEnabled = connection.IsConnected;
		}

		/// <summary>
		/// Handles the Click event of the Show songs button.
		/// </summary>
		private void OpenPlaylist_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int playlistId = (int) button.CommandParameter;
            PlaylistView playlistView = new PlaylistView(this.viewModel.VM_PlaylistsDic, playlistId);
            playlistView.ShowDialog();
        }

		/// <summary>
		/// Handles the PreviewMouseWheel event of the ScrollViewer control.
		/// Makes the table to scroll properly.
		/// </summary>
		private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
		{
			ScrollViewer svc = (ScrollViewer)sender;
			svc.ScrollToVerticalOffset(svc.VerticalOffset - e.Delta);
			e.Handled = true;
		}
	}
}
