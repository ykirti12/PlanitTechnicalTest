using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PlanitTechnicalTestLibrary.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanitTechnicalTestLibrary
{
    [TestFixture]
    public class ValidateErrorsTest : BaseTest
    {
        [Test]
        public void ValidateErrorOnFeedbackPage()
        {
            TopMenuRibbon topMenuRibbon = new TopMenuRibbon();
            FeedbackPage feedbackPage = new FeedbackPage();

            topMenuRibbon.ClickContactButton(driver);
            feedbackPage.ClickSubmitButton(driver);
            var ForNameErrorStatus = feedbackPage.ValidateForenameErrorMessage(driver);
            var EmailErrorStatus = feedbackPage.ValidateEmailErrorMessage(driver);
            var MessageErrorStatus = feedbackPage.ValidateMessageError(driver);
            var MainErrorStatus = feedbackPage.ValidateMainErrorMessage(driver);
            Assert.IsTrue(
                ForNameErrorStatus 
                && EmailErrorStatus 
                && MessageErrorStatus 
                && MainErrorStatus
                );
        }

        [Test]
        public void ValidateErrorAreRemovedOnFillingMandatoryFields()
        {
            string forename = "Ravi";
            TopMenuRibbon topMenuRibbon = new TopMenuRibbon();
            FeedbackPage feedbackPage = new FeedbackPage();

            topMenuRibbon.ClickContactButton(driver);
            feedbackPage.ClickSubmitButton(driver);
            feedbackPage.EnterForename(driver, forename);
            feedbackPage.EnterEmail(driver);
            feedbackPage.EnterMessage(driver);
            //SubmissionPage.VerifySubmissionMessage(driver, forename);
            var MainErrorStatus = feedbackPage.ValidateMainError(driver);

            Assert.IsTrue(MainErrorStatus);
        }
    }
}
