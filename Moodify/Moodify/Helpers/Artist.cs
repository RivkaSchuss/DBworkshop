using System.Globalization;

namespace Moodify.Helpers
{
	/// <summary>
	/// Class to define Artist for the Program
	/// </summary>
	public class Artist
    {
        private int artistId;
        private string artistName;
        private string genre;
        private float artist_hotness;

        private TextInfo TextInfoProp { get; set; } = new CultureInfo(CultureInfo.CurrentUICulture.ToString(), false).TextInfo;

        public int ArtistId
        {
            set
            {
                this.artistId = value;
            }
            get
            {
                return this.artistId;
            }
        }

        public string ArtistName
        {
            set
            {
                this.artistName = value;
            }
            get
            {
                return this.artistName;
            }
        }

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

        public float ArtistHotness
        {
            set
            {
                this.artist_hotness = value;
            }
            get
            {
                return this.artist_hotness;
            }
        }
    }
}
