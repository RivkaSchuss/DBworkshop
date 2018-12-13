using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moodify.Helpers
{
    public class Song
    {
        private int songId;
        private string songName;
        private string albumName;
        private Artist artist;
        private float song_hotness;
        private float tempo;
        private float duration;
        private float loudness;

        public int SongId
        {
            set
            {
                this.songId = value;
            }
            get
            {
                return this.songId;
            }
        }

        public string SongName
        {
            set
            {
                this.songName = value;
            }
            get
            {
                return this.songName;
            }
        }
        public string AlbumName
        {
            set
            {
                this.albumName = value;
            }
            get
            {
                return this.albumName;
            }
        }

        public Artist SongArtist
        {
            set
            {
                this.artist = value;
            }
            get
            {
                return this.artist;
            }
        }

        public float SongHotness
        {
            set
            {
                this.song_hotness = value;
            }
            get
            {
                return this.song_hotness;
            }
        }

        public float Tempo
        {
            set
            {
                this.tempo = value;
            }
            get
            {
                return this.tempo;
            }
        }

        public float Duration
        {
            set
            {
                this.duration = value;
            }
            get
            {
                return this.duration;
            }
        }
        public float Loudness
        {
            set
            {
                this.loudness = value;
            }
            get
            {
                return this.loudness;
            }
        }
    }
}
