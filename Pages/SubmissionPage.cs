using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanitTechnicalTestLibrary.Pages
{
    public class SubmissionPage 
    {
        string SubmissionMessageXpath = "//div[@class='alert alert-success']";
        public bool VerifySubmissionMessage(IWebDriver driver, string forename)
        {
            Helper helper = new Helper();
            helper.WaitForElementToBeVisible(driver, SubmissionMessageXpath);
            var SuccessfulSubmissionMessage = driver.FindElement(By.XPath(SubmissionMessageXpath));
            var message = SuccessfulSubmissionMessage.Text;
            if (message.Equals($"Thanks {forename}, we appreciate your feedback."))
                return true;
            else
                return false;
        }
    }
}
