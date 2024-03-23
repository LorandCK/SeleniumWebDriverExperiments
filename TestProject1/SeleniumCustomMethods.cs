using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebDriver
{
    public class SeleniumCustomMethods
    {
        public static void Click(IWebDriver driver, By locator)
        {
            driver.FindElement(locator).Click();
        }
        public static void EnterText(IWebDriver driver, By locator, string text)
        {
            driver.FindElement(locator).Clear();
            driver.FindElement(locator).SendKeys(text);
        }
        public static void EnterTextAndReturn(IWebDriver driver, By locator, string text)
        {
            driver.FindElement(locator).Clear();
            driver.FindElement(locator).SendKeys(text);
            driver.FindElement(locator).SendKeys(Keys.Return);
        }
        public static void DropDrownByText(IWebDriver driver, By locator, string text)
        {
            SelectElement selectElement = new SelectElement(driver.FindElement(locator));
            selectElement.SelectByText(text);
        }
        public static void DropDrownByValue(IWebDriver driver, By locator, string[]value)        
        {
            SelectElement multiSelect = new SelectElement(driver.FindElement(locator));
            for (int i = 0; i < value.Length; i++)
            {
                Console.WriteLine("Array Element: " + value[i]);
                multiSelect.SelectByValue(value[i]);
            }
        }
    }
}
