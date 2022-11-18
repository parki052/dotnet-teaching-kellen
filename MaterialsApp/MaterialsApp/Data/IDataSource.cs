using MaterialsApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaterialsApp.Data
{
    public interface IDataSource
    {
        public User GetUser(User user);
        public void DepositWood(User user, int amount);
        public void DepositStone(User user, int amount);
        public void DepositIron(User user, int amount);
        public void DepositGold(User user, int amount);
        public User Authenticate(string username);
        public void WithdrawGold(User user, int withdrawAmount);
        public void WithdrawIron(User user, int withdrawAmount);
        public void WithdrawStone(User user, int withdrawAmount);
        public void WithdrawWood(User user, int withdrawAmount);
    }
}
