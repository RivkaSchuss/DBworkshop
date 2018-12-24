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

namespace Moodify.View
{
	/// <summary>
	/// Interaction logic for ExploreView.xaml
	/// </summary>
	public partial class ExploreView : UserControl
	{
        private IExploreVM viewModel;
		public ExploreView()
		{
			InitializeComponent();
            this.viewModel = new ExploreViewModel();
            this.DataContext = viewModel;
		}

        private void Custom_Button_Click(object sender, RoutedEventArgs e)
        {
            CreatePlaylistView view = new CreatePlaylistView();
            view.Show();
        }

        private void Add_Playlists(object sender, RoutedEventArgs e)
        {

        }

        private void Show_Songs(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int playlistId = (int)button.CommandParameter;
            ShowSongsView view = new ShowSongsView(playlistId);
            view.Show();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
