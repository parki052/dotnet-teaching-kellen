using MaterialsApp.Data;
using MaterialsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;


namespace Tests.DataSourceTests
{
    public class InMemoryTests
    {
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
