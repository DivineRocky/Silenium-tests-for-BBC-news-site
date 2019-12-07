using OpenQA.Selenium;

namespace PageObjects
{
    public class SearchPage: BbcBasePageObject
    {
        public SearchPage(IWebDriver driver)
            :base(driver)
        {
        }

        private IWebElement searchResult => Driver.FindElement(By.XPath("//*[@id='se-searchbox-input-field']"));

        public string GetSearchText()
        {
            string keySearchResult = searchResult.GetAttribute("value");
            return keySearchResult;
        }
    }
}
