using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlanitTechnicalTestLibrary.Pages
{
    [TestFixture]
    class SubmissionTest : BaseTest
    {
        [Test]
        [Repeat(5)]
        public void ValidateSubmissionMessage()
        {
            FeedbackPage page = new FeedbackPage();
            TopMenuRibbon topMenuribbon = new TopMenuRibbon();
            SubmissionPage submissionPage = new SubmissionPage();

            string forename = "Kirti" ;
            topMenuribbon.ClickContactButton(driver);
            page.EnterForename(driver, forename);
            page.EnterEmail(driver);
            page.EnterMessage(driver);
            page.ClickSubmitButton(driver);
            var SubmissionStatus = submissionPage.VerifySubmissionMessage(driver,forename);
            Assert.IsTrue(SubmissionStatus);
        }
    }
}
