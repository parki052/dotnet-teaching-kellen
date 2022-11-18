using MaterialsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaterialsApp.Data
{
    public class InMemoryDataSource : IDataSource
    {
        public List<User> Users { get; set; }
        
        public InMemoryDataSource()
        {
            Users = new List<User>()
            {
                new User()
                {
                    Username = "Timmy",
                    WoodCount = 1,
                    StoneCount = 1,
                    IronCount = 1,
                    GoldCount = 1
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

        public User GetUser(User user) => user;

        public User Authenticate(string username) => Users.SingleOrDefault(user => user.Username == username);

        public void DepositWood(User user, int amount) => user.WoodCount += amount;

        public void DepositStone(User user, int amount) => user.StoneCount += amount;

        public void DepositIron(User user, int amount) => user.IronCount += amount;

        public void DepositGold(User user, int amount) => user.GoldCount += amount;

        public void WithdrawGold(User user, int amount) => user.GoldCount -= amount;

        public void WithdrawIron(User user, int amount) => user.IronCount -= amount;

        public void WithdrawStone(User user, int amount) => user.StoneCount -= amount;

        public void WithdrawWood(User user, int amount) => user.WoodCount -= amount;
    }
}