using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlowProject1.Utility;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.Hooks
{
    [Binding]
    public sealed class Hooks: ExtentReport
    {
        private readonly IObjectContainer _container;
        public Hooks(IObjectContainer container) { 
            _container = container;
        
        }
        [BeforeTestRun] 
        public static void BeforeTestRun() 
        {
            extentReportInit();
        }

        [AfterTestRun] 
        public static void AfterTestRun()
        {
            extentReportTeardown();
        }

        [BeforeFeature] 
        public static void BeforeFeature(FeatureContext featureContext) 
        {
            _feature = _extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [BeforeScenario("@flipkartSearchTest")]
        public void BeforeScenarioWithTag()
        {
            Console.WriteLine("inside tagged hook");
        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario(ScenarioContext scenarioContext)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            _container.RegisterInstanceAs<IWebDriver>(driver);

            _scenario = _feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
        }

        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext) 
        {
            String stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            String stepName = scenarioContext.StepContext.StepInfo.Text;
            var driver = _container.Resolve<IWebDriver>();

            //if test passes
            if (scenarioContext.TestError == null)
            {
                if(stepType == "Given")
                {
                    _scenario.CreateNode<Given>(stepName);
                    
                }
                else if (stepType == "When")
                {
                    _scenario.CreateNode<When>(stepName);

                }
                else if (stepType == "Then")
                {
                    _scenario.CreateNode<Then>(stepName);

                }
            }

            //if test fails
            if (scenarioContext.TestError != null)
            {

                
                if (stepType == "Given")
                {
                    ExtentTest test = _scenario.CreateNode<Given>(stepName);
                    test.Fail(scenarioContext.TestError.Message);
                    test.AddScreenCaptureFromPath(addScreenshot(driver, scenarioContext));

                }
                else if (stepType == "When")
                {
                    ExtentTest test = _scenario.CreateNode<When>(stepName);
                    test.Fail(scenarioContext.TestError.Message);
                    test.AddScreenCaptureFromPath(addScreenshot(driver, scenarioContext));

                }
                else if (stepType == "Then")
                {
                    ExtentTest test = _scenario.CreateNode<Then>(stepName);
                    test.Fail(scenarioContext.TestError.Message);
                    test.AddScreenCaptureFromPath(addScreenshot(driver, scenarioContext));

                }
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var driver = _container.Resolve<IWebDriver>();

            if(driver != null)
            {
                driver.Quit();
                Thread.Sleep(5000);
            }
        }
    }
}