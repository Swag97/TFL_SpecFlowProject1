using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowProject1.PageObjects;
using static OpenQA.Selenium.BiDi.Modules.BrowsingContext.Locator;

namespace SpecFlowProject1.Utilities
{
    public  class Base
    {
        public IWebDriver driver;
        public void ExplicitWaitByXpath(string Xpath)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
           // wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            }
            catch (WebDriverTimeoutException e)
            {
                throw new InvalidOperationException($"Element not found within timeout: {Xpath}", e);
            }
        }

        public void ScrollToElementUsingXpath(IWebElement element)
        {

            /*   IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
               js.ExecuteScript("arguments[0].scrollIntoView(true);", Element);*/
        
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element), "Element is not initialized.");
            }
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        
        }
        public int GetIntValueFromTimeInMinutes(string Time)
        {
            Match match = Regex.Match(Time, @"(\d+)\s*min");
            int IntValue = int.Parse(match.Groups[1].Value);

            return IntValue;
        }
    }
}
