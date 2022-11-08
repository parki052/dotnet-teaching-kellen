using MaterialsApp.Data;
using MaterialsApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaterialsApp.Logic
{
    class Manager
    {
        private IDataSource IDataSource { get; set; }

        public Manager(IDataSource dataSource)
        {
            IDataSource = dataSource;
        }

        public void CheckResources()
        {
            string username = GetUsername();
            User user = IDataSource.Authenticate(username);

            if (user != null)
            {
                User userToCheck = IDataSource.CheckResources(user);
                PrintUserResources(userToCheck);
            }
            else
            {
                Console.WriteLine($"Error: user {username} not found. Press any key to return to the main menu... ");
                Console.ReadKey();
            }
        }

        public void DepositResource()
        {
            string username = GetUsername();
            User user = IDataSource.Authenticate(username);

            if (user != null)
            {
                //implement deposit functionality
            }
        }

        public void WithdrawResource()
        {
            string username = GetUsername();
            User user = IDataSource.Authenticate(username);

            if (user != null)
            {
                //implement withdraw functionality
            }
        }

        private string GetUsername()
        {
            Console.Clear();

            Console.Write("Please enter your username: ");
            string input = Console.ReadLine();
            
            return input;
        }

        private void PrintUserResources(User user)
        {
            Console.Clear();

            Console.WriteLine($"{user.Username}'s Materials:\n\n");
            Console.WriteLine($"Wood: {user.WoodCount}");
            Console.WriteLine($"Stone: {user.StoneCount}");
            Console.WriteLine($"Iron: {user.IronCount}");
            Console.WriteLine($"Gold: {user.GoldCount}");
            Console.WriteLine("\n\nPress any key to return to the main menu...");

            Console.ReadKey();
        }


    }
}
