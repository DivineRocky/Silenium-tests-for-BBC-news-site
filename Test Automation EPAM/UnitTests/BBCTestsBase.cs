using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test_Automation_EPAM.BL;

namespace Test_Automation_EPAM
{
    [TestClass]
    public class BBCTestsBase
    {
        protected BBCSiteFacade bBCSiteFacade;

        [TestInitialize]
        public void Initialize()
        {
            bBCSiteFacade = new BBCSiteFacade();
        }

        [TestCleanup]
        public void CleanUp()
        {
            bBCSiteFacade.Dispose();
        }
    }
}
