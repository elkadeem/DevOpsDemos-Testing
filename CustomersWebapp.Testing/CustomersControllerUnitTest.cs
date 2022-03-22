using CustomersWebapp.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace CustomersWebapp.Testing
{
    public class CustomersControllerUnitTest
    {
        [Fact]
        public void Customers_Controller_Will_Return_View()
        {
            //Arrange
            CustomersController customersController = new CustomersController();

            //Act
            var result = customersController.Index(new CustomersViewModel());

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Index_Search_By_Name_Will_Return_View()
        {
            //Arrange
            CustomersController customersController = new CustomersController();
            string search = "name1";
            //Act
            var result = customersController.Index(new CustomersViewModel() { Name = search });

            //Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Index_Search_By_Email_Will_Return_View()
        {
            //Arrange
            CustomersController customersController = new CustomersController();
            string search = "email 1";
            //Act
            var result = customersController.Index(new CustomersViewModel() { Email = search });

            //Assert
            Assert.NotNull(result);
        }

        #region Create
        [Fact]
        public void Create_With_Invalid_Data_Will_Return_To_View_With_Model()
        {
            //Arrange
            CustomersController customersController = new CustomersController();
            var customerModel = new CreateCustomerModel
            {
                Name = "name",
                Email = "Invalid",
                Phone = "21"
            };

            //Act
            var result = customersController.Create(customerModel);

            //Assert
            Assert.IsType<ViewResult>(result);
            Assert.Equal(customerModel, ((ViewResult)result).Model);
        }
        #endregion
    }
}