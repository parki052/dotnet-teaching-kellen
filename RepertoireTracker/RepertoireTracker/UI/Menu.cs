using RepertoireTracker.BLL;
using RepertoireTracker.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepertoireTracker.UI
{
    public class Menu
    {
        public void Run()
        {
            InMemory_Library saveLibrary = new InMemory_Library();
            Workflow workflow = new Workflow(saveLibrary);

            var userExit = false;
            while (!userExit)
            {
                Console.Clear();
                
                Console.WriteLine("** Repertoire Tracker**");
                Console.WriteLine();
                Console.WriteLine("1. List my repertoire");
                Console.WriteLine("2. Add repertoire");
                Console.WriteLine();
                Console.Write("Enter a number to make a selection, or ESC to quit: ");

                var cki = Console.ReadKey(true);



                switch (cki.Key)
                {
                    case ConsoleKey.D1:

                        workflow.ListSongs();

                        break;
                    case ConsoleKey.D2:          
                        
                        workflow.AddSong();

                        break;
                    case ConsoleKey.Escape:

                        userExit = true;

                        break;

                    default:
                        break;
                }
            }
        }
    }
}
