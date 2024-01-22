using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public sealed class FlipkartStepDefinitions
    {
        private IWebDriver driver;

        public FlipkartStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
        }
        

        [Given(@"user is on landing page")]
        public void GivenUserIsOnLandingPage()
        {
            
            driver.Url = "https://www.flipkart.com/";
            Thread.Sleep(5000);
        }

        [When(@"user search with a keyword")]
        public void WhenUserSearchWithAKeyword()
        {
            IWebElement searchbox = driver.FindElement(By.XPath("//input[@name='q']"));
            searchbox.SendKeys("apple");
            searchbox.SendKeys(Keys.Enter);

            Thread.Sleep(5000);
        }

        [Then(@"result is shown")]
        public void ThenResultIsShown()
        {
            String title = driver.Title;
            Console.WriteLine(title);
            Assert.IsTrue(title.Contains("Apple"));
        }
        [When(@"user enters phone number")]
        public void WhenUserEntersPhoneNumber()
        {
            IWebElement phoneNumberInput = driver.FindElement(By.XPath("//div[@class='_3wFoIb row']//input[@type='text']"));
            phoneNumberInput.SendKeys("123456789");
            Thread.Sleep(5000);
            
        }

        [Then(@"user requests otp")]
        public void ThenUserRequestsOtp()
        {
            IWebElement requestButton = driver.FindElement(By.XPath("//div[@class='_3wFoIb row']//button[contains(text(),'OTP')]"));
            requestButton.Click();
            Thread.Sleep(5000);
            Assert.IsTrue(false);
        }

    }
}