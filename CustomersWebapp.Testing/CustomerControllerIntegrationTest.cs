using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        [Fact]
        public async Task Get_Customer_Will_Return_Ok()
        {
            //var application = new WebApplicationFactory<Program>()
            //    .WithWebHostBuilder(builder => { 
            //    });

            var client = factory.CreateClient();

            //Act
            var response = await client.GetAsync("/Customers");

            //Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task Get_Customer_Will_Return_Ok()
        {
            //var application = new WebApplicationFactory<Program>()
            //    .WithWebHostBuilder(builder => { 
            //    });

            var client = factory.CreateClient();

            //Act
            

            //Assert
            response.EnsureSuccessStatusCode();
        }
    }
}
