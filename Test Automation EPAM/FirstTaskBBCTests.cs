﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Test_Automation_EPAM
{
    [TestClass]
    public class FirstTaskBBCTests : BBCTestsBase
    {
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
            _bbcFacade.GoToNews();

            //Act
            var articleTitles = _driver.FindElements(By.XPath("/html/body/div[7]/div/div[4]/div[2]/div/div/div/div/div")).Select(x => x.Text).ToList();

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
            _bbcFacade.GoToNews();
            IWebElement category = _driver.FindElement(By.XPath("/html/body/div[7]/div/div[4]/div[2]/div/div/div/div/div[1]/div/div/div[1]/ul/li[2]/a/span"));
            string categoryResult = category.Text;

            //Act
            IWebElement searchBar = _driver.FindElement(By.XPath("/html/body/header/div/div[1]/div[3]/form/div/input[1]"));
            searchBar.SendKeys(categoryResult);
            string startSearchXPath = "/html/body/header/div/div[1]/div[3]/form/div/button";
            _bbcFacade.ClickOnXPath(startSearchXPath);
            IWebElement searchResult = _driver.FindElement(By.XPath("/html/body/div[6]/section[2]/ol[1]/li[1]/article/div/h1/a"));

            //Assert
            Assert.AreEqual(categoryResult, searchResult.Text);
        }
    }
}
