using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Test_Automation_EPAM
{
    [TestClass]
    public class SecondTaskBBCTests : BBCTestsBase
    {
        private readonly string _nameMissingErrorText = "Name can't be blank";
        private readonly string _emailMissingErrorText = "Email address can't be blank";
        private readonly string _formTextErrorText = "can't be blank";

        [TestMethod]
        public void SubmitingForm_EmptyForm_AllErrorsApeared()
        {
            //Arrange
            GoToNews();
            BBCNewsPage BBCNewsPage = new BBCNewsPage(_driver);
            BBCNewsPage.GoToHaveYourSay();
            HaveYourSayPage HaveYourSayPage = new HaveYourSayPage(_driver);
            HaveYourSayPage.GoToDoYouHaveAQuestion();
            DoYouHaveAQuestionToBBCPage DoYouHaveQuestionsToBBCPage = new DoYouHaveAQuestionToBBCPage(_driver);
            
            //Act
            DoYouHaveQuestionsToBBCPage.FillTheForm("", "", "", "", "");
            DoYouHaveQuestionsToBBCPage.SubmitForm();

            //Assert
            var errors = DoYouHaveQuestionsToBBCPage.GetErrors();
            Assert.IsTrue(errors.Any());
            Assert.IsTrue(errors.Contains(_emailMissingErrorText));
            Assert.IsTrue(errors.Contains(_nameMissingErrorText));
            Assert.IsTrue(errors.Contains(_formTextErrorText));
        }

        [TestMethod]
        public void SubmitingForm_EmptyName_AllErrorsApeared()
        {
            //Arrange
            GoToNews();
            BBCNewsPage BBCNewsPage = new BBCNewsPage(_driver);
            BBCNewsPage.GoToHaveYourSay();
            HaveYourSayPage HaveYourSayPage = new HaveYourSayPage(_driver);
            HaveYourSayPage.GoToDoYouHaveAQuestion();
            DoYouHaveAQuestionToBBCPage DoYouHaveQuestionsToBBCPage = new DoYouHaveAQuestionToBBCPage(_driver);

            //Act
            DoYouHaveQuestionsToBBCPage.FillTheForm("Some case", "", "masha@gmail.com", "", "");
            DoYouHaveQuestionsToBBCPage.SubmitForm();

            //Assert
            var errors = DoYouHaveQuestionsToBBCPage.GetErrors();
            Assert.AreEqual(1, errors.Count());
            Assert.IsTrue(errors.Contains(_nameMissingErrorText));
        }

        [TestMethod]
        public void SubmitingForm_EmptyEmail_AllErrorsApeared()
        {
            //Arrange
            GoToNews();
            BBCNewsPage BBCNewsPage = new BBCNewsPage(_driver);
            BBCNewsPage.GoToHaveYourSay();
            HaveYourSayPage HaveYourSayPage = new HaveYourSayPage(_driver);
            HaveYourSayPage.GoToDoYouHaveAQuestion();
            DoYouHaveAQuestionToBBCPage DoYouHaveQuestionsToBBCPage = new DoYouHaveAQuestionToBBCPage(_driver);

            //Act
            DoYouHaveQuestionsToBBCPage.FillTheForm("Some case", "Masha", "", "", "");
            DoYouHaveQuestionsToBBCPage.SubmitForm();

            //Assert
            var errors = DoYouHaveQuestionsToBBCPage.GetErrors();
            Assert.AreEqual(1, errors.Count());
            Assert.IsTrue(errors.Contains(_emailMissingErrorText));
        }

        [TestMethod]
        public void SubmitingForm_BigForm_AllErrorsApeared()
        {
            //Arrange
            GoToNews();
            BBCNewsPage BBCNewsPage = new BBCNewsPage(_driver);
            BBCNewsPage.GoToHaveYourSay();
            HaveYourSayPage HaveYourSayPage = new HaveYourSayPage(_driver);
            HaveYourSayPage.GoToDoYouHaveAQuestion();
            DoYouHaveAQuestionToBBCPage DoYouHaveQuestionsToBBCPage = new DoYouHaveAQuestionToBBCPage(_driver);

            //Act
            const string bigText = "012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567891";
            DoYouHaveQuestionsToBBCPage.FillTheForm(bigText, "", "masha@gmail.com", "", "");
            DoYouHaveQuestionsToBBCPage.SubmitForm();

            //Assert
            var errors = DoYouHaveQuestionsToBBCPage.GetErrors();
            var formText = DoYouHaveQuestionsToBBCPage.GetFormText();
            Assert.IsTrue(bigText.Contains(formText));
            Assert.AreEqual(DoYouHaveAQuestionToBBCPage.MaxFormLength, formText.Length);
            Assert.IsTrue(bigText.Length > formText.Length);
        }
    }
}
