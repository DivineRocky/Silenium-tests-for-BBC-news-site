using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace BusinessLogic
{
    public class BBCSiteFacade : IDisposable
    {
        public static string SearchError = "Search Failed";
        private readonly IWebDriver webDriver;

        private readonly DoYouHaveAQuestionToBBCPage questionToBBCPage;
        private readonly BBCNewsPage bBCNewsPage;
        private readonly BBCMainPage bBCMainPage;
        private readonly HaveYourSayPage haveYourSayPage;
        private readonly SearchPage searchPage;

        public BBCSiteFacade()
        {
            webDriver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            webDriver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 7);
            webDriver.Manage().Window.Maximize();
            questionToBBCPage = new DoYouHaveAQuestionToBBCPage(webDriver);
            bBCNewsPage = new BBCNewsPage(webDriver);
            bBCMainPage = new BBCMainPage(webDriver);
            haveYourSayPage = new HaveYourSayPage(webDriver);
            searchPage = new SearchPage(webDriver);
        }

        public void AskQuestion(string requestForm, string nameForm, string emailForm)
        {
            GoToQuestionForm();
            questionToBBCPage.FillTheForm(requestForm, nameForm, emailForm);
            questionToBBCPage.SubmitForm();
        }
        
        public void GoToNews()
        {
            bBCMainPage.GoToNews();
        }

        public IEnumerable<string> GetFirstNewsTitles()
        {
            return bBCNewsPage.GetArticleTitles();
        }

        public void SearchForFirstTagFromNews()
        {
            GoToNews();
            var keyWord = bBCNewsPage.GetKeyWord();
            bBCNewsPage.Search(keyWord);
            if (searchPage.GetSearchText() != keyWord)
            {
                throw new DllNotFoundException(SearchError);
            }
        }

        private void GoToQuestionForm()
        {
            GoToNews();
            bBCNewsPage.GoToHaveYourSay();
            haveYourSayPage.GoToDoYouHaveAQuestion();
        }     

        public void Dispose()
        {
            if (webDriver != null)
            {
                webDriver.Close();
            }
        }
    }
}
