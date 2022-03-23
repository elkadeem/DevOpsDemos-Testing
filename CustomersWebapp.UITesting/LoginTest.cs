using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
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
            _webDriver.Navigate().GoToUrl("http://20.224.244.228:8081/");
            var loginLink = _webDriver.FindElement(By.LinkText("Login"));
            loginLink.Click();

            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            var emailEelement = wait.Until(c => c.FindElement(By.Name("Input.Email")));
            var passwordEelement = _webDriver.FindElement(By.Name("Input.Password"));

            emailEelement.SendKeys("elkadeem@hotmail.com");
            passwordEelement.SendKeys("anypassword");

            var submitButton = _webDriver.FindElement(By.CssSelector("#login-submit"));
            submitButton.Click();

            emailEelement = wait.Until(c => c.FindElement(By.Name("Input.Email")));
            if (emailEelement == null)
                CreateScreenShoot();

            Assert.NotNull(emailEelement);
        }

        private void CreateScreenShoot()
        {
            Screenshot screenshot = (_webDriver as ITakesScreenshot).GetScreenshot();
            screenshot.SaveAsFile("screenshot.png", ScreenshotImageFormat.Png);
        }
    }
}