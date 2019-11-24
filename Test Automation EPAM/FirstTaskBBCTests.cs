using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Test_Automation_EPAM
{
    [TestClass]
    public class FirstTaskBBCTests
    {
        IWebDriver _driver;

        [TestInitialize]
        public void Initialize()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 7);
        }

        private void GoToNews()
        {
            _driver.Navigate().GoToUrl("https://www.bbc.com");
            IWebElement newsTab = _driver.FindElement(By.XPath("/html/body/header/div/div[1]/nav/div/ul/li[2]/a"));
            newsTab.Click();
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
            GoToNews();

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
            GoToNews();
            IWebElement category = _driver.FindElement(By.XPath("/html/body/div[7]/div/div[4]/div[2]/div/div/div/div/div[1]/div/div/div[1]/ul/li[2]/a/span"));
            string categoryResult = category.Text;

            //Act
            IWebElement searchBar = _driver.FindElement(By.XPath("/html/body/header/div/div[1]/div[3]/form/div/input[1]"));
            searchBar.SendKeys(categoryResult);
            IWebElement startSearch = _driver.FindElement(By.XPath("/html/body/header/div/div[1]/div[3]/form/div/button"));
            startSearch.Click();
            IWebElement searchResult = _driver.FindElement(By.XPath("/html/body/div[6]/section[2]/ol[1]/li[1]/article/div/h1/a"));

            //Assert
            Assert.AreEqual(categoryResult, searchResult.Text);

        }

        [TestCleanup]
        public void CleanUp()
        {
            _driver.Close();
        }
    }
}

