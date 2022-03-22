using CustomersWebapp.Controllers;
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
            var result = customersController.Index(null, null, null);

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
            var result = customersController.Index(search, null, null);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Index_Search_By_Email_Will_Return_View()
        {
            //Arrange
            CustomersController customersController = new CustomersController();
            string search = "email 1";
            //Act
            var result = customersController.Index(null, search, null);

            //Assert
            Assert.NotNull(result);
        }
    }
}