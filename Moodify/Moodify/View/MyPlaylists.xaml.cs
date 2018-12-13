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

namespace Moodify.View
{
	/// <summary>
	/// Interaction logic for MyPlaylists.xaml
	/// </summary>
	public partial class MyPlaylists : UserControl
	{
        public IMyPlaylistsVM viewModel;
        public ICommand openPlaylist;

		public MyPlaylists()
		{
			InitializeComponent();
            this.viewModel = new MyPlaylistsViewModel();
            this.DataContext = this.viewModel;
		}

        //private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        //{
          //  PlaylistView playlistView = new PlaylistView(this.viewModel);
            //playlistView.Show();
        //}

        //public
    }
}
