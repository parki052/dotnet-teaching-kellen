using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceDemo
{
    class Enemy
    {
        public int MaxHealth { get; set; }
        public int Health { get; set; }
        public string Message { get; set; }

        public Enemy(int maxHealth, string message)
        {
            MaxHealth = maxHealth;
            Health = maxHealth;
            Message = message;
        }
    }
}
