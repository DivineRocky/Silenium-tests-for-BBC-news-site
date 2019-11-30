using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using System.Linq;

namespace Test_Automation_EPAM
{
    internal class BBCNewsPage
    {
        public BBCNewsPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[contains(@class, 'gs-c-promo-heading gs-o-faux-block-link__overlay-link')]")]
        private IList<IWebElement> headliners;

        [FindsBy(How = How.XPath, Using = "(.//*[@class='nw-c-promo-meta']/a/span[1])[1]")]
        private IWebElement keyWord;

        [FindsBy(How = How.XPath, Using = ".//*[@id='orb-search-q']")]
        private IWebElement searchBar;

        [FindsBy(How = How.XPath, Using = ".//*[@id='orb-search-button']")]
        private IWebElement searchButton;

        [FindsBy(How = How.XPath, Using = ".//*[@class='nw-c-nav__wide']/ul/li[15]/span/button")]
        private IWebElement moreButton;

        [FindsBy(How = How.XPath, Using = "(//*[@class='nw-c-nav__wide-overflow-list gel-layout']/ul/li/a)[4]")]
        private IWebElement haveYourSayLink;

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
