using RPS_Interfaces.ChoiceGetters;
using System;

namespace RPS_Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Play(new Player(), new Player());
        }
    }
}