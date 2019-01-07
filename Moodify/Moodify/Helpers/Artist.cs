using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moodify.Helpers
{
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
