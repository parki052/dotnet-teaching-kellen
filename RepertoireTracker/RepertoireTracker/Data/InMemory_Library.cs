using RepertoireTracker.Interfaces;
using RepertoireTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepertoireTracker.Data
{
    class InMemory_Library : ILibrary
    {
        public List<Song> Songs { get; set; }

        public InMemory_Library()
        {
            Songs = new List<Song>()
            {
                new Song()
                {
                    Id = 0,
                    Title = "My first song"
                },
                new Song()
                {
                    Id = 1,
                    Title = "Another one"
                },
                new Song()
                {
                    Id = 2,
                    Title = "Masterpiece"
                },
            };
        }

        public void AddSong(string songName)
        {
            Song song = new Song();
            int newId;

            if (Songs.Count > 0)
            {
                newId = Songs
                          .OrderByDescending(s => s.Id)
                          .First()
                          .Id + 1;
            }
            else
            {
                newId = 1;
            }
            
            song.Id = newId;
            song.Title = songName;

            Songs.Add(song);
        }

        public List<Song> GetAllSongs()
        {
            return Songs;
        }
    }
}
