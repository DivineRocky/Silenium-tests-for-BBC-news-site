using OpenQA.Selenium;

namespace PageObjects
{
    public class BBCMainPage: BbcBasePageObject
    {
        public BBCMainPage(IWebDriver driver)
            :base(driver)
        {
            driver.Navigate().GoToUrl("https://www.bbc.com");
        }

        private IWebElement bbcNewsPage => Driver.FindElement(By.XPath(".//*[@id='orb-nav-links']/ul/li[2]"));

        public void GoToNews()
        {
            bbcNewsPage.Click();
        }
    }

 
}
