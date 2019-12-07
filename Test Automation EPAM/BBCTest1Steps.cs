using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using Test_Automation_EPAM.BL;

namespace Test_Automation_EPAM
{
    [Binding]
    public class BBCTest1Steps
    {
        readonly BBCSiteFacade BBCSiteFacade = new BBCSiteFacade();

        [When(@"I go to BBC News tab")]
        public void WhenIGToBBCNewsTab(Table table)
        {
            BBCSiteFacade.GoToNews();
        }

        [When(@"I search for some news using top article keyword")]
        public void WhenISearchForSomeNewsUsingTopArticleKeyword()
        {
            BBCSiteFacade.SearchForFirstTagFromNews();
        }

        [Then(@"I should see top articles block")]
        public void ThenIShouldSeeTopArticlesBlock()
        {
            BBCSiteFacade.GetFirstNewsTitles();
        }

        [Then(@"I should see keyword results")]
        public void ThenIShouldSeeKeywordResults()
        {           
            var exception = ScenarioContext.Current.TestError;
            Assert.AreEqual(null, exception);
        }
    }
}
