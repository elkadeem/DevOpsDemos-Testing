using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using Xunit;

namespace CustomersWebapp.UITesting
{
    public class LoginTest : IDisposable
    {
        private IWebDriver _webDriver;

        public LoginTest()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            _webDriver = new ChromeDriver();
        }

        public void Dispose()
        {
            _webDriver.Quit();
        }

        [Fact]
        public void Login_With_UserName_And_Password()
        {
            _webDriver.Navigate().GoToUrl("");
        }
    }
}