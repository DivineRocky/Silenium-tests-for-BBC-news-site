using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using System.Linq;

namespace Test_Automation_EPAM
{
    internal class DoYouHaveAQuestionToBBCPage
    {
        public DoYouHaveAQuestionToBBCPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public static int MaxFormLength => 140;

        [FindsBy(How = How.XPath, Using = ".//*[@class='text-input--long']")]
        private IWebElement questionForm;

        [FindsBy(How = How.XPath, Using = ".//*[@placeholder='Name']")]
        private IWebElement name;

        [FindsBy(How = How.XPath, Using = ".//*[@placeholder='Email address']")]
        private IWebElement email;

        [FindsBy(How = How.XPath, Using = ".//*[@placeholder='Age']")]
        private IWebElement age;

        [FindsBy(How = How.XPath, Using = ".//*[@placeholder='Postcode']")]
        private IWebElement postcode;

        [FindsBy(How = How.XPath, Using = ".//*[@class='button-container']")]
        private IWebElement submitButton;

        [FindsBy(How = How.XPath, Using = "(.//*[@class='input-error-message'])")]
        private IList<IWebElement> formError;

        public void FillTheForm(string requestForm, string nameForm, string emailForm, string ageForm, string postcodeForm)
        {
            questionForm.SendKeys(requestForm);
            name.SendKeys(nameForm);
            email.SendKeys(emailForm);
            age.SendKeys(ageForm);
            postcode.SendKeys(postcodeForm);
        }

        public void SubmitForm()
        {
            submitButton.Click();
        }      
        
        public string GetFormText()
        {
            return questionForm.GetAttribute("value");
        }

        public IEnumerable<string> GetErrors()
        {
            return formError?.Select(x => x.Text);
        }
    }
}
