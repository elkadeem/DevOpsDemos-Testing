using CustomersWebapp.Models;
using CustomersWebapp.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CustomersWebApp.IntegrationTesting.CustomersRepsitory
{
    public class CustomerRepositoryIntegrationTest : IClassFixture<CustomersDbContextFixture>
    {
        private readonly CustomersDbContextFixture customersDbContextFixture;

        public CustomerRepositoryIntegrationTest(CustomersDbContextFixture customersDbContextFixture)
        {
            this.customersDbContextFixture = customersDbContextFixture;
        }

        [Fact]
        public async Task Get_Will_Return_Customers_Data()
        {
            //Arrange
            

            CustomersRepository customersRepository = new CustomersRepository(customersDbContextFixture.CustomersDbContext);

            //Act
            var customers = await customersRepository.Get();

            //Assert
            Assert.NotNull(customers);
            Assert.NotEmpty(customers);
        }

        [Fact]
        public async Task Add_Customer_Will_Save_It_In_DB()
        {
            //Arrange            
            CustomersRepository customersRepository = new CustomersRepository(customersDbContextFixture.CustomersDbContext);

            var newCustomer = new Customer("Customer", "email@test.com", "232332")
            {
                Department = "dfgsdgsdgdsgd",
            };
            //Act
            var customers = await customersRepository.Add(newCustomer);

            //Assert
            var customer = await customersDbContextFixture.CustomersDbContext
                .Customers.FirstOrDefaultAsync(c => c.Name == "Customer");
            Assert.NotNull(customer);
            Assert.Equal(newCustomer.Name, customer.Name);
            Assert.Equal(newCustomer.Email, customer.Email);
            Assert.Equal(newCustomer.Department, customer.Department);
            Assert.Equal(newCustomer.Phone, customer.Phone);
        }
    }
}
