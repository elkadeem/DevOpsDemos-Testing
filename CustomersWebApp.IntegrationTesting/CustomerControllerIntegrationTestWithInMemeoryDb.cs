using CustomersWebApp.IntegrationTesting.Fixtures;
using CustomersWebApp.IntegrationTesting.Helpers;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace CustomersWebapp.Testing
{
    public class CustomerControllerIntegrationTestWithInMemeoryDb : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> factory;
        public CustomerControllerIntegrationTestWithInMemeoryDb(CustomWebApplicationFactory<Program> factory)
        {
            this.factory = factory;
        }

        [Fact]
        public async Task Get_Customer_Will_Return_Ok()
        {
            //Arrange
            var client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = true,
                HandleCookies = true,
            });

            var response = await client.GetAsync("/Identity/Account/Login");
            var htmlDocument = await HtmlHelpers.GetDocumentAsync(response);
            var hiddenElement =  htmlDocument.QuerySelector("input[name='__RequestVerificationToken']");


            var content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>()
            {
              new KeyValuePair<string, string>("Input.Email", "test@email.com"),
              new KeyValuePair<string, string>("Input.Password", "P@ssw0rd@324"),
              new KeyValuePair<string, string>("__RequestVerificationToken"
              , hiddenElement.GetAttribute("value"))
            });
            
            response = await client.PostAsync("/Identity/Account/Login", content);
            response.EnsureSuccessStatusCode();

            //Act
            response = await client.GetAsync("/Customers");

            //Assert
            response.EnsureSuccessStatusCode();
        }
    }

    public class UserLogin
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
