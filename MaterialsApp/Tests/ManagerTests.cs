using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MaterialsApp.Data;
using MaterialsApp.Logic;
using MaterialsApp.Models;
using Xunit;

namespace Tests
{
    public class ManagerTests
    {
        [Fact]
        public void Manager_CheckResources_CanCheckResources()
        {
            InMemoryDataSource dataSource = new InMemoryDataSource();
            Manager manager = new Manager(dataSource);

            foreach (var user in dataSource.Users)
            {
                WorkflowResponse response = manager.CheckResources(user.Username);

                int expectedWood = user.WoodCount;
                int expectedStone = user.StoneCount;
                int expectedIron = user.IronCount;
                int expectedGold = user.GoldCount;

                int actualWood = response.User.WoodCount;
                int actualStone = response.User.StoneCount;
                int actualIron = response.User.IronCount;
                int actualGold = response.User.GoldCount;

                Assert.Equal(expectedWood, actualWood);
                Assert.Equal(expectedStone, actualStone);
                Assert.Equal(expectedIron, actualIron);
                Assert.Equal(expectedGold, actualGold);
            }
        }

        #region DepositResource Tests

        [Theory]
        [InlineData("Timmy", 15)]
        [InlineData("Doug", 15)]
        [InlineData("Timmy", 1000)]
        [InlineData("Doug", 1000)]
        [InlineData("Timmy", 1)]
        [InlineData("Doug", 1)]
        public void Manager_DepositResource_CanDepositGold(string username, int depositAmount)
        {
            InMemoryDataSource dataSource = new InMemoryDataSource();
            Manager manager = new Manager(dataSource);

            User user = dataSource.Users.Single(u => u.Username == username);
            int expectedResult = user.GoldCount + depositAmount;

            manager.DepositResource(username, ResourceType.Gold, depositAmount);

            Assert.Equal(expectedResult, user.GoldCount);
        }

        [Theory]
        [InlineData("Timmy", 15)]
        [InlineData("Doug", 15)]
        [InlineData("Timmy", 1000)]
        [InlineData("Doug", 1000)]
        [InlineData("Timmy", 1)]
        [InlineData("Doug", 1)]
        public void Manager_DepositResource_CanDepositStone(string username, int depositAmount)
        {
            InMemoryDataSource dataSource = new InMemoryDataSource();
            Manager manager = new Manager(dataSource);

            User user = dataSource.Users.Single(u => u.Username == username);
            int expectedResult = user.StoneCount + depositAmount;

            manager.DepositResource(username, ResourceType.Stone, depositAmount);

            Assert.Equal(expectedResult, user.StoneCount);
        }

        [Theory]
        [InlineData("Timmy", 15)]
        [InlineData("Doug", 15)]
        [InlineData("Timmy", 1000)]
        [InlineData("Doug", 1000)]
        [InlineData("Timmy", 1)]
        [InlineData("Doug", 1)]
        public void Manager_DepositResource_CanDepositWood(string username, int depositAmount)
        {
            InMemoryDataSource dataSource = new InMemoryDataSource();
            Manager manager = new Manager(dataSource);

            User user = dataSource.Users.Single(u => u.Username == username);
            int expectedResult = user.WoodCount + depositAmount;

            manager.DepositResource(username, ResourceType.Wood, depositAmount);

            Assert.Equal(expectedResult, user.WoodCount);
        }

        [Theory]
        [InlineData("Timmy", 15)]
        [InlineData("Doug", 15)]
        [InlineData("Timmy", 1000)]
        [InlineData("Doug", 1000)]
        [InlineData("Timmy", 1)]
        [InlineData("Doug", 1)]
        public void Manager_DepositResource_CanDepositIron(string username, int depositAmount)
        {
            InMemoryDataSource dataSource = new InMemoryDataSource();
            Manager manager = new Manager(dataSource);

            User user = dataSource.Users.Single(u => u.Username == username);
            int expectedResult = user.IronCount + depositAmount;

            manager.DepositResource(username, ResourceType.Iron, depositAmount);

            Assert.Equal(expectedResult, user.IronCount);
        }

        [Theory]
        [InlineData("asdf")]
        [InlineData("invalid")]
        [InlineData("")]
        public void Manager_DepositResource_UserCannotBeNull(string username)
        {
            InMemoryDataSource dataSource = new InMemoryDataSource();
            Manager manager = new Manager(dataSource);

            var response = manager.DepositResource(username, ResourceType.Gold, 50);

            Assert.False(response.Success);
            Assert.Equal($"Error: user {username} not found. Press any key to return to the main menu... ", response.Message);
        }

