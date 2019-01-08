using System.ComponentModel;

namespace Moodify.ViewModel.CreatePlaylist
{
    interface ICreatePlaylistVM : INotifyPropertyChanged
    {
        string VM_PlaylistName { get; set; }
        int VM_NumOfSongs { get; set; }
        float VM_TempoMax { get; set; }
        float VM_TempoMin { get; set; }
        float VM_PopularityMax { get; set; }
        float VM_PopularityMin { get; set; }
        float VM_LoudnessMax { get; set; }
        float VM_LoudnessMin { get; set; }
        void NotifyPropertyChanged(string propName);

        /// <summary>
        /// Generates the custom playlist using the model.
        /// </summary>
        void GenerateCustomPlaylist();
    }
}