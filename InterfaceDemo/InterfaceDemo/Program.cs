using System;

namespace InterfaceDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnemy enemy1 = new Goblin("Doug", 55);
            IEnemy enemy2 = new Warlock("Gregory", 342);

            IntroduceEnemy(enemy1);
            IntroduceEnemy(enemy2);

        }
        public static void IntroduceEnemy(IEnemy enemy)
        {
            Console.WriteLine("\n-------------------------------------");
            Console.WriteLine($"Name: {enemy.Name} ({enemy.Health} HP)");
            enemy.Battlecry();
            Console.WriteLine("-------------------------------------\n");
        }
    }
}