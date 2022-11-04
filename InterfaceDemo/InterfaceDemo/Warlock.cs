using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceDemo
{
    class Warlock : IEnemy
    {
        public string Name { get; set; }
        public int Health { get; set; }

        public Warlock(string name, int health)
        {
            Name = name;
            Health = health;
        }

        public void Battlecry()
        {
            Console.WriteLine($"I'm the feared warlock known as {Name}");
        }
    }
}
