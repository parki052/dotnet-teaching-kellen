using MaterialsApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaterialsApp.Data
{
    interface IDataSource
    {
        public User CheckResources(User user);
        public void DepositResource(User user);
        public void WithdrawResource(User user);
        public User Authenticate(string username);
    }
}
