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
                User userToCheck = IDataSource.GetUser(user);
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

            if(user == null)
            {
                Console.WriteLine($"Error: user {username} not found. Press any key to return to the main menu... ");
                Console.ReadKey();
            }
            else
            {
                ResourceType resource = GetResourceType();

                if(resource == ResourceType.Invalid)
                {
                    Console.WriteLine("Error: resource type selection was not valid. Press any key to return to the main menu...");
                    Console.ReadKey();
                }
                else
                {
                    int depositAmount = GetIntFromUser($"Please enter the number of {resource} to deposit: ");

                    if(depositAmount <= 0)
                    {
                        Console.WriteLine("Error: resouce amount must be an integer greater than 0. Press any key to return to the main menu...");
                        Console.ReadKey();
                    }
                    else
                    {
                        RouteDeposit(user, resource, depositAmount);
                        Console.WriteLine($"Successfully deposited {depositAmount} {resource} into the account. Press any key to return to the main menu...");
                        Console.ReadKey();
                    }
                }
            }
        }

        private void RouteDeposit(User user, ResourceType resource, int depositAmount)
        {
            switch (resource)
            {
                case ResourceType.Gold:
                    IDataSource.DepositGold(user, depositAmount);
                    break;

                case ResourceType.Iron:
                    IDataSource.DepositIron(user, depositAmount);
                    break;

                case ResourceType.Stone:
                    IDataSource.DepositStone(user, depositAmount);
                    break;

                case ResourceType.Wood:
                    IDataSource.DepositWood(user, depositAmount);
                    break;

                default:
                    throw new Exception("Error: RouteDeposit unable to route deposit request.");
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

        private ResourceType GetResourceType()
        {
            Console.Clear();
            Console.WriteLine("***Select a resource, then press enter***\n");
            Console.WriteLine("1. Wood\n2. Stone\n3. Iron\n4. Gold\n");

            ResourceType resource;
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    resource = ResourceType.Wood;
                    break;

                case "2":
                    resource = ResourceType.Stone;
                    break;

                case "3":
                    resource = ResourceType.Iron;
                    break;

                case "4":
                    resource = ResourceType.Gold;
                    break;

                default:
                    resource = ResourceType.Invalid;
                    break;
            }

            return resource;
        }

        private int GetIntFromUser(string prompt)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            int parsedInt = -1;
            int.TryParse(input, out parsedInt);

            return parsedInt;
        }
    }
}
