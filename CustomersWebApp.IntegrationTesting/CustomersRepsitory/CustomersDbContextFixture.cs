using CustomersWebapp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersWebApp.IntegrationTesting.CustomersRepsitory
{
    public class CustomersDbContextFixture : IDisposable
    {
        public CustomersDbContext CustomersDbContext { get;}
        public CustomersDbContextFixture()
        {
            DbContextOptionsBuilder<CustomersDbContext> dbContextOptionsBuilder
                = new DbContextOptionsBuilder<CustomersDbContext>();
            dbContextOptionsBuilder.UseInMemoryDatabase("testdb");
            CustomersDbContext = new CustomersDbContext(dbContextOptionsBuilder.Options);
            CustomersDbContext.Database.EnsureCreated();

            CustomersDbContext.Customers.Add(new Customer("Customer", "email@test.com", "232332")
            {
                Department = "dfgsdgsdgdsgd",
            });            
        }

        public Task InitalizeDb()
        {
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            CustomersDbContext.Dispose();
        }
    }
}
