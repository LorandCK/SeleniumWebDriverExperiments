using OpenQA.Selenium;

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

        IWebElement LnkResult => driver.FindElement(By.LinkText("Mașini electrice, energie solară și curată | Tesla România"));

        public void LoginClick()
        {
            LoginLink.ClickElement();
        }

        public void SearchFieldInput(string searchTerm)
        {

            SearchField.EnterText(searchTerm);
            SearchField.SubmitElement();

        }
        public bool IsLoggedIn()
        {
            return LnkResult.Displayed;
        }
    }
}
