using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moodify.Helpers
{
    public class Mood
    {

        public Mood(string moodName)
        {
            this.MoodName = moodName;
        }

        public ObservableCollection<Song> Songs
        {
            get;
            set;
        }

        public string MoodName
        {
            get;
            set;
        }
    }
}
