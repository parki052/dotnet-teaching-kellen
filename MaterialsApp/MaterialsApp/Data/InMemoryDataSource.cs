using MaterialsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public User CheckResources(User user) => user;

        public void WithdrawResource(User user)
        {

        }
        public User Authenticate(string username) => Users.SingleOrDefault(user => user.Username == username);

        public void DepositWood(User user, int amount) => user.WoodCount += amount;

        public void DepositStone(User user, int amount) => user.StoneCount += amount;

        public void DepositIron(User user, int amount) => user.IronCount += amount;

        public void DepositGold(User user, int amount) => user.GoldCount += amount;
    }
}
