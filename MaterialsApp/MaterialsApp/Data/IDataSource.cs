using System;
using System.Collections.Generic;
using System.Text;

namespace MaterialsApp.Data
{
    interface IDataSource
    {
        public void CheckResources();
        public void DepositResource();
        public void WithdrawResource();
    }
}
