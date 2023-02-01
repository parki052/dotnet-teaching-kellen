using MaterialsApp.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaterialsApp.Logic
{
    public class ManagerFactory
    {
        public Manager GetManager()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            string mode = config.GetSection("Settings:DataMode").Value;

            var dataSource = GetDataSource(mode);

            return new Manager(dataSource);
        }

        private IDataSource GetDataSource(string mode)
        {     
            switch (mode)
            {
                case "InMemory":
                    return new InMemoryDataSource();

                case "TxtData":
                    return new TxtDataSource();

                default:
                    throw new Exception("Data mode could not be configured");
            }
        }
    }
}
