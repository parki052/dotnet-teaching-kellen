using RepertoireTracker.Data;
using RepertoireTracker.Interfaces;
using RepertoireTracker.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepertoireTracker.BLL
{
    class Workflow
    {
        private ILibrary Library { get; set; }

        public Workflow(ILibrary library)
        {
            Library = library;
        }

        public void AddSong()
        {
            Console.Clear();

            Console.Write("Please enter the name of the song to add: ");

            string songName = Console.ReadLine();

            if(songName == "")
            {
                songName = "Untitled";
            }

            
            Library.AddSong(songName);
        }

        internal void ListSongs()
        {
            Console.Clear();


            foreach(Song song in Library.Songs) 
            {
                Console.WriteLine($"{song.Id}: {song.Title}");
            }
            Console.Write("\n\n\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
