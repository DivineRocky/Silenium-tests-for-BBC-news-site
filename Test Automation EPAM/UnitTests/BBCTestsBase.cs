using BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
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
