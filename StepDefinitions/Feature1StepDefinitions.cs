using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowProject1.PageObjects;
using SpecFlowProject1.Utilities;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class Feature1StepDefinitions : Base
    {
        private IWebDriver driver;
        //  private readonly PageObject P0 = new PageObject(driver);
        public Feature1StepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"Open the browser")]
        public void GivenOpenTheBrowser()
        {
            // throw new NotImplementedException();

        }
        [When(@"Navigate to '([^']*)'")]
        public void WhenNavigateTo(string URL)
        {

            PageObject PO = new PageObject(driver);
            Thread.Sleep(1000);
            driver.Navigate().GoToUrl(URL);

            if (PO.Cookies().Displayed)
            {
                PO.AcceptCookies().Click();
                Thread.Sleep(2000);
            }
        }
        [Then(@"Enter partial text '([^']*)' from FROM station in from field")]
        public void ThenEnterPartialTextFromFROMStationInFromField(string PartialText_FromStation)
        {
            Thread.Sleep(1000);
            PageObject PO = new PageObject(driver);

            PO.FromLocation().SendKeys(PartialText_FromStation);
            Thread.Sleep(1000);
        }


        /*  [Then(@"Enter partial text from FROM station in from field")]
          public void ThenEnterPartialTextFromFROMStationInFromField()
          {
              Thread.Sleep(1000);
              PageObject PO = new PageObject(driver);

              PO.FromLocation().SendKeys("Lei");
              Thread.Sleep(1000);
          }*/
        [Then(@"Select '([^']*)' from the dropdown")]
        public void ThenSelectFromTheDropdown(string ToStation)
        {
            PageObject PO = new PageObject(driver);
            foreach (var station in PO.FromList())
            {
                if (station.Text.Contains(ToStation))
                {
                    station.Click();
                    break;
                }
            }
        }


        /*  [Then(@"Select Leicester Square Underground Station from the dropdown")]
          public void ThenSelectLeicesterSquareUndergroundStationFromTheDropdown()
          {
              PageObject PO = new PageObject(driver);
              foreach (var station in PO.FromList())
              {
                  if (station.Text.Contains("Leicester Square Underground Station"))
                  {
                      station.Click();
                      break;
                  }
              }
          }*/
        [Then(@"Enter partial text '([^']*)' from TO station in To field")]
        public void ThenEnterPartialTextFromTOStationInToField(string PartialText_ToStation)
        {
            PageObject PO = new PageObject(driver);
            PO.ToLocation().SendKeys(PartialText_ToStation);
            Thread.Sleep(1000);
        }

        /*[Then(@"Enter partial text from TO station To station in To field")]
        public void ThenEnterPartialTextFromTOStationToStationInToField()
        {
            PageObject PO = new PageObject(driver);
            PO.ToLocation().SendKeys("Cov");
            Thread.Sleep(1000);
        }
        */
        [Then(@"Select '([^']*)' from the dropdown\.")]
        public void ThenSelectFromTheDropdown_(string ToStation)
        {
            PageObject PO = new PageObject(driver);
            foreach (var station in PO.FromList())
            {
                if (station.Text.Contains(ToStation))
                {
                    station.Click();
                    break;
                }
            }
        }

        /* [Then(@"Select Covent Garden Underground Station from the dropdown")]
         public void ThenSelectCoventGardenUndergroundStationFromTheDropdown()
         {
             PageObject PO = new PageObject(driver);
             foreach (var station in PO.FromList())
             {
                 if (station.Text.Contains("Covent Garden Underground Station"))
                 {
                     station.Click();
                     break;
                 }
             }
         }*/

        [When(@"Click on Plan Journey button")]
        public void WhenClickOnPlanJourneyButton()
        {

            PageObject PO = new PageObject(driver);
            PO.PlanJourneyButton().Click();
        }

        [Then(@"the journey details should be displayed")]
        public void ThenTheJourneyDetailsShouldBeDisplayed()
        {
            PageObject PO = new PageObject(driver);
            string xpath = PO.XPATH_CyclinDuration();
            //ExplicitWaitByXpath(PO.XPATH_CyclinDuration());
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(xpath)));

            var cycleJourneyTimeElement = PO.CycleJourneyTimeBeforeUpdateJourney();
            var walkJourneyTimeElement = PO.WalkJourneyTImeBeforeUpdateJourney();

            if (cycleJourneyTimeElement == null || walkJourneyTimeElement == null)
            {
                throw new InvalidOperationException("One or more required elements are not found on the page.");
            }

            if (PO.CycleJourneyTimeBeforeUpdateJourney().Displayed && PO.WalkJourneyTImeBeforeUpdateJourney().Displayed)
            {
                Console.WriteLine("Updated Journey Details Displayed");
                string cycle_duration = PO.CycleJourneyTimeBeforeUpdateJourney().Text;

                TestContext.Progress.WriteLine("Cycling duration is " + cycle_duration);

                string walk_duration = PO.WalkJourneyTImeBeforeUpdateJourney().Text;

                TestContext.Progress.WriteLine("Walking duration is " + walk_duration);
            }
        }

        [Given(@"We are on Journey Results page")]
        public void GivenWeAreOnJourneyResultsPage()
        {

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [Then(@"Click on Edit Preferences button")]
        public void ThenClickOnEditPreferencesButton()
        {
            PageObject PO = new PageObject(driver);
            PO.EditPreferencesButton().Click();
        }

        [Then(@"Select Routes with least walking")]
        public void ThenSelectRoutesWithLeastWalking()
        {
            PageObject PO = new PageObject(driver);
            PO.RoutesWithLeastWalkingButton().Click();
            Thread.Sleep(1000);
        }

        [When(@"Click on Update Journey Button")]
        public void WhenClickOnUpdateJourneyButton()
        {
            PageObject PO = new PageObject(driver);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement updateJourneyButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(PO.UpdateJourneyButton()));
            //ScrollToElementUsingXpath(PO.UpdateJourneyButton());
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", PO.UpdateJourneyButton());
            Thread.Sleep(1000);
            PO.UpdateJourneyButton().Click();
        }

        [Then(@"Updated journey Details should be present")]
        public void ThenUpdatedJourneyDetailsShouldBePresent()
        {
            PageObject PO = new PageObject(driver);
            //ExplicitWaitByXpath(PO.XPATH_UpdatedJourneyTime());
            string xpath = PO.XPATH_UpdatedJourneyTime();
            //ExplicitWaitByXpath(PO.XPATH_CyclinDuration());
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
            string updatedJourneyDuration = PO.UpdatedJourneyDuration().Text;

            int int_total_duration = GetIntValueFromTimeInMinutes(updatedJourneyDuration);

            TestContext.Progress.WriteLine(updatedJourneyDuration);

            int detailed_journey_time = 0;
            foreach (var time in PO.DetailedJourneyTimes())
            {

                string det_jour_time = time.Text;
                detailed_journey_time = detailed_journey_time + GetIntValueFromTimeInMinutes(det_jour_time);
            }
            TestContext.Progress.WriteLine("Consolidated journey time is " + detailed_journey_time + " mins");

            if (int_total_duration == detailed_journey_time)
            {
                TestContext.Progress.WriteLine("Validated Successfully!");
            }
        }

        [Given(@"Updated journey details are displayed")]
        public void GivenUpdatedJourneyDetailsAreDisplayed()
        {
            PageObject PO = new PageObject(driver);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [Then(@"Click on View Details button")]
        public void ThenClickOnViewDetailsButton()
        {
            PageObject PO = new PageObject(driver);
            PO.ViewDetailsButton().Click();
        }

        [When(@"Details are displayed")]
        public void WhenDetailsAreDisplayed()
        {
            PageObject PO = new PageObject(driver);
            Thread.Sleep(1000);
            if (PO.UpdatedJourneyDetails().Displayed)
            {
                TestContext.Progress.WriteLine("Updated Journey Details are displayed.");
            }

        }
        [Then(@"Verify steps to be followed at '([^']*)'")]
        public void ThenVerifyStepsToBeFollowedAt(string station_name)
        {
            PageObject PO = new PageObject(driver);
            // string station_input = station_name;
            foreach (var station in PO.JourneyDetailSteps(station_name))
            {
                //Console.WriteLine(station.Text);
                if (station.Text.Equals(station_name))
                {

                    TestContext.Progress.WriteLine("Steps to follow at " + station_name + ": ");
                    foreach (var step in PO.StepsToDo(station_name))
                    {
                        TestContext.Progress.WriteLine(step.GetAttribute("aria-label"));
                    }

                }
            }
        }
    }
}
