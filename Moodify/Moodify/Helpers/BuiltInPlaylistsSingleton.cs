using Moodify.Model;
using Newtonsoft.Json.Linq;
using System;
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
            return CreatePlaylists(53, 105, -40, -30, 3, "Moodify Chill");
        }

        public ObservableCollection<Playlist> AddRomanticPlaylists()
        {
            return CreatePlaylists(106, 158, -29, -19, 6, "Moodify Romantic");
        }

        public ObservableCollection<Playlist> AddPartyPlaylists()
        {
            return CreatePlaylists(159, 211, -18, -8, 9, "Moodify Party");
        }

        public ObservableCollection<Playlist> AddFunPlaylists()
        {
            return CreatePlaylists(212, 270, -51, -7, 12, "Moodify Fun");
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
            Playlist popular = GetPlaylistByMoodByOrder(minTempo, maxTempo, minLoudness, maxLoudness, playlistID, playlistName + " Popular", "song_hotness DESC");
            AddPlaylistToCollection(popular, playlists);
            Playlist indie = GetPlaylistByMoodByOrder(minTempo, maxTempo, minLoudness, maxLoudness, playlistID + 1, playlistName + " Indie", "song_hotness ASC");
            AddPlaylistToCollection(indie, playlists);
            Playlist random = GetPlaylistByMoodByOrder(minTempo, maxTempo, minLoudness, maxLoudness, playlistID + 2, playlistName + " Random", "RAND()");
            AddPlaylistToCollection(random, playlists);
            return playlists;
        }

        private void AddPlaylistToCollection(Playlist playlist, ObservableCollection<Playlist> playlists)
        {
            if (playlist != null)
            {
                playlists.Add(playlist);
            }
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
            if (jsonPlaylist == null)
            {
                return null; 
            }

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
                    RealDuration = float.Parse((string)entry["Duration"])
                };
                playlist.Songs.Add(song);

            }
            return playlist;      
        }

	}
}
