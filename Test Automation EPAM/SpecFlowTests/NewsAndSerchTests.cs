using BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecFlowTests.DTO;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowTests
{
    [Binding]
    public class NewsAndSerchTests
    {
        private static BBCSiteFacade bBCSiteFacade;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            bBCSiteFacade = new BBCSiteFacade();
        }

        [When(@"I go to BBC News tab")]
        public void WhenIGToBBCNewsTab()
        {
            bBCSiteFacade.GoToNews();
        }

        [Then(@"I should see listed articles on page")]
        public void ThenIShouldSeeListedArticlesOnPage(Table table)
        {
            var articleTitles = bBCSiteFacade.GetFirstNewsTitles();
            var expectedResults = table.CreateSet<Article>();

            foreach (var expectedResult in expectedResults)
            {
                Assert.IsTrue(articleTitles.Any(at => at.Contains(expectedResult.Title)));
            }
        }

        [When(@"I search for some news using top article keyword")]
        public void WhenISearchForSomeNewsUsingTopArticleKeyword()
        {
            bBCSiteFacade.SearchForFirstTagFromNews();
        }

        [Then(@"I should see keyword results")]
        public void ThenIShouldSeeKeywordResults()
        {
            var exception = ScenarioContext.Current.TestError;
            Assert.AreEqual(null, exception);
        }

        [AfterTestRun]
        public static void AfterRun()
        {
            bBCSiteFacade.Dispose();
        }
    }
}
