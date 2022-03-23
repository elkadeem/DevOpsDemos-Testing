using CustomersWebapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersWebApp.IntegrationTesting.Fixtures
{
    public static class DatabaseSeeding
    {           
        public static void SeedCustomers(CustomersDbContext customersDbContext)
        {
            customersDbContext.Customers
                .Add(new Customer("customer11", "customer11@email.com", "123456") { ID = 1, Department = "Department" });

           customersDbContext.Customers
                .Add(new Customer("customer22", "customer22@email.com", "234567") { ID = 2, Department = "Department" });

            customersDbContext.Customers
                .Add(new Customer("customer33", "customer33@email.com", "312456") {   
                    ID = 3, Department = "Department"
                });

           customersDbContext.SaveChanges();

        }
    }
}
