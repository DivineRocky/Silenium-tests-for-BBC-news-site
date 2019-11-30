﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;

namespace Test_Automation_EPAM.BL
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
            webDriver = new ChromeDriver();
            webDriver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 7);
            webDriver.Manage().Window.Maximize();
            questionToBBCPage = new DoYouHaveAQuestionToBBCPage(webDriver);
            bBCNewsPage = new BBCNewsPage(webDriver);
            bBCMainPage = new BBCMainPage(webDriver);
            haveYourSayPage = new HaveYourSayPage(webDriver);
            searchPage = new SearchPage(webDriver);
        }

        public void AskQuestion(string requestForm, string nameForm, string emailForm, string ageForm, string postcodeForm)
        {
            GoToQuestionForm();
            questionToBBCPage.FillTheForm(requestForm, nameForm, emailForm, ageForm, postcodeForm);
            questionToBBCPage.SubmitForm();
        }
        
        public void GoToNews()
        {
            bBCMainPage.GoToNews();
        }

        public IEnumerable<string> GetFirstNewsTitles()
        {
            GoToNews();
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
