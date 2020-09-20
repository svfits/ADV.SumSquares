using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Text;

namespace ADV.SumSquares.IntegrationTest
{
    [TestClass]
    public class IntagrationTest
    {
        private static IWebDriver driver;
        private StringBuilder verificationErrors;
        private static string baseURL;
        private bool acceptNextAlert = true;

        [ClassInitialize]
        public static void InitializeClass(TestContext testContext)
        {
            driver = new ChromeDriver();
            baseURL = "https://www.google.com/";
        }

        [ClassCleanup]
        public static void CleanupClass()
        {
            try
            {
                //driver.Quit();// quit does not close the window
                driver.Close();
                driver.Dispose();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        [TestInitialize]
        [DeploymentItem("chromedriver.exe")]
        public void InitializeTest()
        {
            verificationErrors = new StringBuilder();
        }

        [TestCleanup]
        public void CleanupTest()
        {
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [TestMethod]
        public void TheUntitledTestCaseTest()
        {
            driver.Navigate().GoToUrl("http://localhost:5000/");
            driver.FindElement(By.Id("Number0")).Click();
            driver.FindElement(By.XPath("//body")).Click();
            driver.FindElement(By.Id("Number0")).Clear();
            driver.FindElement(By.Id("Number0")).SendKeys("12");
            driver.FindElement(By.Id("Number1")).Clear();
            driver.FindElement(By.Id("Number1")).SendKeys("12");
            driver.FindElement(By.XPath("//main/div/div")).Click();
            driver.FindElement(By.Id("Number2")).Clear();
            driver.FindElement(By.Id("Number2")).SendKeys("12");
            driver.FindElement(By.XPath("//main/div/div")).Click();
            driver.FindElement(By.Id("Number3")).Clear();
            driver.FindElement(By.Id("Number3")).SendKeys("12");
            driver.FindElement(By.XPath("//main/div/div")).Click();
            driver.FindElement(By.Id("Number4")).Clear();
            driver.FindElement(By.Id("Number4")).SendKeys("12");
            driver.FindElement(By.Id("execute")).Click();
            driver.FindElement(By.Id("Number0")).Click();
            driver.FindElement(By.Id("Number0")).Clear();
            driver.FindElement(By.Id("Number0")).SendKeys("45");
            driver.FindElement(By.Id("Number1")).Click();
            driver.FindElement(By.Id("Number1")).Clear();
            driver.FindElement(By.Id("Number1")).SendKeys("45");
            driver.FindElement(By.Id("Number2")).Click();
            driver.FindElement(By.XPath("//body")).Click();
            driver.FindElement(By.Id("Number1")).Clear();
            driver.FindElement(By.Id("Number1")).SendKeys("46");
            driver.FindElement(By.Id("Number2")).Click();
            driver.FindElement(By.Id("Number2")).Clear();
            driver.FindElement(By.Id("Number2")).SendKeys("47");
            driver.FindElement(By.XPath("//main/div/div")).Click();
            driver.FindElement(By.Id("Number3")).Clear();
            driver.FindElement(By.Id("Number3")).SendKeys("48");
            driver.FindElement(By.XPath("//main/div/div")).Click();
            driver.FindElement(By.Id("Number4")).Clear();
            driver.FindElement(By.Id("Number4")).SendKeys("49");
            driver.FindElement(By.XPath("//main/div")).Click();
            driver.FindElement(By.Id("execute")).Click();
            driver.FindElement(By.XPath("//main/div/div")).Click();
            driver.FindElement(By.Id("Number4")).Clear();
            driver.FindElement(By.Id("Number4")).SendKeys("1");
            driver.FindElement(By.XPath("//main/div/div")).Click();
            driver.FindElement(By.Id("Number3")).Clear();
            driver.FindElement(By.Id("Number3")).SendKeys("2");
            driver.FindElement(By.XPath("//body")).Click();
            driver.FindElement(By.Id("Number2")).Clear();
            driver.FindElement(By.Id("Number2")).SendKeys("3");
            driver.FindElement(By.XPath("//main/div/div")).Click();
            driver.FindElement(By.Id("Number1")).Clear();
            driver.FindElement(By.Id("Number1")).SendKeys("4");
            driver.FindElement(By.XPath("//body")).Click();
            driver.FindElement(By.Id("Number0")).Clear();
            driver.FindElement(By.Id("Number0")).SendKeys("5");
            driver.FindElement(By.XPath("//main/div")).Click();
            driver.FindElement(By.Id("execute")).Click();
            driver.FindElement(By.Id("execute")).Click();
            driver.FindElement(By.Id("Number4")).Click();
            driver.FindElement(By.Id("Number4")).Click();
            
            driver.FindElement(By.Id("Number4")).Click();
            driver.FindElement(By.Id("Number4")).Clear();
            driver.FindElement(By.Id("Number4")).SendKeys("56");
            driver.FindElement(By.Id("execute")).Click();
            driver.FindElement(By.Id("Number2")).Click();
            driver.FindElement(By.Id("Number2")).Clear();
            driver.FindElement(By.Id("Number2")).SendKeys("3666");
            driver.FindElement(By.Id("Number3")).Click();
            driver.FindElement(By.Id("Number3")).Clear();
            driver.FindElement(By.Id("Number3")).SendKeys("26666");
            driver.FindElement(By.Id("Number1")).Click();
            driver.FindElement(By.Id("Number1")).Clear();
            driver.FindElement(By.Id("Number1")).SendKeys("46666");
            driver.FindElement(By.Id("Number0")).Click();
            driver.FindElement(By.Id("Number0")).Clear();
            driver.FindElement(By.Id("Number0")).SendKeys("55555");
            driver.FindElement(By.XPath("//main/div")).Click();
            driver.FindElement(By.Id("execute")).Click();
            driver.FindElement(By.Id("Number0")).Click();
            driver.FindElement(By.XPath("//main/div/div")).Click();
            driver.FindElement(By.Id("Number0")).Clear();
            driver.FindElement(By.Id("Number0")).SendKeys("20");
            driver.FindElement(By.XPath("//body")).Click();
            driver.FindElement(By.Id("Number1")).Clear();
            driver.FindElement(By.Id("Number1")).SendKeys("21");
            driver.FindElement(By.Id("Number2")).Click();
            driver.FindElement(By.XPath("//body")).Click();
            
            driver.FindElement(By.Id("Number2")).Clear();
            driver.FindElement(By.Id("Number2")).SendKeys("22");
            driver.FindElement(By.XPath("//main/div/div")).Click();
            driver.FindElement(By.Id("Number3")).Clear();
            driver.FindElement(By.Id("Number3")).SendKeys("23");
            driver.FindElement(By.XPath("//body")).Click();
            driver.FindElement(By.Id("Number4")).Clear();
            driver.FindElement(By.Id("Number4")).SendKeys("24");
            driver.FindElement(By.XPath("//main/div")).Click();
            driver.FindElement(By.Id("execute")).Click();
            driver.FindElement(By.XPath("//body")).Click();
            driver.FindElement(By.Id("Number0")).Clear();
            driver.FindElement(By.Id("Number0")).SendKeys("1");
            driver.FindElement(By.XPath("//body")).Click();
            driver.FindElement(By.Id("Number1")).Clear();
            driver.FindElement(By.Id("Number1")).SendKeys("2");
            driver.FindElement(By.XPath("//body")).Click();
            driver.FindElement(By.Id("Number2")).Clear();
            driver.FindElement(By.Id("Number2")).SendKeys("3");
            driver.FindElement(By.XPath("//body")).Click();
            driver.FindElement(By.Id("Number3")).Clear();
            driver.FindElement(By.Id("Number3")).SendKeys("4");
            driver.FindElement(By.XPath("//body")).Click();
            driver.FindElement(By.Id("Number4")).Clear();
            driver.FindElement(By.Id("Number4")).SendKeys("4");
            driver.FindElement(By.XPath("//main/div")).Click();
            driver.FindElement(By.Id("execute")).Click();            
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
