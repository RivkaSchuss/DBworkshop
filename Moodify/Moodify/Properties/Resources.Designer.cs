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
        ///   Looks up a localized string similar to SELECT playlist_affiliation.playlist_id as PlaylistId, playlist_name as PlaylistName, playlist_songs.song_id as SongId, title as SongName, artist_name as ArtisName, duration as Duration
        ///                            from playlist_info, playlist_affiliation, playlist_songs, song_info, artists, song_analysis
        ///                            where playlist_affiliation.user_id = &apos;{0}&apos; and playlist_affiliation.playlist_id = playlist_info.playlist_id
        ///                             and playlist_info.playlist_id = playli [rest of string was truncated]&quot;;.
        /// </summary>
        public static string SqlGetUserPlaylistsQuery {
            get {
                return ResourceManager.GetString("SqlGetUserPlaylistsQuery", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT into users (username, email, password) VALUES (&apos;{userName}&apos;, &apos;{email}&apos;, &apos;{password}&apos;).
        /// </summary>
        public static string SqlRegisterQuery {
            get {
                return ResourceManager.GetString("SqlRegisterQuery", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT user_id from users
        ///WHERE binary username = &apos;{userName}&apos; and binary password = &apos;{password}&apos;.
        /// </summary>
        public static string SqlSignInQuery {
            get {
                return ResourceManager.GetString("SqlSignInQuery", resourceCulture);
            }
        }
    }
}
