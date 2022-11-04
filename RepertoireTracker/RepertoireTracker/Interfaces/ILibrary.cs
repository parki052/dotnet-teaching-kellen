using RepertoireTracker.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepertoireTracker.Interfaces
{
    interface ILibrary
    {
        public List<Song> Songs { get; set; }

        public void AddSong(string songName);

        public List<Song> GetAllSongs();
    }
}
