using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace CustomersWebapp.Testing
{
    public class CustomerControllerIntegrationTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> factory;

        public CustomerControllerIntegrationTest(WebApplicationFactory<Program> factory)
        {            
            this.factory = factory;
        }

        [Theory]
        [InlineData("/customers")]
        [InlineData("/customers/create")]
        public async Task Call_Secure_Page_Will_Return_302(string page)
        {
            //Arrange
            var client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });

            //Act
            var response = await client.GetAsync(page);

            //Assert
            Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);
            Assert.Contains("/Identity/Account/Login", response.Headers.Location.OriginalString);
        }

        [Theory]
        [InlineData("/")]
        [InlineData("/Home/Privacy")]
        [InlineData("/Identity/Account/Register")]
        [InlineData("/Identity/Account/Login")]        
        public async Task Call_Links_Will_Return_Ok(string page)
        {            
            //Arrange
            var client = factory.CreateClient();

            //Act
            var response = await client.GetAsync(page);

            //Assert
            response.EnsureSuccessStatusCode();
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
