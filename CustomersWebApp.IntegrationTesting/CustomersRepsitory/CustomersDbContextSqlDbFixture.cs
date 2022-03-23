using CustomersWebapp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersWebApp.IntegrationTesting.CustomersRepsitory
{
    public class CustomersDbContextSqlDbFixture : IDisposable
    {
        public CustomersDbContext CustomersDbContext { get;}
        public CustomersDbContextSqlDbFixture()
        {
            DbContextOptionsBuilder<CustomersDbContext> dbContextOptionsBuilder
                = new DbContextOptionsBuilder<CustomersDbContext>();
            dbContextOptionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=aspnet-CustomersWebapp-Testing-Db;Trusted_Connection=True;MultipleActiveResultSets=true");
            CustomersDbContext = new CustomersDbContext(dbContextOptionsBuilder.Options);            
            CustomersDbContext.Database.EnsureDeleted();
            CustomersDbContext.Database.Migrate();

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
