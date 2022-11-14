using MaterialsApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaterialsApp.Data
{
    class TxtDataSource : IDataSource
    {
        public User Authenticate(string username)
        {
            throw new NotImplementedException();
        }

        public User GetUser(User user)
        {
            throw new NotImplementedException();
        }

        public void DepositGold(User user, int amount)
        {
            throw new NotImplementedException();
        }

        public void DepositIron(User user, int amount)
        {
            throw new NotImplementedException();
        }

        public void DepositStone(User user, int amount)
        {
            throw new NotImplementedException();
        }

        public void DepositWood(User user, int amount)
        {
            throw new NotImplementedException();
        }

        public void WithdrawResource(User user)
        {
            throw new NotImplementedException();
        }
    }
}
