using System.Collections.ObjectModel;

namespace Moodify.Helpers
{
	/// <summary>
	/// Defines the Mood class for the Program
	/// </summary>
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
