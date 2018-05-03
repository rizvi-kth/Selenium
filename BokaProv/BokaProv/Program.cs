using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace BokaProv
{
    class Program
    {

       

        static void Main(string[] args)
        {

            var _testRun = new TestRunner();
            _testRun.run();

            Console.WriteLine("Boka prov!");
            Console.ReadLine();


        }
    }

    public class TestRunner
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        public TestRunner()
        {

            driver = new ChromeDriver(@"C:\Users\SERIHAS\source\repos\SeleniumCmder\BokaProv\BokaProv\bin\Debug\netcoreapp2.0");
            baseURL = "https://www.katalon.com/";
            verificationErrors = new StringBuilder();


        }

        internal void run()
        {

            driver.Navigate().GoToUrl("https://fp.trafikverket.se/Boka/#/information");
            driver.FindElement(By.XPath("(//a[contains(text(),'Start')])[2]")).Click();
            driver.FindElement(By.XPath("//h1/i")).Click();
            driver.FindElement(By.XPath("(//a[contains(@href, 'javascript:void(0)')])[8]")).Click();
            driver.FindElement(By.Id("id-control-searchText")).Click();
            driver.FindElement(By.Id("id-control-searchText")).Clear();
            driver.FindElement(By.Id("id-control-searchText")).SendKeys("Ja");
            driver.FindElement(By.LinkText("Jakobsberg")).Click();
            driver.FindElement(By.Id("language-select")).Click();
            //new SelectElement(driver.FindElement(By.Id("language-select"))).SelectByText("Engelska");
            driver.FindElement(By.Id("language-select")).Click();
            driver.FindElement(By.Id("vehicle-select")).Click();
            //new SelectElement(driver.FindElement(By.Id("vehicle-select"))).SelectByText("Ja, automat");
            driver.FindElement(By.Id("vehicle-select")).Click();
            // Warning: verifyTextPresent may require manual changes
            //try
            //{
            //    Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*Lediga provtider[\\s\\S]*$"));
            //}
            //catch (AssertionException e)
            //{
            //    verificationErrors.Append(e.Message);
            //}
            String varTestDate = driver.FindElement(By.XPath("//html/body/div[1]/section[5]/div/div[9]/div[1]/div/div/div[1]/div[2]/div[1]")).Text;
            Console.WriteLine(varTestDate);
            //try
            //{
            //    Assert.AreEqual(varTestDate, driver.FindElement(By.XPath("//html/body/div[1]/section[5]/div/div[9]/div[1]/div/div/div[1]/div[2]/div[1]")).Text);
            //}
            //catch (AssertionException e)
            //{
            //    verificationErrors.Append(e.Message);
            //}
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | //html/body/div[1]/section[5]/div/div[9]/div[1]/div/div/div[1]/div[2]/div[1] | ]]
            // ERROR: Caught exception [ERROR: Unsupported command [getEval | storedVars['varTestDate'].match(/^[^\s]+/) | ]]
            //Console.WriteLine(varDate);
            String varLastSeenDate = "2018-11-14";
            Console.WriteLine(varLastSeenDate);
            // ERROR: Caught exception [Error: locator strategy either id or name must be specified explicitly.]
        }
    }
}
