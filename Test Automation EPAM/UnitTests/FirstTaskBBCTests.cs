using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class FirstTaskBBCTests : BBCTestsBase
    {
        [TestMethod]
        public void GoToBBCNewsTab()
        {
            bBCSiteFacade.GoToNews();
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
            bBCSiteFacade.GoToNews();

            //Act
            var articleTitles = bBCSiteFacade.GetFirstNewsTitles();
            
            //Assert
            foreach (var expectedResult in expectedResults)
            {
                Assert.IsTrue(articleTitles.Any(at => at.Contains(expectedResult)));
            }
        }

        [TestMethod]
        public void Search_NormalInput_NoErrors()
        {
            //Arrange
            bBCSiteFacade.SearchForFirstTagFromNews();
        }
    }
}

