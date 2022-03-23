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
    public class CustomerRepositoryWithSqlIntegrationTest : IClassFixture<CustomersDbContextSqlDbFixture>
    {
        private readonly CustomersDbContextSqlDbFixture customersDbContextFixture;

        public CustomerRepositoryWithSqlIntegrationTest(CustomersDbContextSqlDbFixture customersDbContextFixture)
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
            var newCustomer = new Customer("Customer1", "email1@test.com", "2323321")
            {
                Department = "Department",
            };
            //Act
            using var transaction = customersDbContextFixture.CustomersDbContext.Database.BeginTransaction();
            var customers = await customersRepository.Add(newCustomer);

            //Assert
            var customer = await customersDbContextFixture.CustomersDbContext
                .Customers.FirstOrDefaultAsync(c => c.ID == newCustomer.ID);

            Assert.NotNull(customer);
            Assert.Equal(newCustomer.Name, customer.Name);
            Assert.Equal(newCustomer.Email, customer.Email);
            Assert.Equal(newCustomer.Department, customer.Department);
            Assert.Equal(newCustomer.Phone, customer.Phone);
        }

        [Fact]
        public async Task Add_Customer_With_Duplicated_Email_Will_Throw_Exception()
        {
            //Arrange            
            CustomersRepository customersRepository = new CustomersRepository(customersDbContextFixture.CustomersDbContext);

            var newCustomer = new Customer("Customer1", "email2@test.com", "2323321")
            {
                Department = "Department",
            };

            using var transaction = customersDbContextFixture.CustomersDbContext.Database.BeginTransaction();
            var customers = await customersRepository.Add(newCustomer);

            newCustomer = new Customer("Customer1", "email2@test.com", "2323321")
            {
                Department = "Department",
            };

            //Act
            await Assert.ThrowsAsync<DbUpdateException>(() => customersRepository.Add(newCustomer));
        }
    }
}
