using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumWebDriver.Pages;
using System.Text.Json;

namespace SeleniumWebDriver
{
    internal class DataDrivenTesting 
    {

        private IWebDriver _driver;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://www.google.com/");
            _driver.Manage().Window.Maximize();
            //ReadJsonFile();
        }

        [Test]
        [Category("ddt")]
        [TestCaseSource(nameof(LoginJsonDataSource))]
        public void PageWithPOM(LoginModel loginModel)
        {
            //POM initialization
            //Arrange
            LoginPage loginPage = new LoginPage(_driver);

            //Act
            loginPage.LoginClick();
            loginPage.SearchFieldInput(loginModel.SearchTerm);

            //Assert
            var getLoggedIn= loginPage.IsLoggedIn;
            Assert.That(getLoggedIn, Is.True);
        }

        [Test]
        [Category("ddt")]
        public void PageWithPOMWithJsonData()
        {
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "login.json");
            var jsonString = File.ReadAllText(jsonFilePath);
            var loginModel = JsonSerializer.Deserialize<List<LoginModel>>(jsonString);

            LoginPage loginPage = new LoginPage(_driver);
            loginPage.LoginClick();
            loginPage.SearchFieldInput(loginModel.FirstOrDefault().SearchTerm);
        }

        public static IEnumerable<LoginModel> Login()
        {
            yield return new LoginModel()
            {
                SearchTerm = "automation testing"
            };
            yield return new LoginModel()
            {
                SearchTerm = "new value"
            };
            yield return new LoginModel()
            {
                SearchTerm = "negative value"
            };
        }

        public static IEnumerable<LoginModel> LoginJsonDataSource()
        {
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "login.json");
            var jsonString = File.ReadAllText(jsonFilePath);
            var loginModel = JsonSerializer.Deserialize<List<LoginModel>>(jsonString);
            foreach (var loginData in loginModel)
            {
                yield return loginData;
            }
        }

        private void ReadJsonFile()
        {
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "login.json");
            var jsonString = File.ReadAllText(jsonFilePath);
            var loginModel = JsonSerializer.Deserialize<LoginModel>(jsonString);

            Console.WriteLine($"The searched term is {loginModel.SearchTerm}");

        }

        [TearDown]
        public void TearDown()
        {
          //  _driver.Quit();
          _driver.Dispose();
        }
    }
}

