using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Test_Automation_EPAM
{
    [TestClass]
    public class SeleniumBBCTests
    {
        IWebDriver _driver;

        [TestInitialize]
        public void Initialize()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 7);
        }

        [TestMethod]
        public void GoToBBCWebSite()
        {
            // Creates a new Chrome instance and opens the browser
            // Navigates to a page by address
            _driver.Navigate().GoToUrl("https://www.bbc.com");
        }

        [TestMethod]
        public void VerifyFirstArticleTitle()
        {
            //Arrange
            _driver.Navigate().GoToUrl("https://www.bbc.com");
            IWebElement element = _driver.FindElement(By.XPath("/html/body/header/div/div[1]/nav/div/ul/li[2]/a"));

            //Act
            element.Click();
            IWebElement headLine = _driver.FindElement(By.XPath("/html/body/div[7]/div/div[4]/div[2]/div/div/div/div/div[1]/div/div/div[1]/div/a/h3"));
            string elementText = headLine.Text;

            //Assert
            Assert.AreEqual("India air pollution at 'unbearable levels'", elementText);
        }

        [TestMethod]
        [DataRow("Hong Kong protests: Knife attacker bites man's ear", "/html/body/div[7]/div/div[4]/div[2]/div/div/div/div/div[3]/div/div[2]/div/a")]
        [DataRow("Nigel Farage will not stand as election candidate", "/html/body/div[7]/div/div[4]/div[2]/div/div/div/div/div[5]/div/div[2]/div/a")]
        [DataRow("World's most profitable company to go public", "/html/body/div[7]/div/div[4]/div[2]/div/div/div/div/div[8]/div/div[2]/div/a")]
        [DataRow("The Russian vegans cooking up a revolution", "/html/body/div[7]/div/div[4]/div[2]/div/div/div/div/div[9]/div/a/div/div/h3")]
        [DataRow("'Comfort women' film to be shown in Japan amid row", "/html/body/div[7]/div/div[4]/div[2]/div/div/div/div/div[11]/div/div[2]/div/a")]
        public void VerifyMultipleArticleTitles(string expectedResult, string elementXPath)
        {
            //Arrange
            _driver.Navigate().GoToUrl("https://www.bbc.com");
            IWebElement element = _driver.FindElement(By.XPath("/html/body/header/div/div[1]/nav/div/ul/li[2]/a"));
            IWebElement headLine;

            //Act
            element.Click();
            headLine = _driver.FindElement(By.XPath(elementXPath));
            string elementText = headLine.Text;

            //Assert
            Assert.AreEqual(expectedResult, elementText);           
        }

        [TestMethod]
        public void VerifySearchBar()
        {
            //Arrange
            _driver.Navigate().GoToUrl("https://www.bbc.com");
            IWebElement element = _driver.FindElement(By.XPath("/html/body/header/div/div[1]/nav/div/ul/li[2]/a"));
            element.Click();
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

