using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Test_Automation_EPAM.BL;

namespace Test_Automation_EPAM
{
    [TestClass]
    public class SecondTaskBBCTests : BBCTestsBase
    {
        private const string _nameMissingErrorText = "Name can't be blank";
        private const string _emailMissingErrorText = "Email address can't be blank";
        private const string _formTextErrorText = "can't be blank";
        private BBCSiteFacade bBCSiteFacade;

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), _formTextErrorText)]
        public void SubmitingForm_EmptyForm_AllErrorsApeared()
        {          
            bBCSiteFacade.AskQuestion("", "", "", "", "");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), _nameMissingErrorText)]
        public void SubmitingForm_EmptyName_AllErrorsApeared()
        {
            bBCSiteFacade.AskQuestion("Some case", "", "masha@gmail.com", "", "");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), _emailMissingErrorText)]
        public void SubmitingForm_EmptyEmail_AllErrorsApeared()
        {
            bBCSiteFacade.AskQuestion("Some case", "Masha", "", "", "");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), _nameMissingErrorText)]
        public void SubmitingForm_BigForm_AllErrorsApeared()
        {
            const string bigText = "012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567891";
            bBCSiteFacade.AskQuestion(bigText, "", "masha@gmail.com", "", "");
        }
    }
}
