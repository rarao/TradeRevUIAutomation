using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestFrameworkWrapper;

namespace TradeRevUtilities.POMs
{
    public class JobsPage : POMBase
    {
        private string TestCaseName { get; set; }
        public JobsPage(string tcName) : base(tcName, "")
        {
            this.TestCaseName = tcName;
        }
        private IWebElement ContentWrapper
        {
            get
            {
                this.WaitForElementLoad(By.ClassName("content-wrapper"));
                return this.Driver.FindElement(By.ClassName("content-wrapper"));
            }
        }
        private IWebElement FilterBar
        {
            get
            {
                return this.ContentWrapper.FindElement(By.ClassName("filter-bar"));
            }
        }
        private IWebElement PostingsWrapper
        {
            get
            {
                return this.ContentWrapper.FindElement(By.ClassName("postings-wrapper"));
            }
        }
        public IWebElement NoPostingsMessage
        {
            get
            {
                return this.ContentWrapper.FindElement(By.ClassName("no-postings-message"));
            }
        }
        
        public int FilterCount
        {
            get
            {
                return this.FilterBar.FindElements(By.ClassName("filter-button-wrapper")).Count;
            }
        }
        public FilterBy GetFilterByName(string name)
        {
            ReadOnlyCollection<IWebElement> webElements = this.FilterBar.FindElements(By.ClassName("filter-button-wrapper"));

            foreach (var webelement in webElements)
            {
                if (webelement.FindElement(By.ClassName("filter-button")).Text.ToLower().Equals(name.ToLower()))
                    return new FilterBy(webelement);
            }
            return null;
        }
        public List<JobPosting> GetJobPostings()
        {
            try
            {
                ReadOnlyCollection<IWebElement> webElements = this.PostingsWrapper.FindElements(By.ClassName("posting"));

                List<JobPosting> jobPostings = new List<JobPosting>();
                foreach (var webelement in webElements)
                {
                    jobPostings.Add(new JobPosting(webelement));
                }
                return jobPostings;
            }
            catch
            {
                return null;
            }
        }
    }
    public class FilterBy
    {
        private IWebElement element;
        public FilterBy(IWebElement ele)
        {
            element = ele;
        }
        private IWebElement FilterBtn
        {
            get
            {
                return this.element.FindElement(By.ClassName("filter-button"));
            }
        }
        private IWebElement FilterPopup
        {
            get
            {
                return this.element.FindElement(By.ClassName("filter-popup"));
            }
        }
        public string FilterName
        {
            get
            {
                return FilterBtn.Text;
            }
        }

        public void SetValue(string value)
        {
            FilterBtn.Click();

            ReadOnlyCollection<IWebElement> list = FilterPopup.FindElements(By.TagName("a"));

            foreach (var item in list)
            {
                if (item.Text.ToLower().Contains(value.ToLower()))
                {
                    item.Click();
                    break;
                }
            }
        }
    }
    public class JobPosting
    {
        private IWebElement element;
        public JobPosting(IWebElement ele)
        {
            element = ele;
        }
        public string Category
        {
            get
            {
                return this.element.FindElement(By.XPath("..")).FindElement(By.ClassName("posting-category-title")).Text;
            }
        }
        public string Title
        {
            get
            {
                return this.element.FindElement(By.TagName("h5")).Text;
            }
        }
        public string ApplyBtn
        {
            get
            {
                return this.element.FindElement(By.ClassName("posting-btn-submit")).Text;
            }
        }
        public string Location
        {
            get
            {
                return this.element.FindElement(By.ClassName("sort-by-location")).Text;
            }
        }
        public string Team
        {
            get
            {
                return this.element.FindElement(By.ClassName("sort-by-team")).Text;
            }
        }
        public string Commitment
        {
            get
            {
                return this.element.FindElement(By.ClassName("sort-by-commitment")).Text;
            }
        }
    }
}
