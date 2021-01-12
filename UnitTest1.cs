using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class UntitledTestCase
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://www.google.com/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }


        [Test]
        public void PrviTest()
        {
            driver.Navigate().GoToUrl("https://demo.opencart.com/");
            Thread.Sleep(1000);
            driver.Navigate().GoToUrl("https://demo.opencart.com/index.php?route=product/category&path=20_27");
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//div[@id='content']/div[2]/div/div/div[2]/div[2]/button/span")).Click();
            Thread.Sleep(1000);
            driver.Navigate().GoToUrl("https://demo.opencart.com/index.php?route=checkout/cart");
            Thread.Sleep(1000);
            driver.Navigate().GoToUrl("https://demo.opencart.com/index.php?route=checkout/checkout");
            Thread.Sleep(1000);
        }

        [Test]
        public void DrugiTest()
        {
            driver.Navigate().GoToUrl("https://demo.opencart.com/");
            driver.FindElement(By.XPath("//div[@id='top-links']/ul/li[2]/a/span[2]")).Click();
            driver.FindElement(By.LinkText("Login")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("input-email")).Click();
            driver.FindElement(By.Id("input-email")).Clear();
            driver.FindElement(By.Id("input-email")).SendKeys("ivanparadzik4@gmail.com");
            driver.FindElement(By.Id("input-password")).Click();
            driver.FindElement(By.Id("input-password")).Clear();
            driver.FindElement(By.Id("input-password")).SendKeys("lozinka123");
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        [Test]
        public void TreciTest()
        {
            Random rand = new Random();
            driver.Navigate().GoToUrl("https://demo.opencart.com/");
            driver.FindElement(By.LinkText("My Account")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.LinkText("Login")).Click();
            driver.FindElement(By.Id("input-email")).Click();
            driver.FindElement(By.Id("input-email")).Clear();
            driver.FindElement(By.Id("input-email")).SendKeys("ivanparadzik4@gmail.com");
            driver.FindElement(By.Id("input-password")).Click();
            driver.FindElement(By.Id("input-password")).Clear();
            driver.FindElement(By.Id("input-password")).SendKeys("lozinka123");
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.LinkText("Edit your account information")).Click();
            driver.FindElement(By.Id("input-firstname")).Clear();
            driver.FindElement(By.Id("input-firstname")).SendKeys("NovoIme" + rand.Next(200));
            driver.FindElement(By.Id("input-lastname")).Click();
            driver.FindElement(By.Id("input-lastname")).Clear();
            driver.FindElement(By.Id("input-lastname")).SendKeys("NovoPrezime" + rand.Next(200));
            driver.FindElement(By.XPath("//input[@value='Continue']")).Click();
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
