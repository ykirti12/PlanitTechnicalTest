using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanitTechnicalTestLibrary
{
    [TestFixture]
    public class BaseTest
    {
        string BaseUrl = "http://jupiter.cloud.planittesting.com";
        public IWebDriver driver;

        [SetUp]
        public void TestSetup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(BaseUrl);
        }

        [TearDown]
        public void TestTeardown()
        {
            driver.Quit();
        }
    }
    
}
