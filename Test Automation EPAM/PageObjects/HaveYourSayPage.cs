using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Test_Automation_EPAM
{
    internal class HaveYourSayPage
    {
        public HaveYourSayPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "(.//*[@ class='nw-c-5-slice gel-layout gel-layout--equal b-pw-1280']/div[1]/div/div[2]/div/a)[1]")]
        private IWebElement doYouHaveAQuestion;

        public void GoToDoYouHaveAQuestion()
        {
            doYouHaveAQuestion.Click();
        }
    }
}
