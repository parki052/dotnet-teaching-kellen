using MaterialsApp.Data;
using MaterialsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;


namespace Tests
{
    public class InMemoryTests
    {
        public List<User> TestUsers = new List<User>()
        {
            new User()
            {
                Username = "Test1",
                WoodCount = 0,
                StoneCount = 0,
                IronCount = 0,
                GoldCount = 0
            },
            new User()
            {
                Username = "Test2",
                WoodCount = 5000,
                StoneCount = 1000,
                IronCount = 3000,
                GoldCount = 100000
            }
        };

        [Fact]
        public void InMemoryDataSource_GetUser_CanGetUser()
        {
            var dataSource = new InMemoryDataSource();

            User authenticatedUser = dataSource.Authenticate("Timmy");

            User user = dataSource.GetUser(authenticatedUser);

            Assert.Equal(authenticatedUser.Username, user.Username);
        }
        [Fact]
        public void InMemoryDataSource_Authenticate_CannotGetInvalidUser()
        {
            var dataSource = new InMemoryDataSource();

            User authenticatedUser = dataSource.Authenticate("Invalid");

            Assert.Null(authenticatedUser);
        }
        [Fact]
        public void InMemoryDataSource_Authenticate_CanAuthenticateUser()
        {
            var dataSource = new InMemoryDataSource();

            User authenticatedUser = dataSource.Authenticate("Timmy");

            Assert.Equal("Timmy", authenticatedUser.Username);
        }
    }
}
