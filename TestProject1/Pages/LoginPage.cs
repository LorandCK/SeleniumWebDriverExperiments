using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebDriver.Pages
{
    internal class LoginPage
    {
        private readonly IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        IWebElement LoginLink
        {
            get
            {
                return driver.FindElement(By.Id("L2AGLb"));
            }
        }

        IWebElement SearchField => driver.FindElement(By.Name("q"));

        public void LoginClick()
        {
            SeleniumCustomMethods.Click(LoginLink);
        }

        public void SearchFieldInput(string searchTerm)
        {
            SearchField.SendKeys(searchTerm);
            SeleniumCustomMethods.Submit(SearchField);
        }
    }
}
