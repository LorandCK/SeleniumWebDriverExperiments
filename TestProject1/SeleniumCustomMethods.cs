using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumWebDriver
{
    public static class SeleniumCustomMethods
    {
        public static void ClickElement(this IWebElement locator)
        {
            locator.Click();
        }

        public static void SubmitElement(this IWebElement locator)
        {
            locator.Submit();
        }

        public static void EnterText(this IWebElement locator, string text)
        {
            locator.Clear();
            locator.SendKeys(text);
        }

        public static void EnterTextAndReturn(IWebDriver driver, By locator, string text)
        {
            driver.FindElement(locator).Clear();
            driver.FindElement(locator).SendKeys(text);
            driver.FindElement(locator).SendKeys(Keys.Return);
        }

        public static void DropDrownByText(IWebDriver driver, By locator, string text)
        {
            var selectElement = new SelectElement(driver.FindElement(locator));
            selectElement.SelectByText(text);
        }

        public static void DropDrownByValue(IWebDriver driver, By locator, string[] value)
        {
            var multiSelect = new SelectElement(driver.FindElement(locator));
            for (int i = 0; i < value.Length; i++)
            {
                Console.WriteLine("Selected values: " + value[i]);
                multiSelect.SelectByValue(value[i]);
            }
        }

        public static void MultiSelectByValues(IWebDriver driver, By locator, string[] values)
        {
            var multiSelect = new SelectElement(driver.FindElement(locator));
            foreach (var value in values)
            {
                multiSelect.SelectByValue(value);
            }
        }

        public static List<string> GetAllSelectedLists(IWebDriver driver, By locator)
        {
            var options = new List<string>();
            var multiSelect = new SelectElement(driver.FindElement(locator));
            var selectedOption = multiSelect.AllSelectedOptions;
            foreach (var option in selectedOption)
            {
                options.Add(option.Text);
            }
            return options;
        }
    }
}
