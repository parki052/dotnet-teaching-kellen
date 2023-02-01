using MaterialsApp.Data;
using MaterialsApp.Logic;
using MaterialsApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaterialsApp
{
    class IO
    {
        private bool Exit { get; set; } = false;

        private Manager Manager { get; set; }

        public IO()
        {
            Manager = new ManagerFactory().GetManager();

            //Manager = new Manager(Settings.DataSource);
        }

        public void Run()
        {
            while (!Exit)
            {
                Menu();
            }
        }

        public void Menu()
        {
            Console.Clear();

            Console.WriteLine("                    ***** Materials App *****\n\n");
            Console.WriteLine("--------------------");
            Console.WriteLine("-  Menu Selection  -");
            Console.WriteLine("--------------------");
            Console.WriteLine("1. Check resources");
            Console.WriteLine("2. Deposit a resource");
            Console.WriteLine("3. Withdraw a resource");
            Console.WriteLine("--------------------\n");
            Console.WriteLine("Press a number to select a menu item, or ESC to quit: ");

            var cki = Console.ReadKey(true);

            switch (cki.Key)
            {
                case ConsoleKey.D1:
                    CheckResourcesWorkflow();
                    break;

                case ConsoleKey.D2:
                    DepositResourceWorkflow();
                    break;

                case ConsoleKey.D3:
                    WithdrawResourceWorkflow();
                    break;

                case ConsoleKey.Escape:
                    Exit = true;
                    break;

                default:
                    break;
            }
        }

        internal void CheckResourcesWorkflow()
        {
            string username = GetUsername();
            WorkflowResponse response = Manager.CheckResources(username);

            if (!response.Success)
            {
                Console.WriteLine(response.Message);
                Console.ReadKey();
            }
            else
            {
                PrintUserResources(response.User);
            }
        }

        internal void DepositResourceWorkflow()
        {
            string username = GetUsername();
            ResourceType resource = GetResourceType();

            if(resource == ResourceType.Invalid)
            {
                Console.WriteLine("Error: invalid resource type selected. Press any key to return to the main menu...");
                Console.ReadKey();
            }
            else
            {
                int depositAmount = GetIntFromUser($"Please enter the number of {resource} to deposit: ");
                WorkflowResponse response = Manager.DepositResource(username, resource, depositAmount);

                if (!response.Success)
                {
                    Console.WriteLine(response.Message);
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine(response.Message);
                    Console.ReadKey();
                }
            }
        }

        internal void WithdrawResourceWorkflow()
        {
            string username = GetUsername();
            ResourceType resource = GetResourceType();

            if(resource == ResourceType.Invalid)
            {
                Console.WriteLine("Error: invalid resource type selected. Press any key to return to the main menu...");
                Console.ReadKey();
            }
            else
            {
                int withdrawAmount = GetIntFromUser($"Please enter the number of {resource} to withdraw: ");

                WorkflowResponse response = Manager.WithdrawResource(username, resource, withdrawAmount);

                if (!response.Success)
                {
                    Console.WriteLine(response.Message);
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine(response.Message);
                    Console.ReadKey();
                }
            }
        }

        private string GetUsername()
        {
            Console.Clear();

            Console.Write("Please enter your username: ");
            string input = Console.ReadLine();

            return input;
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

            bool success = int.TryParse(input, out int parsedInt);

            if (success)
            {
                return parsedInt;
            }
            else
            {
                return -1;
            }
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
