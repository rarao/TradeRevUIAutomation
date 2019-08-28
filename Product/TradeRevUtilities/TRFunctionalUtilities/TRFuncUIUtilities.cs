using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestFrameworkWrapper;
using TestFrameworkWrapper.Selenium;
using TradeRevUtilities.Utilities;

namespace TradeRevUtilities.TRFunctionalUtilities
{
    public class TRFuncUIUtilities
    {
        private string TestCaseName { get; set; }
        public TRFuncUIUtilities(string tcName)
        {
            this.TestCaseName = tcName;
        }
        public CareersPageUtility careersPageUtility
        {
            get
            {
                return new CareersPageUtility(TestCaseName);
            }
        }
        public HomePageUtility homePageUtility
        {
            get
            {
                return new HomePageUtility(TestCaseName);
            }
        }
        public JobsPageUtility jobsPageUtility
        {
            get
            {
                return new JobsPageUtility(TestCaseName);
            }
        }
        public void LaunchApplication()
        {
            try
            {
                TRBrowser.Instance.Close(this.TestCaseName);
                TRBrowser browser = TRBrowser.Instance;

                string url = TRGlobals.SiteUrl;
                BrowserType browserType = (BrowserType)Enum.Parse(typeof(BrowserType), TRGlobals.Browser);
                browser.Launch(url, this.TestCaseName, browserType, 60, 60);
            }
            catch (Exception ex)
            {
                TRAssert.Fail("Unable to launch application.", ex);
            }
        }
        public void CloseApplication()
        {
            TRBrowser.Instance.Close(this.TestCaseName);
        }
        public void ValidateCareersPage(Map map)
        {
            try
            {
                this.homePageUtility.NavigateAndSwitchToCareers();
                this.careersPageUtility.VerifyCareersPageSections();
            }
            catch (Exception ex)
            {
                TRAssert.Fail("Error while validating careers page", ex);
            }
        }
        public void ValidateJobsite(Map map)
        {
            try
            {
                if (!map.ContainsKey("NavigateToCareersPage") || Convert.ToBoolean(map.Get("NavigateToCareersPage")))
                    this.NavigateTo(Structures.TradeRevURL.careerspage);

                this.careersPageUtility.OpenAndSwitchToCanadianOpportunities();
                this.jobsPageUtility.VerifyJobSite();
            }
            catch (Exception ex)
            {
                TRAssert.Fail("Error while validating job site", ex);
            }
        }
        public void NavigateTo(string url)
        {
            try
            {
                this.homePageUtility.NavigateTo(url);
            }
            catch (Exception ex)
            {
                TRAssert.Fail("Error while navigating to page", ex);
            }
        }
        public void RetrieveAvailablePositions(Map map)
        {
            try
            {
                map.Put("AvailablePositions", this.jobsPageUtility.GetAvailableJobs());
            }
            catch (Exception ex)
            {
                TRAssert.Fail("Error while retrieving available positions", ex);
            }
        }
        public void FilterJobs(Map map)
        {
            try
            {
                string[] filter = map.Get("JobFilter").Split('#');

                for(int i=0;i<filter.Length;i++)
                {
                    string filterBy = filter[i].Split('!')[0];
                    string filterValue = filter[i].Split('!')[1];

                    this.jobsPageUtility.FilterJobs(filterBy, filterValue);
                }
            }
            catch (Exception ex)
            {
                TRAssert.Fail("Error while filtering jobs", ex);
            }
        }
        public void VerifyFilter(Map map)
        {
            try
            {
                string[] filter = map.Get("JobFilter").Split('#');

                for (int i = 0; i < filter.Length; i++)
                {
                    string filterBy = filter[i].Split('!')[0];
                    string filterValue = filter[i].Split('!')[1];

                    switch(filterBy.ToLower())
                    {
                        case "city":
                            this.jobsPageUtility.VerifyJobPostingCity(filterValue);
                            break;
                        case "team":
                            this.jobsPageUtility.VerifyJobPostingTeam(filterValue);
                            break;
                        case "worktype":
                            this.jobsPageUtility.VerifyJobPostingWorkType(filterValue);
                            break;
                    }                   
                }
            }
            catch (Exception ex)
            {
                TRAssert.Fail("Error while verifying job filters", ex);
            }
        }
    }
}
