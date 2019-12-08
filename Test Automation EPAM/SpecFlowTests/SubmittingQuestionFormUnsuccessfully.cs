using BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecFlowTests.DTO;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowTests
{
    [Binding]
    public class SubmittingQuestionFormUnsuccessfully
    {
        private static BBCSiteFacade bBCSiteFacade;
        private const string errorTag = "Exception_Form";

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            bBCSiteFacade = new BBCSiteFacade();
        }

        [When(@"I fulfill a Question Form without Text field")]
        public void WhenIFulfillAQuestionFormWithoutTextField(Table table)
        {
            AskQuestion(table);
        }

        [When(@"I fulfill a Question Form without Name field")]
        public void WhenIFulfillAQuestionFormWithoutNameField(Table table)
        {
            AskQuestion(table);
        }

        [When(@"I fulfill a Question Form without Email field")]
        public void WhenIFulfillAQuestionFormWithoutEmailField(Table table)
        {
            AskQuestion(table);
        }

        private static void AskQuestion(Table table)
        {
            var questionForm = table.CreateInstance<QuestionForm>();
            try
            {
                bBCSiteFacade.AskQuestion(questionForm.Text, questionForm.Name, questionForm.Email);
            }
            catch (Exception e)
            {
                ScenarioContext.Current.Add(errorTag, e.Message);
            }
        }

        [Then(@"an Empty Text Error occurs")]
        public void ThenAnEmptyTextErrorOccurs(Table table)
        {
            var occuredError = ScenarioContext.Current[errorTag];
            var error = table.CreateInstance<Error>();
            Assert.AreEqual(error.ErrorMessage, occuredError);
        }

        [Then(@"an Empty Name Error occurs")]
        public void ThenAnEmptyNameErrorOccurs(Table table)
        {
            var occuredError = ScenarioContext.Current[errorTag];
            var error = table.CreateInstance<Error>();
            Assert.AreEqual(error.ErrorMessage, occuredError);
        }

        [Then(@"an Empty Email Error occurs")]
        public void ThenAnEmptyEmailErrorOccurs(Table table)
        {
            var occuredError = ScenarioContext.Current[errorTag];
            var error = table.CreateInstance<Error>();
            Assert.AreEqual(error.ErrorMessage, occuredError);
        }

        [AfterTestRun]
        public static void AfterRun()
        {
            bBCSiteFacade.Dispose();
        }
    }
}
