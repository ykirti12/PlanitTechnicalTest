using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanitTechnicalTestLibrary
{
    public class Helper
    {
        public void WaitForElementToBeVisible(IWebDriver driver, string xpath)
        {
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
        }
    }
}
