using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumWebDriver.Pages;

namespace SeleniumWebDriver
{
    [TestFixture("selenium")]
    public class NUnitAttributes
    {
        private IWebDriver _driver;
        private readonly string searchTerm;

        public NUnitAttributes(string searchTerm)
        {
            this.searchTerm = searchTerm;
        }

        [SetUp]

        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://www.google.com/");
            _driver.Manage().Window.Maximize();
        }

        [Test]
        [Category("smoke")]
        public void LoginWithPOM()
        {
            LoginPage loginPage = new LoginPage(_driver);
            loginPage.LoginClick();
            loginPage.SearchFieldInput(searchTerm);
        }
        [Test]
        [TestCase("Chrome", "30")]
        public void TestBrowserVersion(string browser, string version)
        {
            Console.WriteLine($"The browser is {browser} and the version is {version}");
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
