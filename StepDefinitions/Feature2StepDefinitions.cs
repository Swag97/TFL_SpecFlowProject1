using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowProject1.PageObjects;
using TechTalk.SpecFlow;
using static OpenQA.Selenium.BiDi.Modules.BrowsingContext.Locator;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class Feature2StepDefinitions
    {
        private IWebDriver driver;
        public Feature2StepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
        }
        [Given(@"Navigate to '([^']*)'")]
        public void GivenNavigateTo(string URL)
        {
            PageObject PO = new PageObject(driver);
            driver.Navigate().GoToUrl(URL);
            Thread.Sleep(1000);
            if (PO.Cookies().Displayed)
            {
                PO.AcceptCookies().Click();
                Thread.Sleep(2000);
            }
        }


        [When(@"From and To station fields are displayed")]
        public void WhenFromAndToStationFieldsAreDisplayed()
        {
            PageObject PO = new PageObject(driver);
            if(PO.FromLocation().Displayed && PO.ToLocation().Displayed)
            {
                TestContext.Progress.WriteLine("From and To station fields are displayed.");
            }
        }
        [Then(@"Enter Invalid From station - '([^']*)'")]
        public void ThenEnterInvalidFromStation_(string InvalidStation)
        {
            PageObject PO = new PageObject(driver);
            PO.FromLocation().SendKeys(InvalidStation);
        }

        [Then(@"Enter Invalid To station - '([^']*)'")]
        public void ThenEnterInvalidToStation_(string InvalidTo)
        {
            PageObject PO = new PageObject(driver);
            PO.ToLocation().SendKeys(InvalidTo);
        }

       
        [Then(@"CLick on Plan Journey Button")]
        public void ThenCLickOnPlanJourneyButton()
        {
            PageObject PO = new PageObject(driver);
            PO.PlanJourneyButton().Click();
            string xpath = PO.ValidationErrorXpath();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
        }


        [Then(@"Error message should be Displayed")]
        public void ThenErrorMessageShouldBeDisplayed()
        {
            PageObject PO = new PageObject(driver);
            if (PO.ValidationErrorForInvalidInputs().Text.Equals("Sorry, we can't find a journey matching your criteria"))
            {

                TestContext.Progress.WriteLine("ERROR : " + PO.ValidationErrorForInvalidInputs().Text);
            }
            Thread.Sleep(1000);
        }

    }
}
