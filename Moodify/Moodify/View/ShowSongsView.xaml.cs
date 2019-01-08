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
using System.Windows.Shapes;
using Moodify.ViewModel.ShowSongs;

namespace Moodify.View
{
    /// <summary>
    /// Interaction logic for ShowSongsView.xaml
    /// </summary>
    public partial class ShowSongsView : Window
    {
        ShowSongsViewModel viewModel;

        public ShowSongsView(int playlistId)
        {
            InitializeComponent();
            this.viewModel = new ShowSongsViewModel(playlistId);
            this.DataContext = this.viewModel;
        }

		/// <summary>
		/// Adds the playlists to the user Playlists
		/// </summary>
		private void AddPlaylists(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            this.viewModel.VM_PlaylistID = (int)button.CommandParameter;
        }

		/// <summary>
		/// Clicks the return button, closes the current window.
		/// </summary>
		private void ClickReturn(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		/// <summary>
		/// Handles the PreviewMouseWheel event of the ScrollViewer control.
		/// Makes the Table to able to scroll the window properly.
		/// </summary>
		private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
		{
			ScrollViewer svc = (ScrollViewer)sender;
			svc.ScrollToVerticalOffset(svc.VerticalOffset - e.Delta);
			e.Handled = true;
		}
	}
}
