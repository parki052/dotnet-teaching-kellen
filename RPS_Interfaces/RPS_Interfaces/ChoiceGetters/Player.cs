using System;
using System.Collections.Generic;
using System.Text;

namespace RPS_Interfaces.ChoiceGetters
{
    class Player : IChoiceGetter
    {
        public Choice GetChoice()
        {
            bool validInput = false;
            string input = "";

            Choice choice;

            while (!validInput)
            {
                Console.Write("Please choose R, P, or S and press enter: ");
                input = Console.ReadLine().ToLower();

                if(input != "r" && input != "p" && input != "s")
                {
                    Console.WriteLine($"{input} was not a valid choice, press any key to retry...");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    validInput = true;
                }
            }

            switch (input)
            {
                case "r":
                    choice = Choice.Rock;
                    break;

                case "p":
                    choice = Choice.Paper;
                    break;

                case "s":
                    choice = Choice.Scissors;
                    break;

                default:
                    throw new Exception("Error: Could not parse user input to a Choice.");
            }

            return choice;
        }
    }
}
