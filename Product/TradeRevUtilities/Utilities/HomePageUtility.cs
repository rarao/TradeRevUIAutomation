using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestFrameworkWrapper;
using TradeRevUtilities.POMs;

namespace TradeRevUtilities.Utilities
{
    public class HomePageUtility
    {
        private string TestCaseName { get; set; }
        public HomePageUtility(string tcName)
        {
            this.TestCaseName = tcName;
        }

        public HomePage homePage
        {
            get
            {
                return new HomePage(TestCaseName);
            }
        }

        public void NavigateAndSwitchToCareers()
        {
            this.homePage.CareersButton.Click();

            this.homePage.SwitchToNewTab();
        }
        public void NavigateTo(string url)
        {
            try
            {
                this.homePage.NavigateTO(url);
            }
            catch (Exception ex)
            {
                TRAssert.Fail("Error while navigating to url", ex);
            }
        }
    }
}