        [Theory]
        [InlineData("Timmy")]
        [InlineData("Doug")]
        public void Manager_DepositResource_CannotDepositInvalidResourceType(string username)
        {
            InMemoryDataSource dataSource = new InMemoryDataSource();
            Manager manager = new Manager(dataSource);

            var result = manager.DepositResource(username, ResourceType.Invalid, 50);

            Assert.False(result.Success);
            Assert.Equal("Error: resource type selection was not valid. Press any key to return to the main menu...", result.Message);
        }

        [Theory]
        [InlineData("Timmy", ResourceType.Gold, 0)]
        [InlineData("Timmy", ResourceType.Gold, -1)]
        [InlineData("Timmy", ResourceType.Gold, -100)]
        [InlineData("Doug", ResourceType.Gold, 0)]
        [InlineData("Doug", ResourceType.Gold, -1)]
        [InlineData("Timmy", ResourceType.Wood, 0)]
        [InlineData("Timmy", ResourceType.Wood, -1)]
        [InlineData("Timmy", ResourceType.Wood, -100)]
        [InlineData("Doug", ResourceType.Wood, 0)]
        [InlineData("Doug", ResourceType.Wood, -1)]
        [InlineData("Timmy", ResourceType.Stone, 0)]
        [InlineData("Timmy", ResourceType.Stone, -1)]
        [InlineData("Timmy", ResourceType.Stone, -100)]
        [InlineData("Doug", ResourceType.Stone, 0)]
        [InlineData("Doug", ResourceType.Stone, -1)]
        [InlineData("Timmy", ResourceType.Iron, 0)]
        [InlineData("Timmy", ResourceType.Iron, -1)]
        [InlineData("Timmy", ResourceType.Iron, -100)]
        [InlineData("Doug", ResourceType.Iron, 0)]
        [InlineData("Doug", ResourceType.Iron, -1)]
        public void Manager_DepositResource_CannotDepositInvalidAmount(string username, ResourceType resource, int depositAmount)
        {
            InMemoryDataSource dataSource = new InMemoryDataSource();
            Manager manager = new Manager(dataSource);

            var result = manager.DepositResource(username, resource, depositAmount);

            Assert.False(result.Success);
            Assert.Equal("Error: resouce amount must be an integer greater than 0. Press any key to return to the main menu...", result.Message);
        }
        #endregion

        #region WithdrawResource Tests

        [Theory]
        [InlineData("asdf")]
        [InlineData("invalid")]
        [InlineData("")]
        public void Manager_WithdrawResource_UserCannotBeNull(string username)
        {
            InMemoryDataSource dataSource = new InMemoryDataSource();
            Manager manager = new Manager(dataSource);

            var response = manager.WithdrawResource(username, ResourceType.Gold, 50);

            Assert.False(response.Success);
            Assert.Equal($"Error: user {username} not found. Press any key to return to the main menu... ", response.Message);
        }

        [Theory]
        [InlineData("Timmy")]
        [InlineData("Doug")]
        public void Manager_WithdrawResource_CannotWithdrawInvalidResourceType(string username)
        {
            InMemoryDataSource dataSource = new InMemoryDataSource();
            Manager manager = new Manager(dataSource);

            var result = manager.WithdrawResource(username, ResourceType.Invalid, 50);

            Assert.False(result.Success);
            Assert.Equal("Error: resource type selection was not valid. Press any key to return to the main menu...", result.Message);
        }

