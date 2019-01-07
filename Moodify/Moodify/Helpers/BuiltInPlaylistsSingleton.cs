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
                { new Mood("Fun", new Genre(), highTempo), AddFunPlaylists() },
                { new Mood("Chill", new Genre(), lowTempo), AddChillPlaylists() },
                { new Mood("Party", new Genre(), highTempo), AddPartyPlaylists() },
                { new Mood("Romantic", new Genre(), mediumTempo), AddRomanticPlaylists() },
                { new Mood("Sad", new Genre(), lowTempo), AddSadPlaylists() }
            };
            return dic;
        }

        public Dictionary<Mood, ObservableCollection<Playlist>> PlaylistDictionary
        {
            get; set;
        }

        public ObservableCollection<Playlist> AddSadPlaylists()
        {
            return CreatePlaylists(0, 52, -51.64, -20, 0, "Moodify Sad");
        }

        public ObservableCollection<Playlist> AddChillPlaylists()
        {
            return CreatePlaylists(53, 105, -40, -30, 2, "Moodify Chill");
        }

        public ObservableCollection<Playlist> AddRomanticPlaylists()
        {
            return CreatePlaylists(106, 158, -29, -19, 4, "Moodify Romantic");
        }

        public ObservableCollection<Playlist> AddPartyPlaylists()
        {
            return CreatePlaylists(159, 211, -18, -8, 6, "Moodify Party");
        }

        public ObservableCollection<Playlist> AddFunPlaylists()
        {
            return CreatePlaylists(212, 270, -51, -7, 8, "Moodify Fun");
        }

        /// <summary>
        /// Creates the playlists by popular (order by DESC), Indie (order by ASC)
        /// </summary>
        /// <param name="minTempo">The minimum tempo.</param>
        /// <param name="maxTempo">The maximum tempo.</param>
        /// <param name="minLoudness">The minimum loudness.</param>
        /// <param name="maxLoudness">The maximum loudness.</param>
        /// <param name="playlistID">The playlist identifier.</param>
        /// <param name="playlistName">Name of the playlist.</param>
        /// <returns></returns>
        public ObservableCollection<Playlist> CreatePlaylists(double minTempo, double maxTempo, double minLoudness, double maxLoudness, int playlistID, string playlistName)
        {
            ObservableCollection<Playlist> playlists = new ObservableCollection<Playlist>();
            playlists.Add(GetPlaylistByMoodByOrder(minTempo, maxTempo, minLoudness, maxLoudness, playlistID, playlistName + " Popular", "DESC"));
            playlists.Add(GetPlaylistByMoodByOrder(minTempo, maxTempo, minLoudness, maxLoudness, playlistID + 1, playlistName + " Indie", "ASC"));
            return playlists;
        }

        /// <summary>
        /// Gets the playlist by mood and by order.
        /// </summary>
        /// <param name="minTempo">The minimum tempo.</param>
        /// <param name="maxTempo">The maximum tempo.</param>
        /// <param name="minLoudness">The minimum loudness.</param>
        /// <param name="maxLoudness">The maximum loudness.</param>
        /// <param name="playlistID">The playlist identifier.</param>
        /// <param name="playlistName">Name of the playlist.</param>
        /// <param name="orderBy">The order by.</param>
        /// <returns></returns>
        public Playlist GetPlaylistByMoodByOrder(double minTempo, double maxTempo, double minLoudness, double maxLoudness, int playlistID, string playlistName, string orderBy)
        {
            DBHandler handler = DBHandler.Instance;
            string query = string.Format(DBQueryManager.Instance.QueryDictionary["SqlGenerateBuiltinPlaylist"], minTempo, maxTempo, minLoudness, maxLoudness, orderBy);
            JArray result = handler.ExecuteWithResults(query);
            return PlaylistParser(result, playlistID, playlistName);
        }

        /// <summary>
        /// Parses the playlist from json (the result of the sql query) to Playlist Object.
        /// </summary>
        /// <param name="jsonPlaylist">The json playlist.</param>
        /// <param name="playlistID">The playlist identifier.</param>
        /// <param name="playlistName">Name of the playlist.</param>
        /// <returns></returns>
        public Playlist PlaylistParser(JArray jsonPlaylist, int playlistID, string playlistName)
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


		public ObservableCollection<Playlist> AddExamplePlaylists()
		{
			ObservableCollection<Playlist> playlists = new ObservableCollection<Playlist>();

			Playlist test = new Playlist();
			test.PlaylistName = "Rivka's playlist";
			test.PlaylistId = 12;
			Song song1 = new Song();
			song1.SongName = "lalala";
			Song song2 = new Song();
			song2.SongName = "jdjdjd";
			test.Songs = new ObservableCollection<Song>();
			test.Songs.Add(song1);
			test.Songs.Add(song2);
			for (int i = 0; i< 10; i++)
			{
				Song songss = new Song();
				songss.SongName ="example" + i.ToString();
				test.Songs.Add(songss);
			}
			playlists.Add(test);

			Playlist test2 = new Playlist();
			test2.PlaylistName = "yael's playlist";
			test2.PlaylistId = 15;
			Song song3 = new Song();
			song3.SongName = "lalala";
			Song song4 = new Song();
			song4.SongName = "jdjdjd";
			test2.Songs = new ObservableCollection<Song>();
			test2.Songs.Add(song3);
			test2.Songs.Add(song4);
			playlists.Add(test2);

			Playlist test3 = new Playlist();
			test3.PlaylistName = "Avihay's playlist";
			test3.PlaylistId = 15;
			Song song31 = new Song();
			song3.SongName = "ldsfsdalala";
			Song song32 = new Song();
			song4.SongName = "jdjfdsadjd";
			test3.Songs = new ObservableCollection<Song>();
			test3.Songs.Add(song3);
			test3.Songs.Add(song4);
			playlists.Add(test3);

			Playlist test4 = new Playlist();
			test4.PlaylistName = "dan's playlist";
			test4.PlaylistId = 15;
			Song song41 = new Song();
			song3.SongName = "hhhhh";
			Song song42 = new Song();
			song4.SongName = "bnnbv";
			test4.Songs = new ObservableCollection<Song>();
			test4.Songs.Add(song3);
			test4.Songs.Add(song4);
			playlists.Add(test4);

			Playlist test5 = new Playlist();
			test5.PlaylistName = "barak's playlist";
			test5.PlaylistId = 15;
			Song song51 = new Song();
			song3.SongName = "cccc";
			Song song52 = new Song();
			song4.SongName = "vvvvv";
			test5.Songs = new ObservableCollection<Song>();
			test5.Songs.Add(song3);
			test5.Songs.Add(song4);
			playlists.Add(test5);

			return playlists;
		}
	}
}
