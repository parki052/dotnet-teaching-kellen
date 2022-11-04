using RepertoireTracker.Interfaces;
using RepertoireTracker.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RepertoireTracker.Data
{
    class SaveFile_Library : ILibrary
    {
        public List<Song> Songs { get; set; }

        private string SaveFile { get; set; }

        public SaveFile_Library()
        {
            SaveFile = @"C:\Data\RepertoireTracker\data.txt";
            Songs = new List<Song>();

            if (File.Exists(SaveFile))
            {
                PopulateSongs();
            }
            else
            {
                File.Create(SaveFile).Close();              
            }
        }

        private void PopulateSongs()
        {
            using(StreamReader sr = File.OpenText(SaveFile))
            {
                string line = "";

                while((line = sr.ReadLine()) != null)
                {
                    string[] splitLine = line.Split(',');

                    Song song = new Song()
                    {
                        Id = int.Parse(splitLine[0]),
                        Title = splitLine[1]
                    };

                    Songs.Add(song);
                }
            }
        }

        public void AddSong(string songName)
        {
            Song song = new Song();
            int newId; 
            
            if(Songs.Count > 0)
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

            using(StreamWriter sw = File.AppendText(SaveFile))
            {
                if(newId != 1)
                {
                    sw.Write("\n");
                }
                sw.Write($"{newId},{songName}");
            }
        }

        public List<Song> GetAllSongs()
        {
            return Songs;
        }
    }
}