        [Theory]
        [InlineData("Timmy", ResourceType.Gold, 0)]
        [InlineData("Timmy", ResourceType.Gold, -1)]
        [InlineData("Timmy", ResourceType.Gold, -100)]
        [InlineData("Doug", ResourceType.Gold, 0)]
        [InlineData("Doug", ResourceType.Gold, -1)]
        [InlineData("Timmy", ResourceType.Wood, 0)]
        [InlineData("Timmy", ResourceType.Wood, -1)]
        [InlineData("Timmy", ResourceType.Wood, -100)]
        [InlineData("Doug", ResourceType.Wood, 0)]
        [InlineData("Doug", ResourceType.Wood, -1)]
        [InlineData("Timmy", ResourceType.Stone, 0)]
        [InlineData("Timmy", ResourceType.Stone, -1)]
        [InlineData("Timmy", ResourceType.Stone, -100)]
        [InlineData("Doug", ResourceType.Stone, 0)]
        [InlineData("Doug", ResourceType.Stone, -1)]
        [InlineData("Timmy", ResourceType.Iron, 0)]
        [InlineData("Timmy", ResourceType.Iron, -1)]
        [InlineData("Timmy", ResourceType.Iron, -100)]
        [InlineData("Doug", ResourceType.Iron, 0)]
        [InlineData("Doug", ResourceType.Iron, -1)]
        public void Manager_WithdrawResource_CannotWithdrawInvalidAmount(string username, ResourceType resource, int withdrawAmount)
        {
            InMemoryDataSource dataSource = new InMemoryDataSource();
            Manager manager = new Manager(dataSource);

            var result = manager.WithdrawResource(username, resource, withdrawAmount);

            Assert.False(result.Success);
            Assert.Equal("Error: resouce amount must be an integer greater than 0. Press any key to return to the main menu...", result.Message);
        }
        
        [Theory]
        [InlineData("Timmy", ResourceType.Wood, 2)]
        [InlineData("Timmy", ResourceType.Stone, 2)]
        [InlineData("Timmy", ResourceType.Iron, 2)]
        [InlineData("Timmy", ResourceType.Gold, 2)]
        [InlineData("Doug", ResourceType.Wood, 5001)]
        [InlineData("Doug", ResourceType.Stone, 1001)]
        [InlineData("Doug", ResourceType.Iron, 3001)]
        [InlineData("Doug", ResourceType.Gold, 100001)]
        public void Manager_WithdrawResource_CannotOverdrawResource(string username, ResourceType resource, int withdrawAmount)
        {
            InMemoryDataSource dataSource = new InMemoryDataSource();
            Manager manager = new Manager(dataSource);

            var result = manager.WithdrawResource(username, resource, withdrawAmount);

            Assert.False(result.Success);
            Assert.Equal($"Error: insufficient balance of {resource}", result.Message);
        }

        [Theory]
        [InlineData("Timmy", 1)]
        [InlineData("Doug", 100000)]
        public void Manager_WithdrawResource_CanWithdrawGold(string username, int withdrawAmount)
        {
            InMemoryDataSource dataSource = new InMemoryDataSource();
            Manager manager = new Manager(dataSource);

            User user = dataSource.Users.Single(u => u.Username == username);
            int expectedResult = user.GoldCount - withdrawAmount;

            manager.WithdrawResource(username, ResourceType.Gold, withdrawAmount);

            Assert.Equal(expectedResult, user.GoldCount);
        }

        [Theory]
        [InlineData("Timmy", 1)]
        [InlineData("Doug", 1000)]
        public void Manager_WithdrawResource_CanWithdrawStone(string username, int withdrawAmount)
        {
            InMemoryDataSource dataSource = new InMemoryDataSource();
            Manager manager = new Manager(dataSource);

            User user = dataSource.Users.Single(u => u.Username == username);
            int expectedResult = user.StoneCount - withdrawAmount;

            manager.WithdrawResource(username, ResourceType.Stone, withdrawAmount);

            Assert.Equal(expectedResult, user.StoneCount);
        }

        [Theory]
        [InlineData("Timmy", 1)]
        [InlineData("Doug", 5000)]
        public void Manager_WithdrawResource_CanWithdrawWood(string username, int withdrawAmount)
        {
            InMemoryDataSource dataSource = new InMemoryDataSource();
            Manager manager = new Manager(dataSource);

            User user = dataSource.Users.Single(u => u.Username == username);
            int expectedResult = user.WoodCount - withdrawAmount;

            manager.WithdrawResource(username, ResourceType.Wood, withdrawAmount);

            Assert.Equal(expectedResult, user.WoodCount);
        }

        [Theory]
        [InlineData("Timmy", 1)]
        [InlineData("Doug", 3000)]
        public void Manager_WithdrawResource_CanWithdrawIron(string username, int withdrawAmount)
        {
            InMemoryDataSource dataSource = new InMemoryDataSource();
            Manager manager = new Manager(dataSource);

            User user = dataSource.Users.Single(u => u.Username == username);
            int expectedResult = user.IronCount - withdrawAmount;

            manager.WithdrawResource(username, ResourceType.Iron, withdrawAmount);

            Assert.Equal(expectedResult, user.IronCount);
        }
        #endregion
    }
}
