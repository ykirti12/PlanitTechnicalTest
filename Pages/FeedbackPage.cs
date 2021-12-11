using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace PlanitTechnicalTestLibrary.Pages
{
    public class FeedbackPage
    {
        string SubmitButtonXPath = "//*[@class='btn-contact btn btn-primary']";
        string ForeNameTextFieldId = "forename";
        string ForeNameValue = "Yadav";
        string EmailTextFieldId = "email";
        string EmailValue = "kirti@yahoo.com";
        string MessageTextFieldId = "message";
        string MessageValue = "Test Passed";
        string MainErrorElementXPath = "//div[@class='alert alert-info ng-scope']";
        string MainErrorMessage = "We welcome your feedback - tell it how it is.";
        string LoadingBarXPath = "//div[@style='display: block;']";

        public void ClickSubmitButton(IWebDriver driver)
        {
            var SubmitButton = driver.FindElement(By.XPath(SubmitButtonXPath));
            SubmitButton.SendKeys("");
            SubmitButton.Click();
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath(LoadingBarXPath)));
        }

        public bool ValidateForenameErrorMessage(IWebDriver driver)
        {
            var ForeNameError = driver.FindElement(By.Id("forename-err"));
            var error = ForeNameError.Text;
            if (error.Equals("Forename is required"))
                return true;
            else 
                return false;
        }

        public bool ValidateEmailErrorMessage(IWebDriver driver)
        {
            var EmailError = driver.FindElement(By.Id("email-err"));
            var error = EmailError.Text;
            if (error.Equals("Email is required"))
                    return true;
                else
                    return false;
        }

        public bool ValidateMessageError(IWebDriver driver)
        {
            var MessageError = driver.FindElement(By.Id("message-err"));
            var error = MessageError.Text;
            if (error.Equals("Message is required"))
                    return true;
                else
                    return false;
        }

        public bool ValidateMainErrorMessage(IWebDriver driver)
        {
            var MainErrorElement = driver.FindElement(By.XPath("//div[@class='alert alert-error ng-scope']"));
            var MainError = MainErrorElement.Text;
            if (MainError.Equals("We welcome your feedback - but we won't get it unless you complete the form correctly."))
                    return true;
                else
                    return false;
        }

        public bool ValidateMainError(IWebDriver driver)
        {
            var MainErrorElement = driver.FindElement(By.XPath(MainErrorElementXPath));
            var MainError = MainErrorElement.Text;
            if (MainError.Equals(MainErrorMessage))
                return true;
            else
                return false;
        }

        public void EnterForename(IWebDriver driver)
        {
            var ForeNameTextField = driver.FindElement(By.Id(ForeNameTextFieldId));
            ForeNameTextField.SendKeys(ForeNameValue);
        }
        public void EnterForename(IWebDriver driver, string forename)
        {
            var ForeNameTextField = driver.FindElement(By.Id(ForeNameTextFieldId));
            ForeNameTextField.SendKeys(forename);
        }

        public void EnterEmail(IWebDriver driver)
        {
            var EmailTextField = driver.FindElement(By.Id(EmailTextFieldId));
            EmailTextField.SendKeys(EmailValue);
        }

        public void EnterMessage(IWebDriver driver)
        {
            var MessageTextField = driver.FindElement(By.Id(MessageTextFieldId));
            MessageTextField.SendKeys(MessageValue);
        }
    }
}
