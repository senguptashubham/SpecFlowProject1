using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public sealed class DataTableDrivenStepDefinitions
    {
        private IWebDriver driver;
        private ArrayList results = new ArrayList();

        public DataTableDrivenStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
        }

        [When(@"user searches text from data table")]
        public void WhenUserSearchesTextFromDataTable(Table table)
        {
            var searchContext = table.CreateSet<SearchTestData>();

            foreach(var item in searchContext) 
            {
                IWebElement searchbox = driver.FindElement(By.XPath("//input[@name='q']"));
                searchbox.Clear();
                searchbox.SendKeys(item.searchKey);
                searchbox.SendKeys(Keys.Enter);

                Thread.Sleep(5000);
                String title = driver.Title;
                results.Add(title.Contains(item.searchKey));
            }
        }

        [Then(@"text should be displayed in title")]
        public void ThenTextShouldBeDisplayedInTitle()
        {
            foreach(Boolean result in  results) 
            {
                if(!result)
                {
                    Assert.IsTrue(false);
                }
            }
            Assert.IsTrue(true);
        }



    }

    public class SearchTestData
    {
        public String searchKey { get; set; }
    }
}