using System;
using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowProject1.PageObjects;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class Feature3StepDefinitions
    {
        private IWebDriver driver;
        public Feature3StepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
        }
        [Given(@"we are on PLan Journey page")]
        public void GivenWeAreOnPLanJourneyPage()
        {
            PageObject PO = new PageObject(driver);
            Thread.Sleep(1000);
            driver.Url = "https://tfl.gov.uk/plan-a-journey";
            if (PO.Cookies().Displayed)
            {
                PO.AcceptCookies().Click();
                Thread.Sleep(2000);
            }
        }

        [When(@"Plan dourney page is displayed")]
        public void WhenPlanDourneyPageIsDisplayed()
        {

            PageObject PO = new PageObject(driver);
            if (PO.FromLocation().Displayed && PO.ToLocation().Displayed)
            {
                TestContext.Progress.WriteLine("From and To station fields are displayed.");
                Thread.Sleep(1000);
            }
        }


         [Then(@"leave FROM station blank")]
        public void ThenLeaveFROMStationBlank()
        {
            
        }

     
        [Then(@"leave TO station blank")]
        public void ThenLeaveTOStationBlank()
        {
            
        }
        [Then(@"CLick on Plan Journey button")]
        public void ThenCLickOnPlanJourneyButton()
        {
            PageObject PO = new PageObject(driver);
            PO.PlanJourneyButton().Click();
        }

        [Then(@"Error message should be displayed")]
        public void ThenErrorMessageShouldBeDisplayed()
        {
            
            PageObject PO = new PageObject(driver);
            if (PO.InputFromError().Displayed && PO.InputToError().Displayed )
            {
                TestContext.Progress.WriteLine("Error : " + PO.InputFromError().Text);
                TestContext.Progress.WriteLine("Error : " + PO.InputToError().Text);
                TestContext.Progress.WriteLine("Therefore, unable to plan a journey!");
            }
        }
    }
}
