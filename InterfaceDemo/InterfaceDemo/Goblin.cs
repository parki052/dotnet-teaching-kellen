using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceDemo
{
    class Goblin : IEnemy
    {
        public string Name { get; set; }
        public int Health { get; set; }

        public Goblin(string name, int health)
        {
            Name = name;
            Health = health;
        }

        public void Battlecry()
        {
            Console.WriteLine($"I'm {Name}. Gonna get ya mate!");
        }
    }
}
