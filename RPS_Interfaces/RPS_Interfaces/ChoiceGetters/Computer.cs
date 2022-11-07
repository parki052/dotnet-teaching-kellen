using System;
using System.Collections.Generic;
using System.Text;

namespace RPS_Interfaces.ChoiceGetters
{
    class Computer : IChoiceGetter
    {
        public Choice GetChoice()
        {
            Random rng = new Random();
            int number = rng.Next(1, 4);

            Choice choice;

            switch (number)
            {
                case 1:
                    choice = Choice.Rock;
                    break;

                case 2:
                    choice = Choice.Paper;
                    break;

                case 3:
                    choice = Choice.Scissors;
                    break;

                default:
                    throw new Exception("Error: RngChoice didn't return a value 1-3.");
            }

            return choice;
        }
    }
}
