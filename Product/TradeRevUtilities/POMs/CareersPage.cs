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
    public class CareersPage : POMBase
    {
        private string TestCaseName { get; set; }
        public CareersPage(string tcName):base(tcName,"")
        {
            this.TestCaseName = tcName;
        }
        private IWebElement ContentArea
        {
            get
            {
                this.WaitForElementLoad(By.ClassName("content-area"));
                return this.Driver.FindElement(By.ClassName("content-area"));
            }
        }
        public ReadOnlyCollection<IWebElement> Sections
        {
            get
            {
                return this.ContentArea.FindElements(By.TagName("section"));
            }
        }
        public IWebElement CallOutSection
        {
            get
            {
                return Sections[0];
            }
        }
        public IWebElement VideoSection
        {
            get
            {
                return Sections[2];
            }
        }
        public IWebElement SliderSection
        {
            get
            {
                return Sections[5];
            }
        }
        public IWebElement CanadianOpportunitiesBtn
        {
            get
            {
                return Sections[3].FindElement(By.ClassName("job-links__button--ca"));
            }
        }
    }
}
