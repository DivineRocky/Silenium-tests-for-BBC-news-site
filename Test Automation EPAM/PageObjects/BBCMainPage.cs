using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace Test_Automation_EPAM
{
    internal class BBCMainPage
    {
        public BBCMainPage(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("https://www.bbc.com");
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(20)));
        }

        [FindsBy(How = How.XPath, Using = ".//*[@id='orb-nav-links']/ul/li[2]")]
        public IWebElement bbcNewsPage;

        public void GoToNews()
        {
            bbcNewsPage.Click();
        }
    }

 
}
