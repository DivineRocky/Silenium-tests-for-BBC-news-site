using OpenQA.Selenium;

namespace PageObjects
{
    public class HaveYourSayPage : BbcBasePageObject
    {
        public HaveYourSayPage(IWebDriver driver) 
            : base(driver)
        {
        }

        private IWebElement doYouHaveAQuestion => Driver.FindElement(By.XPath("(.//*[@ class='nw-c-5-slice gel-layout gel-layout--equal b-pw-1280']/div[1]/div/div[2]/div/a)[1]"));

        public void GoToDoYouHaveAQuestion()
        {
            doYouHaveAQuestion.Click();
        }
    }
}
