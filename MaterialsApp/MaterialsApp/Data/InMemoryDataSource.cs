using MaterialsApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaterialsApp.Data
{
    class InMemoryDataSource : IDataSource
    {
        private List<User> Users { get; set; }
        public InMemoryDataSource()
        {
            Users = new List<User>()
            {
                new User()
                {
                    Username = "Timmy",
                    WoodCount = 0,
                    StoneCount = 0,
                    IronCount = 0,
                    GoldCount = 0
                },
                new User()
                {
                    Username = "Doug",
                    WoodCount = 5000,
                    StoneCount = 1000,
                    IronCount = 3000,
                    GoldCount = 100000
                }
            };
        }

        public void CheckResources()
        {
            
        }
        public void DepositResource()
        {

        }
        public void WithdrawResource()
        {

        }
    }
}
