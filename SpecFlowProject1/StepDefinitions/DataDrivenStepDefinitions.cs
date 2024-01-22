using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public sealed class DataDrivenStepDefinitions
    {
        private IWebDriver driver;

        public DataDrivenStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
        }

        [When(@"user search with (.*)")]
        public void WhenUserSearchWithText(String searchText)
        {
            IWebElement searchbox = driver.FindElement(By.XPath("//input[@name='q']"));
            searchbox.SendKeys(searchText);
            searchbox.SendKeys(Keys.Enter);

            Thread.Sleep(5000);
        }

        [Then(@"result displays (.*)")]
        public void ThenResultDisplaysText(String searchText)
        {
            String title = driver.Title;
            Console.WriteLine(title);
            Assert.IsTrue(title.Contains(searchText));
        }

        



    }

    
}