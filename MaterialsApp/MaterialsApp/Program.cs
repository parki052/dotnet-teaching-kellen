using MaterialsApp.Data;
using Microsoft.Extensions.Configuration;
using System;

namespace MaterialsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            string dataMode = configuration.GetSection("Settings:DataMode").Value;
    
            IDataSource dataSource = ConfigureDataMode(dataMode);
    
            Application application = new Application(dataSource);
            application.Run();
        }

        static IDataSource ConfigureDataMode(string mode)
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