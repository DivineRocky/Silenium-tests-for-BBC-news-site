using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test_Automation_EPAM
{
    [TestClass]
    public class FirstTaskBBCTests : BBCTestsBase
    {
        [TestMethod]
        public void GoToBBCNewsTab()
        {
            BBCMainPage BBCMainPage = new BBCMainPage(_driver);
            BBCMainPage.GoToNews();
        }

        [TestMethod]
        public void VerifyMultipleArticleTitles()
        {
            //Arrange
            List<string> expectedResults = new List<string>();
            expectedResults.Add("Record numbers vote in Hong Kong elections");
            expectedResults.Add("Cryptoqueen: How this woman made billions - then vanished");
            expectedResults.Add("Passenger plane crashes into homes in DR Congo");
            expectedResults.Add("'We are protesting with a peaceful marathon'");
            expectedResults.Add("US Justice Ruth Bader Ginsburg hospitalised");
            expectedResults.Add("Tesla truck has 150,000 orders despite launch gaffe");

            //Act
            GoToNews();
            BBCNewsPage BBCNewsPage = new BBCNewsPage(_driver);
            var articleTitles = BBCNewsPage.GetArticleTitles();
            
            //Assert
            foreach (var expectedResult in expectedResults)
            {
                Assert.IsTrue(articleTitles.Any(at => at.Contains(expectedResult)));
            }
        }

        [TestMethod]
        public void VerifySearchBar()
        {
            //Arrange
            GoToNews();
            BBCNewsPage BBCNewsPage = new BBCNewsPage(_driver);
            var keyWord = BBCNewsPage.GetKeyWord();
            BBCNewsPage.Search(keyWord);
            SearchPage SearchPage = new SearchPage(_driver);
            var searchResult = SearchPage.GetSearchText();

            //Assert
            Assert.AreEqual(keyWord, searchResult);
        }
    }
}

