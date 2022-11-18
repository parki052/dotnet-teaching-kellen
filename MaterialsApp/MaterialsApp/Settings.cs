using MaterialsApp.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaterialsApp
{
    public static class Settings
    {
        public static string FilePath { get; set; }
        public static IDataSource DataSource { get; set; }

        static Settings()
        {
            var config =  new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", true, true)
            .Build();
            
            string filePath = config.GetSection("Settings:SaveFilePath").Value;
            SetFilePath(filePath);

            string dataSource = config.GetSection("Settings:DataMode").Value;
            SetDataSource(dataSource);
        }

        static void SetFilePath(string path)
        {
            FilePath = path;
        }

        static void SetDataSource(string mode)
        {
            switch (mode)
            {
                case "InMemory":
                    DataSource =  new InMemoryDataSource();
                    break;

                case "TxtData":
                    DataSource =  new TxtDataSource();
                    break;

                default:
                    throw new Exception("Data mode could not be configured");
            }
        }
    }
}
