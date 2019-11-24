using OpenQA.Selenium;

namespace Test_Automation_EPAM
{
    public class BBCFacade
    {
        private readonly IWebDriver _driver;

        public BBCFacade(IWebDriver driver)
        {
            _driver = driver;
        }

        public void GoToNews()
        {
            _driver.Navigate().GoToUrl("https://www.bbc.com");
            string newsTabXPath = "/html/body/header/div/div[1]/nav/div/ul/li[2]/a";
            ClickOnXPath(newsTabXPath);
        }

        public void ClickOnXPath(string xPath)
        {
            IWebElement goToHaveYourSay = _driver.FindElement(By.XPath(xPath));
            goToHaveYourSay.Click();
        }
    }
}
