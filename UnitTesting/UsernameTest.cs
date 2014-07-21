using System;
using System.Drawing.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Selenium;

namespace UnitTesting
{
    [TestFixture]
    public class UsernameTest
    {
        private IWebDriver driver;
        private String urlPrefix = "qavip";
        private int waitTime = 3000;
        private const String user = "admin";
        private const String password = "1234";
        //private Boolean test = false;

        [Test]
        public void Init()
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://" + urlPrefix + ".orpheusdev.net/");
            Console.WriteLine(driver.FindElement(By.Name("version")).GetAttribute("content"));

            IWebElement userName = driver.FindElement(By.Name("UserName"));
            Assert.IsTrue(userName.Displayed);
            userName.SendKeys(user);
            userName.SendKeys(Keys.Enter);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(waitTime));

            IWebElement personalImage = driver.FindElement(By.XPath("/html/body/div/div[1]/div[2]/div/div/div/div/div/div[1]/img"));
            Assert.IsTrue(personalImage.Displayed);

            IWebElement personalPhrase = driver.FindElement(By.XPath("/html/body/div/div[1]/div[2]/div/div/div/div/div/div[1]/p/img"));
            Assert.IsTrue(personalPhrase.Displayed);
        }
    }
}