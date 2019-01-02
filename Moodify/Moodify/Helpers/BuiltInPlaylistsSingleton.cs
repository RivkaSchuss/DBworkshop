using Moodify.Model;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace Moodify.Helpers
{
    public class BuiltInPlaylistsSingleton
    {
        private static BuiltInPlaylistsSingleton instance = null;

        public static BuiltInPlaylistsSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BuiltInPlaylistsSingleton();
                }
                return instance;
            }
        }

        public BuiltInPlaylistsSingleton()
        {
            this.PlaylistDictionary = CreateDictionary();
        }

        public Dictionary<Mood, ObservableCollection<Playlist>> CreateDictionary()
        {
            int lowTempo = 40;
            int mediumTempo = 100;
            int highTempo = 140;

            Dictionary<Mood, ObservableCollection<Playlist>> dic = new Dictionary<Mood, ObservableCollection<Playlist>>()
            {
                { new Mood("Fun", new Genre(), highTempo), AddFunPlaylist() },
                { new Mood("Chill", new Genre(), lowTempo), AddChillPlaylist() },
                { new Mood("Party", new Genre(), highTempo), AddPartyPlaylist() },
                { new Mood("Romantic", new Genre(), mediumTempo), AddRomanticPlaylist() },
                { new Mood("Sad", new Genre(), lowTempo), AddSadPlaylist() }
            };
            ObservableCollection<Mood> generics = new ObservableCollection<Mood>();

            return dic;
        }

        public Dictionary<Mood, ObservableCollection<Playlist>> PlaylistDictionary
        {
            get; set;
        }

        public ObservableCollection<Playlist> AddFunPlaylist()
        {
            return null;
        }

        public ObservableCollection<Playlist> AddChillPlaylist()
        {
            return GetPlaylistsByMood(53, 105, -40, -30, 8, "Chill_Bulit");
        }

        public ObservableCollection<Playlist> AddPartyPlaylist()
        {
            return null;
        }

        public ObservableCollection<Playlist> AddRomanticPlaylist()
        {
            return null;
        }

        public ObservableCollection<Playlist> AddSadPlaylist()
        {
            return null;
        }

        public ObservableCollection<Playlist> GetPlaylistsByMood(float minTempo, float maxTempo, float minLoudness, float maxLoudness, int playlistID, string playlistName)
        {
            DBHandler handler = DBHandler.Instance;
            string query = string.Format(@"SELECT song_id as SongId, title as SongName, artist_name as ArtistName, duration as Duration
                                FROM (SELECT *
                                FROM song_analysis natural JOIN song_info NATURAL JOIN similar_artists NATURAL JOIN artists
                                GROUP BY song_id
                                HAVING tempo >=53 and tempo <= 105 and
                                 loudness >= -40 and loudness <= -30
                                ORDER BY song_hotness DESC) as joined", minTempo, maxTempo, minLoudness, maxLoudness);
            JArray result = handler.ExecuteWithResults(query);
            ObservableCollection <Playlist> playlists =  new ObservableCollection<Playlist>();
            playlists.Add(ParsePlaylist(result, playlistID, playlistName));
            return playlists;
        }

        public Playlist ParsePlaylist(JArray jsonPlaylist, int playlistID, string playlistName)
        {
            Playlist playlist = new Playlist()
            {
                PlaylistId = playlistID,
                PlaylistName = playlistName,
                Songs = new ObservableCollection<Song>()
            };
            foreach (var entry in jsonPlaylist)
            {
                var artist = new Artist()
                {
                    ArtistName = (string)entry["ArtistName"]
                };
                var song = new Song()
                {
                    SongId = int.Parse((string)entry["SongId"]),
                    SongName = (string)entry["SongName"],
                    SongArtist = artist,
                    Duration = float.Parse((string)entry["Duration"])
                };
                //int playlistId = int.Parse((string)jsonPlaylist["PlaylistId"]);
                playlist.Songs.Add(song);

            }
            return playlist;      
        }


        //public ObservableCollection<Playlist> AddExamplePlaylists()
        //{
        //    ObservableCollection<Playlist> playlists = new ObservableCollection<Playlist>();

        //    Playlist test = new Playlist();
        //    test.PlaylistName = "Rivka's playlist";
        //    test.PlaylistId = 12;
        //    Song song1 = new Song();
        //    song1.SongName = "lalala";
        //    Song song2 = new Song();
        //    song2.SongName = "jdjdjd";
        //    test.Songs = new ObservableCollection<Song>();
        //    test.Songs.Add(song1);
        //    test.Songs.Add(song2);
        //    playlists.Add(test);

        //    Playlist test2 = new Playlist();
        //    test2.PlaylistName = "Avihay's playlist";
        //    test2.PlaylistId = 15;
        //    Song song3 = new Song();
        //    song3.SongName = "lalala";
        //    Song song4 = new Song();
        //    song4.SongName = "jdjdjd";
        //    test2.Songs = new ObservableCollection<Song>();
        //    test2.Songs.Add(song3);
        //    test2.Songs.Add(song4);
        //    playlists.Add(test2);

        //    return playlists;
        //}
    }
}
