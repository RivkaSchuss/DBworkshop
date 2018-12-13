using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moodify.Helpers
{
    public class Mood
    {
        private Genre genre;
        private float tempo;
        private string moodName;


        public Genre Genre
        {
            get
            {
                return this.genre;
            }
            set
            {
                this.genre = value;
            }
        }

        public float Tempo
        {
            get
            {
                return this.tempo;
            }
            set
            {
                this.tempo = value;
            }
        }

        public string MoodName
        {
            get
            {
                return this.moodName;
            }
            set
            {
                this.moodName = value;
            }
        }
    }
}
