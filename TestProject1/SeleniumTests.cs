using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TestProject1
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
            IWebElement webElement = driver.FindElement(By.Id("L2AGLb"));
            webElement.Click();
            IWebElement webElement1 = driver.FindElement(By.Name("q"));
            webElement1.SendKeys("apple");
            webElement1.SendKeys(Keys.Return);
            driver.Quit();
        }

        [Test] 
        public void ShortenedLogin()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.com/");
            driver.FindElement(By.Id("L2AGLb")).Click();
            driver.FindElement(By.Name("q")).SendKeys("samsung");
            driver.FindElement(By.Name("q")).SendKeys(Keys.Return);
            driver.Quit();
        }

        [Test]
        public void CustomMethodLogin()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.com/");
            SeleniumCustomMethods.Click(driver, By.Id("L2AGLb"));
            SeleniumCustomMethods.EnterTextAndReturn(driver, By.Name("q"), "applestore");
            driver.Quit();
        }

        [Test]
        public void DropDownTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demoqa.com/select-menu");
            SelectElement selectElement = new SelectElement(driver.FindElement(By.Id("oldSelectMenu")));
            selectElement.SelectByText("Blue");
            driver.Quit();
        }

        [Test]
        public void DropDownCustomMethod()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demoqa.com/select-menu");
            SeleniumCustomMethods.DropDrownByText(driver, By.Id("oldSelectMenu"), "Green");
            driver.Quit();
        }

        [Test]
        public void MultiDropdownTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demoqa.com/select-menu");
            SelectElement multiSelect = new SelectElement(driver.FindElement(By.Id("cars")));
            multiSelect.SelectByValue("opel");
            multiSelect.SelectByValue("volvo");
            IList<IWebElement> selectedOptions = multiSelect.AllSelectedOptions;
            foreach (IWebElement selectedOption in selectedOptions)
            {
                Console.Write(selectedOption.Text+" ");
            }
            driver.Quit();
        }
        [Test]
        public void MultiDropdownCustomMethod()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demoqa.com/select-menu");
            SeleniumCustomMethods.DropDrownByValue(driver, By.Id("cars"), ["audi", "saab"]);
            driver.Quit();
        }

    }
}