using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceDemo
{
    class Goblin : Enemy
    {

        public Goblin(int maxHealth) : base(maxHealth, "I'm a Goblin!")
        {
            
        }
    }
}
