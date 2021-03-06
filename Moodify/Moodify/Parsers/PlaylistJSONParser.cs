﻿using System.Collections.ObjectModel;
using Moodify.Containers;
using Newtonsoft.Json.Linq;

namespace Moodify.Parsers
{
	/// <summary>
	/// Parse Playlist from JSON
	/// </summary>
	class PlaylistJSONParser
    {
		/// <summary>
		/// Parses JSON to playlist.
		/// </summary>
		/// <param name="jsonPlaylist">The playlist as JArray.</param>
		/// <param name="playlistID">The playlist identifier.</param>
		/// <param name="playlistName">Name of the playlist.</param>
		/// <returns></returns>
		public static Playlist ParseJSONPlaylist(JArray jsonPlaylist, int playlistID, string playlistName)
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
                    ArtistName = (string)entry["ArtistName"],
                    Genre = (string)entry["Genre"]
                };
                var song = new Song()
                {
                    SongId = int.Parse((string)entry["SongId"]),
                    SongName = (string)entry["SongName"],
                    SongArtist = artist,
                    RealDuration = float.Parse((string)entry["Duration"]),
                    AlbumName = (string)entry["AlbumName"]
                };
                playlist.Songs.Add(song);

            }
            return playlist;
        }
    }
}
