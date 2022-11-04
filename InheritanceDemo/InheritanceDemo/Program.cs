using System;

namespace InheritanceDemo
{
    class Program
    {
        static void Main(string[] args) 
        { 
            Goblin goblin = new Goblin(10);
            
            Console.WriteLine(goblin.Message + " " + $" ({goblin.Health}/{goblin.MaxHealth} HP)");

            Golem golem = new Golem(500);

            Console.WriteLine(golem.Message + " " + $" ({golem.Health}/{golem.MaxHealth} HP)");

            Console.ReadKey();
        }
    }
}

