﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Moodify.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Moodify.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to server=localhost; uid=root; pwd=123456; database=moodify_schema.
        /// </summary>
        public static string connectionString {
            get {
                return ResourceManager.GetString("connectionString", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT * FROM users where username = &apos;{0}&apos;.
        /// </summary>
        public static string SqlCheckIfUsernameExists {
            get {
                return ResourceManager.GetString("SqlCheckIfUsernameExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT song_id as SongId, title as SongName, artist_name as ArtistName, album_name as AlbumName, genre as Genre, duration as Duration
        ///                                FROM (SELECT *
        ///                                FROM song_analysis natural JOIN song_info NATURAL JOIN similar_artists NATURAL JOIN artists
        ///                                GROUP BY song_id
        ///                                HAVING tempo &gt;= &apos;{0}&apos; and tempo &lt;= &apos;{1}&apos; and
        ///                                 loudness &gt;= &apos;{2}&apos; and loudness &lt;= &apos;{3}&apos;
        ///   [rest of string was truncated]&quot;;.
        /// </summary>
        public static string SqlGenerateBuiltinPlaylist {
            get {
                return ResourceManager.GetString("SqlGenerateBuiltinPlaylist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT song_id as SongId, title as SongName, artist_name as ArtistName, album_name as AlbumName, genre as Genre, duration as Duration
        ///FROM (SELECT *
        ///FROM song_analysis natural JOIN song_info NATURAL JOIN similar_artists NATURAL JOIN artists
        ///GROUP BY song_id
        ///HAVING tempo &gt;= {0} and tempo &lt;= {1} and
        /// loudness &gt;= {2} and loudness &lt;= {3} and
        /// song_hotness &gt;= {4} and song_hotness &lt;= {5}
        /// ORDER BY RAND()
        ///LIMIT {6}) as joined.
        /// </summary>
        public static string SqlGenerateCustomePlaylist {
            get {
                return ResourceManager.GetString("SqlGenerateCustomePlaylist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT playlist_affiliation.playlist_id as PlaylistId, playlist_name as PlaylistName, playlist_songs.song_id as SongId, title as SongName, artist_name as ArtistName, duration as Duration, genre as Genre, album_name as AlbumName
        ///                            from playlist_info, playlist_affiliation, playlist_songs, song_info, artists, song_analysis
        ///                            where playlist_affiliation.user_id = &apos;{0}&apos; and playlist_affiliation.playlist_id = playlist_info.playlist_id
        ///                          [rest of string was truncated]&quot;;.
        /// </summary>
        public static string SqlGetUserPlaylistsQuery {
            get {
                return ResourceManager.GetString("SqlGetUserPlaylistsQuery", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT into playlist_info (playlist_name) VALUES (&apos;{0}&apos;);
        ///SELECT LAST_INSERT_ID();.
        /// </summary>
        public static string SqlInsertNewPlaylist {
            get {
                return ResourceManager.GetString("SqlInsertNewPlaylist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT INTO playlist_affiliation (playlist_id, user_id) SELECT {0}, user_id FROM users WHERE username = &apos;{1}&apos;;.
        /// </summary>
        public static string SqlInsertPlaylistIDToUser {
            get {
                return ResourceManager.GetString("SqlInsertPlaylistIDToUser", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT into playlist_songs (playlist_id, song_id) VALUES {0};.
        /// </summary>
        public static string SqlInsertSongsWithPlaylistID {
            get {
                return ResourceManager.GetString("SqlInsertSongsWithPlaylistID", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT into users (username, email, password) VALUES (&apos;{0}&apos;, &apos;{1}&apos;, &apos;{2}&apos;);
        ///SELECT LAST_INSERT_ID().
        /// </summary>
        public static string SqlRegisterQuery {
            get {
                return ResourceManager.GetString("SqlRegisterQuery", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT user_id from users
        ///WHERE binary username = &apos;{0}&apos; and binary password = &apos;{1}&apos;.
        /// </summary>
        public static string SqlSignInQuery {
            get {
                return ResourceManager.GetString("SqlSignInQuery", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT SUM(duration) as total_duration from playlist_songs natural join song_analysis where playlist_id = &apos;{0}&apos;.
        /// </summary>
        public static string SqlSumTotalDurationPlaylist {
            get {
                return ResourceManager.GetString("SqlSumTotalDurationPlaylist", resourceCulture);
            }
        }
    }
}
