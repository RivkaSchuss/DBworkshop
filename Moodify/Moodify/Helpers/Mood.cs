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

        public Mood(string moodName, Genre genre, float tempo)
        {
            this.MoodName = moodName;
            this.Genre = genre;
            this.Tempo = tempo;
        }

        public Genre Genre
        {
            get;
            set;
        }


        public float Tempo
        {
            get;
            set;

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
