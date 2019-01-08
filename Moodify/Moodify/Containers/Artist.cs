using System.Globalization;

namespace Moodify.Containers
{
    /// <summary>
    /// Class to define Artist for the Program
    /// </summary>
    public class Artist
    {
        private string genre;

        private TextInfo TextInfoProp { get; set; } = new CultureInfo(CultureInfo.CurrentUICulture.ToString(), false).TextInfo;

        public int ArtistId { set; get; }

        public string ArtistName { set; get; }

        public string Genre
        {
            set
            {
                this.genre = value;
            }
            get
            {
                return TextInfoProp.ToTitleCase(this.genre);
            }
        }

        public float ArtistHotness { set; get; }
    }
}
