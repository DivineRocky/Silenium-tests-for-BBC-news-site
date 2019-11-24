using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;

namespace Test_Automation_EPAM
{
    [TestClass]
    public class SecondTaskBBCTests : BBCTestsBase
    {
        private void GoToSubmissionForm()
        {
            _bbcFacade.GoToNews();
            string secondMoreElementXPath = "/html/body/div[7]/header/div[2]/div/div[1]/nav/ul/li[15]";
            _bbcFacade.ClickOnXPath(secondMoreElementXPath);
            var haveYouSayElement = _driver.FindElement(By.PartialLinkText("Have Your Say"));
            haveYouSayElement.Click();
            string questionForBBCXPath = "/html/body/div[7]/div/div[1]/div/div[2]/div[2]/div[1]/div/div[2]/div/a";
            _bbcFacade.ClickOnXPath(questionForBBCXPath);
        }

        [TestMethod]
        public void VerifySubmission_EmptyForm_ErrorsAppears()
        {
            //Arrange
            GoToSubmissionForm();
            var textErrorXpath = "/html/body/div[2]/div[6]/div/div[5]/div[1]/div[2]/div/div[1]/div[1]/div[2]/div[2]/div/div/div[1]/div[1]/div[2]";
            var nameErrorXpath = "/html/body/div[2]/div[6]/div/div[5]/div[1]/div[2]/div/div[1]/div[1]/div[2]/div[2]/div/div/div[1]/div[3]/div[1]/div/label/div";
            var emailErrorXpath = "/html/body/div[2]/div[6]/div/div[5]/div[1]/div[2]/div/div[1]/div[1]/div[2]/div[2]/div/div/div[1]/div[3]/div[2]/div/label/div";

            //Act           
            string submitXPath = "/html/body/div[2]/div[6]/div/div[5]/div[1]/div[2]/div/div[1]/div[1]/div[2]/div[2]/div/div/div[1]/div[5]/button";
            _bbcFacade.ClickOnXPath(submitXPath);

            //Assert            
            Assert.IsTrue(VerifyElemetAppearance(textErrorXpath));
            Assert.IsTrue(VerifyElemetAppearance(nameErrorXpath));
            Assert.IsTrue(VerifyElemetAppearance(emailErrorXpath));
        }

        private bool VerifyElemetAppearance(string xPath)
        {
            try
            {
                var bigErrorElement = _driver.FindElement(By.XPath(xPath));
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

    }
}
