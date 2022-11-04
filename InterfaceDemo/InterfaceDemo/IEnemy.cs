using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceDemo
{
    interface IEnemy
    {
        public string Name { get; set; }
        public int Health { get; set; }

        public void Battlecry();
    }
}
