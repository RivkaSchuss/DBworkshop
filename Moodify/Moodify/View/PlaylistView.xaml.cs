﻿using Moodify.ViewModel;
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
using Moodify.Containers;
using Moodify.ViewModel.PlaylistVM;

namespace Moodify.View
{
    /// <summary>
    /// Interaction logic for PlaylistView.xaml
    /// </summary>
    public partial class PlaylistView : Window
    {
        public PlaylistView(IDictionary<int, Playlist> playlists, int playlistId)
        {
            InitializeComponent();
            Playlist currentPlaylist = playlists[playlistId];
            this.DataContext = new PlaylistViewModel(currentPlaylist);
        }

		/// <summary>
		/// Handles the PreviewMouseWheel event of the ScrollViewer control.
		/// Make the table to scroll properly
		/// </summary>
		private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
		{
			ScrollViewer svc = (ScrollViewer)sender;
			svc.ScrollToVerticalOffset(svc.VerticalOffset - e.Delta);
			e.Handled = true;
		}
	}
}
