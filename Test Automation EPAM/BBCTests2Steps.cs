using TechTalk.SpecFlow;

namespace Test_Automation_EPAM
{
    [Binding]
    public class BBCTests2Steps
    {
        [Given(@"I want to ask a question to BBC Team")]
        public void GivenIWantToAskAQuestionToBBCTeam()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I submit the Question Form with all fields fulfilled")]
        public void WhenISubmitTheQuestionFormWithAllFieldsFulfilled()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I submit the Question Form without Question Form fulfilled")]
        public void WhenISubmitTheQuestionFormWithoutQuestionFormFulfilled()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I submit the Question Form without Name field fulfilled")]
        public void WhenISubmitTheQuestionFormWithoutNameFieldFulfilled()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I submit the Question Form without Email field fulfilled")]
        public void WhenISubmitTheQuestionFormWithoutEmailFieldFulfilled()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I should see the Question Form sent confirmation")]
        public void ThenIShouldSeeTheQuestionFormSentConfirmation()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I should see an error message telling me I must fulfill the Question Form field")]
        public void ThenIShouldSeeAnErrorMessageTellingMeIMustFulfillTheQuestionFormField()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I should see an error message telling me I must fulfill the Name field")]
        public void ThenIShouldSeeAnErrorMessageTellingMeIMustFulfillTheNameField()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I should see an error message telling me I must fulfill the Email field")]
        public void ThenIShouldSeeAnErrorMessageTellingMeIMustFulfillTheEmailField()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
