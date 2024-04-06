using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumWebDriver.Pages;

namespace SeleniumWebDriver
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void VerboseLogin()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.com/");
            driver.Manage().Window.Maximize();
            var webElement = driver.FindElement(By.Id("L2AGLb"));
            webElement.Click();
            var webElement1 = driver.FindElement(By.Name("q"));
            webElement1.SendKeys("apple");
            webElement1.SendKeys(Keys.Return);
            driver.Quit();
        }

        [Test]
        public void ShortenedLogin()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.com/");
            driver.FindElement(By.Id("L2AGLb")).Click();
            driver.FindElement(By.Name("q")).SendKeys("samsung");
            driver.FindElement(By.Name("q")).SendKeys(Keys.Return);
            driver.Quit();
        }

        [Test]
        public void CustomMethodLogin()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.com/");
            IWebElement webElement = driver.FindElement(By.Id("L2AGLb"));
            SeleniumCustomMethods.Click(webElement);
            SeleniumCustomMethods.EnterTextAndReturn(driver, By.Name("q"), "applestore");
            driver.Quit();
        }

        [Test]
        public void LoginWithPOM()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.com/");
            driver.Manage().Window.Maximize();
            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginClick();
            loginPage.SearchFieldInput("tesla");
            driver.Quit();
        }

        [Test]
        public void DropDownTest()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demoqa.com/select-menu");
            var selectElement = new SelectElement(driver.FindElement(By.Id("oldSelectMenu")));
            selectElement.SelectByText("Blue");
            driver.Quit();
        }

        [Test]
        public void DropDownCustomMethod()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demoqa.com/select-menu");
            SeleniumCustomMethods.DropDrownByText(driver, By.Id("oldSelectMenu"), "Green");
            driver.Quit();
        }

        [Test]
        public void MultiDropdownTest()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demoqa.com/select-menu");
            var multiSelect = new SelectElement(driver.FindElement(By.Id("cars")));
            multiSelect.SelectByValue("opel");
            multiSelect.SelectByValue("volvo");
            var selectedOptions = multiSelect.AllSelectedOptions;
            foreach (IWebElement selectedOption in selectedOptions)
            {
                Console.Write(selectedOption.Text + " ");
            }
            driver.Quit();
        }
        [Test]
        public void MultiDropdownCustomMethod()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demoqa.com/select-menu");
            SeleniumCustomMethods.DropDrownByValue(driver, By.Id("cars"), ["audi", "saab"]);
            driver.Quit();
        }
        [Test]
        public void MultiDropdownElements()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demoqa.com/select-menu");
            SeleniumCustomMethods.MultiSelectByValues(driver, By.Id("cars"), ["audi", "saab"]);
            var getSelectedOptions = SeleniumCustomMethods.GetAllSelectedLists(driver, By.Id("cars"));
            getSelectedOptions.ForEach(Console.WriteLine);
            driver.Quit();
        }
    }
}