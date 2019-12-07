using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace PageObjects
{
    public class BBCNewsPage:BbcBasePageObject
    {
        public BBCNewsPage(IWebDriver driver)
            :base(driver)
        {
        }

        private IList<IWebElement> headliners => Driver.FindElements(By.XPath("//a[contains(@class, 'gs-c-promo-heading gs-o-faux-block-link__overlay-link')]"));
        private IWebElement keyWord => Driver.FindElement(By.XPath("(.//*[@class='nw-c-promo-meta']/a/span[1])[1]"));
        private IWebElement searchBar => Driver.FindElement(By.XPath(".//*[@id='orb-search-q']"));
        private IWebElement searchButton => Driver.FindElement(By.XPath(".//*[@id='orb-search-button']"));
        private IWebElement moreButton => Driver.FindElement(By.XPath(".//*[@class='nw-c-nav__wide']/ul/li[15]/span/button"));
        private IWebElement haveYourSayLink => Driver.FindElement(By.XPath("(//*[@class='nw-c-nav__wide-overflow-list gel-layout']/ul/li/a)[4]"));

        public IEnumerable<string> GetArticleTitles()
        {
            var articleTitles = headliners.Select(x => x.Text).ToList();
            return articleTitles;
        }

        public string GetKeyWord()
        { 
            string hashKeyWord = keyWord.Text;
            return hashKeyWord;
        }

        public void Search(string textQuery)
        {
            searchBar.SendKeys(textQuery);
            searchButton.Click();
        }

        public void GoToHaveYourSay()
        {
            moreButton.Click();
            haveYourSayLink.Click();
        }
    }



        
}   
