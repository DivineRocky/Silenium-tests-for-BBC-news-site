using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Test_Automation_EPAM
{
    internal class SearchPage
    {
        public SearchPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='se-searchbox-input-field']")]
        private IWebElement searchResult;

        public string GetSearchText()
        {
            string keySearchResult = searchResult.GetAttribute("value");
            return keySearchResult;
        }
    }
}
