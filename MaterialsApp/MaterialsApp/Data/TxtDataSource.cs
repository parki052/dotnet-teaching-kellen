using MaterialsApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MaterialsApp.Data
{
    class TxtDataSource : IDataSource
    {
        private List<User> Users { get; set; }
        private string SaveFile { get; set; }

        public TxtDataSource()
        {
            Users = new List<User>();
            SaveFile = Settings.FilePath;

            if (File.Exists(SaveFile))
            {
                PopulateUsers();
            }
            else
            {
                File.Create(SaveFile).Close();
            }
        }

        private void PopulateUsers()
        {
            using(StreamReader sr = File.OpenText(SaveFile))
            {
                string line = "";

                while ((line = sr.ReadLine()) != null) 
                {
                    string[] splitLine = line.Split(',');

                    User user = new User()
                    {
                        Username = splitLine[0],
                        WoodCount = int.Parse(splitLine[1]),
                        StoneCount = int.Parse(splitLine[2]),
                        IronCount = int.Parse(splitLine[3]),
                        GoldCount = int.Parse(splitLine[4])
                    };

                    Users.Add(user);
                }
            }
        }

        private void RewriteSave()
        {
            File.Delete(SaveFile);
            File.Create(SaveFile).Close();

            int currentLine = 0;
            using(StreamWriter sw = File.AppendText(SaveFile))
            {
                foreach(var user in Users)
                {
                    if(currentLine != 0)
                    {
                        sw.Write("\n");
                    }

                    sw.Write($"{user.Username},{user.WoodCount},{user.StoneCount},{user.IronCount},{user.GoldCount}");
                    currentLine++;
                }
            }
        }

        public User Authenticate(string username) => Users.SingleOrDefault(user => user.Username == username);

        public User GetUser(User user) => user;

        public void DepositWood(User user, int amount) 
        {
            user.WoodCount += amount;
            RewriteSave();
        }

        public void DepositGold(User user, int amount)
        {
            user.GoldCount += amount;
            RewriteSave();
        }

        public void DepositStone(User user, int amount)
        {
            user.StoneCount += amount;
            RewriteSave();
        }

        public void DepositIron(User user, int amount)
        {
            user.IronCount += amount;
            RewriteSave();
        }

        public void WithdrawWood(User user, int amount) 
        {
            user.WoodCount -= amount;
            RewriteSave();
        }

        public void WithdrawGold(User user, int amount)
        {
            user.GoldCount -= amount;
            RewriteSave();
        }

        public void WithdrawStone(User user, int amount)
        {
            user.StoneCount -= amount;
            RewriteSave();
        }

        public void WithdrawIron(User user, int amount)
        {
            user.IronCount -= amount;
            RewriteSave();
        }
    }
}
