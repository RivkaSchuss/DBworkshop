using Moodify.Containers;

namespace Moodify.Singletons
{
    class CustomPlaylistSingleton
    {
        /// <summary>
        /// Getter for the singleton instance.
        /// </summary>
        /// <value>
        /// The instance itself.
        /// </value>
        public static CustomPlaylistSingleton Instance { get; } = new CustomPlaylistSingleton();

        public Playlist CustomPlaylist { get; set; }

        /// <summary>
        /// Prevents a default instance of the <see cref="CustomPlaylistSingleton"/> class from being created.
        /// </summary>
        private CustomPlaylistSingleton() { }
    }
}
