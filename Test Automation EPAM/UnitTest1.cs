using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test_Automation_EPAM
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
    }

    public class UnitTest2
    {
        [IWebDriver]
        public void IWebDriver()
            IWebDriver driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://www.bbc.com");
    }


}

