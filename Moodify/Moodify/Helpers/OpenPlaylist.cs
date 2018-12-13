using Moodify.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Moodify.Helpers
{
    public class OpenPlaylist : ICommand
    {
        public void Execute(object parameter)
        {
            PlaylistView playlistView = new PlaylistView((int)parameter);
            playlistView.Show();
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;
    }
}
