using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1.Utility
{
    public class ExtentReport
    {
        public static ExtentReports _extentReports;
        public static ExtentTest _feature;
        public static ExtentTest _scenario;

        public static String dir = AppDomain.CurrentDomain.BaseDirectory;
        public static String testResultPath = dir.Replace("bin\\Debug\\net6.0", "TestResults");

        public static void extentReportInit()
        {
            var htmlReporter = new ExtentHtmlReporter(testResultPath);
            htmlReporter.Config.ReportName = "Automation test report";
            htmlReporter.Config.DocumentTitle = "Automation test report";
            htmlReporter.Config.Theme = Theme.Dark;
            htmlReporter.Start();

            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(htmlReporter);
            _extentReports.AddSystemInfo("Application", "Flipkart");
            _extentReports.AddSystemInfo("Browser", "Chrome");
            _extentReports.AddSystemInfo("OS", "Windows");
        }

        public static void extentReportTeardown()
        {
            _extentReports.Flush();
        }

        public String addScreenshot(IWebDriver driver, ScenarioContext scenarioContext) 
        {
            ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;
            Screenshot screenshot = takesScreenshot.GetScreenshot();
            String screenshotPath = Path.Combine(testResultPath, scenarioContext.ScenarioInfo.Title + ".png");
            screenshot.SaveAsFile(screenshotPath,ScreenshotImageFormat.Png);
            return screenshotPath;
        }
    }
}
