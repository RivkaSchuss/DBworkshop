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
	/// Interaction logic for MyPlaylists.xaml
	/// </summary>
	public partial class MyPlaylists : UserControl
	{
        public IMyPlaylistsVM viewModel;
        //private int userId;
		ConnectionStatus connection = ConnectionStatus.Instance;

		public MyPlaylists()
		{
			InitializeComponent();
			connection.PropertyChanged += HandleEvent;
            //this.userId = 0;
			IsEnabled = false;
        }

		public void HandleEvent(object sender, PropertyChangedEventArgs args)
		{
			InitializeComponent();
			this.viewModel = new MyPlaylistsViewModel();
            this.DataContext = this.viewModel;
			this.IsEnabled = connection.IsConnected;
		}

		private void OpenPlaylist_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int playlistId = (int) button.CommandParameter;
            PlaylistView playlistView = new PlaylistView(this.viewModel.VM_PlaylistsDic, playlistId);
            playlistView.ShowDialog();
        }

		private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
		{
			ScrollViewer svc = (ScrollViewer)sender;
			svc.ScrollToVerticalOffset(svc.VerticalOffset - e.Delta);
			e.Handled = true;
		}

	}
}
