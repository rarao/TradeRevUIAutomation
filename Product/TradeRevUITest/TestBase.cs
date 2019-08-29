using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestFrameworkWrapper;
using TestFrameworkWrapper.MSTest;
using TradeRevUtilities.TRFunctionalUtilities;

namespace TradeRevUITest
{
    [TestClass]
    public class TestBase : AutomationTestBase
    {
        private TRFuncUIUtilities _TRFuncUIUtilities;
        public TRFuncUIUtilities TRFuncUIUtilities
        {
            get
            {
                if (_TRFuncUIUtilities == null)
                {
                    _TRFuncUIUtilities = new TRFuncUIUtilities(TestContext.FullyQualifiedTestClassName + "_" + TestContext.TestName);

                }
                return _TRFuncUIUtilities;
            }
        }

        [AssemblyInitialize()]
        public static void BeforeSuite(TestContext testContext)
        {

        }

        [TestInitialize()]
        public void BeforeTest()
        {
            TRFuncUIUtilities.LaunchApplication();
        }

        [TestCleanup()]
        public void AfterTest()
        {
            TRFuncUIUtilities.CloseApplication();
        }

        [AssemblyCleanup()]
        public static void AfterSuite()
        {

        }
    }
}
