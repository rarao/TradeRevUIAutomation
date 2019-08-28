using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestFrameworkWrapper;
using TradeRevUtilities.POMs;

namespace TradeRevUtilities.Utilities
{
    public class JobsPageUtility
    {
        private string TestCaseName { get; set; }
        public JobsPageUtility(string tcName)
        {
            this.TestCaseName = tcName;
        }

        public JobsPage jobsPage
        {
            get
            {
                return new JobsPage(TestCaseName);
            }
        }
        public void VerifyJobSite()
        {
            try
            {
                TRAssert.AreEqual(3, this.jobsPage.FilterCount, "Jobs filter count is not as expected.");
                TRAssert.IsNotNull(this.jobsPage.GetFilterByName("city"), "City filter is not present.");
                TRAssert.IsNotNull(this.jobsPage.GetFilterByName("team"), "team filter is not present.");
                TRAssert.IsNotNull(this.jobsPage.GetFilterByName("work type"), "work type is not present.");

                List<JobPosting> displayedJobs = this.jobsPage.GetJobPostings();

                if (displayedJobs == null)
                    TRAssert.IsNotNull(this.jobsPage.NoPostingsMessage, "No postings message is not displayed");
                else
                    TRAssert.Pass("Job postings are displayed");
            }
            catch (Exception ex)
            {
                TRAssert.Fail("Error while verifying job site", ex);
            }
        }
        public void FilterJobs(string by,string value)
        {
            try
            {
                FilterBy filter = this.jobsPage.GetFilterByName(by);
                filter.SetValue(value);
            }
            catch (Exception ex)
            {
                TRAssert.Fail("Error while filtering jobs by : " + by, ex);
            }
        }

        public void VerifyJobPostingCity(string city)
        {
            try
            {
                List<JobPosting> jobPostings = this.jobsPage.GetJobPostings();

                foreach (var job in jobPostings)
                {
                    TRAssert.AreEqual(city.ToLower(), job.Location.ToLower(), "city name not as per filter for job : " + job.Title);
                }
            }
            catch (Exception ex)
            {
                TRAssert.Fail("Error while verifying job posting city. ", ex);
            }
        }
        public void VerifyJobPostingTeam(string team)
        {
            try
            {
                List<JobPosting> jobPostings = this.jobsPage.GetJobPostings();

                foreach (var job in jobPostings)
                {                  
                    TRAssert.IsTrue(job.Team.ToLower().Contains(team.ToLower()), "team name not as per filter for job : " + job.Title);
                }
            }
            catch (Exception ex)
            {
                TRAssert.Fail("Error while verifying job posting team. ", ex);
            }
        }
        public void VerifyJobPostingWorkType(string worktype)
        {
            try
            {
                List<JobPosting> jobPostings = this.jobsPage.GetJobPostings();

                foreach (var job in jobPostings)
                {
                    TRAssert.IsTrue(job.Commitment.ToLower().Contains(worktype.ToLower()), "worktype not as per filter for job : " + job.Title);
                }
            }
            catch (Exception ex)
            {
                TRAssert.Fail("Error while verifying job posting worktype. ", ex);
            }
        }
        public int GetAvailableJobs()
        {
            try
            {
                List<JobPosting> jobPostings = this.jobsPage.GetJobPostings();

                return jobPostings == null ? 0 : jobPostings.Count;
            }
            catch (Exception ex)
            {
                TRAssert.Fail("Error while getting available job count. ", ex);
                return 0;
            }
        }
    }
}
