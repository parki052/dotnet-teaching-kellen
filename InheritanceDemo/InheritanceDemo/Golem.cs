using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceDemo
{
    class Golem : Enemy
    {
        public Golem(int maxHealth) : base(maxHealth, "I'm hard!")
        {

        } 
    }
}
