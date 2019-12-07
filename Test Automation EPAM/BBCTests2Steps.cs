using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;
using Test_Automation_EPAM.BL;

namespace Test_Automation_EPAM
{
    [Binding]
    public class BBCTests2Steps
    {
        readonly BBCSiteFacade BBCSiteFacade = new BBCSiteFacade();

        [When(@"I submit the Question Form with all fields fulfilled")]
        public void WhenISubmitTheQuestionFormWithAllFieldsFulfilled()
        {
            BBCSiteFacade.AskQuestion("some text","","randomemail@random.com","22","some adress");
        }
        
        [When(@"I submit the Question Form without Question Form fulfilled")]
        public void WhenISubmitTheQuestionFormWithoutQuestionFormFulfilled()
        {
            BBCSiteFacade.AskQuestion("", "Maria", "randomemail@random.com", "22", "some adress");
        }
        
        [When(@"I submit the Question Form without Name field fulfilled")]
        public void WhenISubmitTheQuestionFormWithoutNameFieldFulfilled()
        {
            BBCSiteFacade.AskQuestion("some text", "", "randomemail@random.com", "22", "some adress");
        }
        
        [When(@"I submit the Question Form without Email field fulfilled")]
        public void WhenISubmitTheQuestionFormWithoutEmailFieldFulfilled()
        {
            BBCSiteFacade.AskQuestion("some text", "Maria", "", "22", "some adress");
        }
        
        [Then(@"I should see the Question Form sent confirmation")]
        public void ThenIShouldSeeTheQuestionFormSentConfirmation()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I should see an error message telling me I must fulfill the Question Form field")]
        public void ThenIShouldSeeAnErrorMessageTellingMeIMustFulfillTheQuestionFormField()
        {
            var exception = ScenarioContext.Current.TestError;
            if (exception is ArgumentException
                && exception.Message.Contains("can't be blank"))
            {
                Assert.Inconclusive(exception.Message);
            }
        }
        
        [Then(@"I should see an error message telling me I must fulfill the Name field")]
        public void ThenIShouldSeeAnErrorMessageTellingMeIMustFulfillTheNameField()
        {
            var exception = ScenarioContext.Current.TestError;
            if (exception is ArgumentException
                && exception.Message.Contains("Name can't be blank"))
            {
                Assert.Inconclusive(exception.Message);
            }
        }
        
        [Then(@"I should see an error message telling me I must fulfill the Email field")]
        public void ThenIShouldSeeAnErrorMessageTellingMeIMustFulfillTheEmailField()
        {
            var exception = ScenarioContext.Current.TestError;
            if (exception is ArgumentException
                && exception.Message.Contains("Email address can't be blank"))
            {
                Assert.Inconclusive(exception.Message);
            }
        }
    }
}
