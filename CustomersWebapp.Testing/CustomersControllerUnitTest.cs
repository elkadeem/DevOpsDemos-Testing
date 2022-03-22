using CustomersWebapp.Controllers;
using CustomersWebapp.Models;
using CustomersWebapp.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace CustomersWebapp.Testing
{
    public class CustomersControllerUnitTest
    {
        private readonly CustomersController customersController;
        public CustomersControllerUnitTest()
        {
            
            customersController = new CustomersController(new FakeCustomerRepository());
        }

        [Fact]
        public async Task Customers_Controller_Will_Return_View()
        {
            //Arrange

            //Act
            var result = await customersController.Index(new CustomersViewModel());

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Index_Search_By_Name_Will_Return_View()
        {
            //Arrange
            
            string search = "name1";
            //Act
            var result = await customersController.Index(new CustomersViewModel() { Name = search });

            //Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task Index_Search_By_Email_Will_Return_View()
        {
            //Arrange
            
            string search = "email 1";
            //Act
            var result = await customersController.Index(new CustomersViewModel() { Email = search });

            //Assert
            Assert.NotNull(result);
        }

        #region Create
        [Fact]
        public async Task Create_With_Invalid_Data_Will_Return_To_View_With_Model()
        {
            //Arrange
            
            var customerModel = new CreateCustomerModel
            {
                Name = "name",
                Email = "Invalid",
                Phone = "21"
            };
            customersController.ModelState.AddModelError("Email", "Invalid");
            //Act
            var result = await customersController.Create(customerModel);

            //Assert
            Assert.IsType<ViewResult>(result);
            Assert.Equal(customerModel, ((ViewResult)result).Model);
        }

        [Fact]
        public async Task Create_With_valid_Data_Will_Return_Redirect_To_Index()
        {
            //Arrange
            
            var customerModel = new CreateCustomerModel
            {
                Name = "name",
                Email = "elkadeem@hotmail.com",
                Phone = "21"
            };
            //Act
            var result = await customersController.Create(customerModel);

            //Assert
            Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", ((RedirectToActionResult)result).ActionName);
        }
        #endregion
    }

    public class FakeCustomerRepository : ICustomersRepository
    {
        public Task<bool> Add(Customer customer)
        {
            return Task.FromResult(true);
        }

        public Task<List<Customer>> Get()
        {
            return Task.FromResult(new List<Customer>());
        }
    }
}