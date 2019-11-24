using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Automation_EPAM
{
    [TestClass]
    public class BBCTestsBase
    {
        protected IWebDriver _driver;
        protected BBCFacade _bbcFacade;

        [TestInitialize]
        public void Initialize()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 7);
            _driver.Manage().Window.Maximize();
            _bbcFacade = new BBCFacade(_driver);
        }

        [TestCleanup]
        public void CleanUp()
        {
            _driver.Close();
        }
    }
}
