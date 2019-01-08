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
using Moodify.ViewModel.Explore;

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
			// Sign to the event of ConnectionStatus changed
			connection.PropertyChanged += HandleEvent;
			IsEnabled = false;
			InitializeComponent();
		}

		/// <summary>
		/// Handles the event of ConnectionStatus changed
		/// changed the Is Enable of the tabitem. 
		/// </summary>
		public void HandleEvent(object sender, PropertyChangedEventArgs args)
		{
			this.viewModel = new ExploreViewModel();
            this.DataContext = viewModel;
			this.IsEnabled = connection.IsConnected;
		}

		/// <summary>
		/// Handles the Click event of the Custom Button.
		/// </summary>
		private void Custom_Button_Click(object sender, RoutedEventArgs e)
        {
            CreatePlaylistView view = new CreatePlaylistView();
            view.ShowDialog();
        }

		/// <summary>
		/// Handles the Songs event of the Show button.
		/// </summary>
		private void Show_Songs(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int playlistId = (int)button.CommandParameter;
            ShowSongsView view = new ShowSongsView(playlistId);
            view.ShowDialog();
        }

		/// <summary>
		/// Handles the PreviewMouseWheel event of the ScrollViewer control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="MouseWheelEventArgs"/> instance containing the event data.</param>
		private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
		{
			ScrollViewer svc = (ScrollViewer)sender;
			svc.ScrollToVerticalOffset(svc.VerticalOffset - e.Delta);
			e.Handled = true;
		}

	}
}
