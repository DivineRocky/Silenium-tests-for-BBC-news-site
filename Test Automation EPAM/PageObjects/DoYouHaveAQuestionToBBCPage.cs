using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PageObjects
{
    public class DoYouHaveAQuestionToBBCPage : BbcBasePageObject
    {
        public DoYouHaveAQuestionToBBCPage(IWebDriver driver) 
            : base(driver)
        {
        }

        public static int MaxFormLength => 140;

        private IWebElement questionForm => Driver.FindElement(By.XPath(".//*[@class='text-input--long']"));
        private IWebElement name => Driver.FindElement(By.XPath(".//*[@placeholder='Name']"));
        private IWebElement email => Driver.FindElement(By.XPath(".//*[@placeholder='Email address']"));
        private IWebElement submitButton => Driver.FindElement(By.XPath(".//*[@class='button-container']"));
        private IList<IWebElement> formError => Driver.FindElements(By.XPath("(.//*[@class='input-error-message'])"));

        public void FillTheForm(string requestForm, string nameForm, string emailForm)
        {
            questionForm.SendKeys(requestForm);
            name.SendKeys(nameForm);
            email.SendKeys(emailForm);
        }

        public void SubmitForm()
        {
            submitButton.Click();
            var errors = GetErrors();
            if (errors.Any())
            {
                throw new ArgumentException(errors.First());
            }
        }      
        
        public string GetFormText()
        {
            return questionForm.GetAttribute("value");
        }

        private IEnumerable<string> GetErrors()
        {
            return formError?.Select(x => x.Text);
        }
    }
}
