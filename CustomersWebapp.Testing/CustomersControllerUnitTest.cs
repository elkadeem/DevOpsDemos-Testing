using CustomersWebapp.Controllers;
using CustomersWebapp.Models;
using CustomersWebapp.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace CustomersWebapp.Testing
{
    public class CustomersControllerUnitTest
    {
        private Mock<ICustomersRepository> repositoryStub;
        private readonly CustomersController customersController;
        public CustomersControllerUnitTest()
        {
            repositoryStub = new Mock<ICustomersRepository>();
            customersController = new CustomersController(repositoryStub.Object);
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
            repositoryStub.Setup(c => c.Get())
                .Returns(Task.FromResult(new List<Customer>()));

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
            repositoryStub.Setup(c => c.Get())
                .Returns(Task.FromResult(new List<Customer>()));

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
            repositoryStub.Setup(c => c.Get())
                .Returns(Task.FromResult(new List<Customer>()));

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
            repositoryStub.Setup(c => c.Add(It.IsAny<Customer>()))
                .ReturnsAsync(true);

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

        [Fact]
        public async Task Create_Will_Return_To_View_With_Error_When_Errors_Wile_Saving()
        {
            //Arrange
            repositoryStub.Setup(c => c.Add(It.IsAny<Customer>()))
                .ReturnsAsync(false);

            var customerModel = new CreateCustomerModel
            {
                Name = "name",
                Email = "elkadeem@hotmail.com",
                Phone = "21"
            };
            //Act
            var result = await customersController.Create(customerModel);

            //Assert
            //Here I am working with mock
            repositoryStub.Verify(c => c.Add(It.IsAny<Customer>()), Times.Once);

            Assert.IsType<ViewResult>(result);
            Assert.Equal(customerModel, ((ViewResult)result).Model);
            Assert.False(customersController.ModelState.IsValid);
            Assert.NotEmpty(customersController.ModelState.Values);


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