using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace Test_Automation_EPAM
{
    [TestClass]
    public class BBCTestsBase
    {
        protected IWebDriver _driver;

        [TestInitialize]
        public void Initialize()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 7);
            _driver.Manage().Window.Maximize();
        }

        [TestCleanup]
        public void CleanUp()
        {
            _driver.Close();
        }

        protected void GoToNews()
        {
            BBCMainPage BBCMainPage = new BBCMainPage(_driver);
            BBCMainPage.GoToNews();
        }
    }
}
