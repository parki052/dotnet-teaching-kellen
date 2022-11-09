using MaterialsApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaterialsApp.Data
{
    interface IDataSource
    {
        public User CheckResources(User user);
        public void DepositWood(User user, int amount);
        public void DepositStone(User user, int amount);
        public void DepositIron(User user, int amount);
        public void DepositGold(User user, int amount);
        public void WithdrawResource(User user);
        public User Authenticate(string username);
    }
}
