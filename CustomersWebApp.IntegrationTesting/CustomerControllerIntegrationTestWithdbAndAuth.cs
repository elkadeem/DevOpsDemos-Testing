using CustomersWebApp.IntegrationTesting.Fixtures;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace CustomersWebapp.Testing
{
    public class CustomerControllerIntegrationTestWithdbAndAuth : IClassFixture<CustomWebApplicationFactoryWithAuthentication<Program>>
    {
        private readonly WebApplicationFactory<Program> factory;

        public CustomerControllerIntegrationTestWithdbAndAuth(CustomWebApplicationFactoryWithAuthentication<Program> factory)
        {            
            this.factory = factory;
        }

        [Fact]
        public async Task Get_Customer_Will_Return_Ok()
        {            
            //Arrange
            var client = factory.CreateClient(new WebApplicationFactoryClientOptions { 
              AllowAutoRedirect = false
            });

            //Act
            var response = await client.GetAsync("/Customers");

            //Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task Get_Customer_Details_Will_Return_Ok()
        {
            //Arrange
            var client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });

            //Act
            var response = await client.GetAsync("/Customers/Details/1");

            //Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task Get_Customer_Details_Will_Return_Not_Found()
        {
            //Arrange
            var client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });

            //Act
            var response = await client.GetAsync("/Customers/Details/100000");

            //Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        //[Fact]
        //public async Task Get_Customer_Will_Return_Ok()
        //{
        //    //var application = new WebApplicationFactory<Program>()
        //    //    .WithWebHostBuilder(builder => { 
        //    //    });

        //    var client = factory.CreateClient();

        //    //Act


        //    //Assert
        //    response.EnsureSuccessStatusCode();
        //}
    }
}
