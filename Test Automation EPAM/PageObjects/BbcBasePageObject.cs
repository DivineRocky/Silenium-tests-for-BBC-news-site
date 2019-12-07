using OpenQA.Selenium;

namespace PageObjects
{
    public abstract class BbcBasePageObject
    {
        protected IWebDriver Driver;

        public BbcBasePageObject(IWebDriver driver)
        {
            this.Driver = driver;
        }
    }
}