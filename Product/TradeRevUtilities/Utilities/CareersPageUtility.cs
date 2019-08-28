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
    public class CareersPageUtility
    {
        private string TestCaseName { get; set; }
        public CareersPageUtility(string tcName)
        {
            this.TestCaseName = tcName;
        }

        public CareersPage careersPage
        {
            get
            {
                return new CareersPage(TestCaseName);
            }
        }

        public void VerifyCareersPageSections()
        {
            try
            {
                TRAssert.AreEqual(8, this.careersPage.Sections.Count, "Number of sections are wrong");

                TRAssert.IsTrue(this.careersPage.CallOutSection.GetAttribute("class").Contains("callout"), "Callout section is not present at the top");
                TRAssert.IsNotNull(this.careersPage.VideoSection.FindElement(By.ClassName("video")), "Video section doesnot have a video");
                TRAssert.IsNotNull(this.careersPage.CallOutSection.FindElement(By.ClassName("supsystic-slider")), "Slider not present in the slider section");

                TRAssert.IsNotNull(this.careersPage.Sections[1].FindElement(By.ClassName("section-title")), "2nd Section is a TextSection but doesnot have a title");
                TRAssert.IsNotNull(this.careersPage.Sections[3].FindElement(By.ClassName("section-title")), "4th Section is a TextSection but doesnot have a title");
                TRAssert.IsNotNull(this.careersPage.Sections[4].FindElement(By.ClassName("section-title")), "5th Section is a TextSection but doesnot have a title");
                TRAssert.IsNotNull(this.careersPage.Sections[6].FindElement(By.ClassName("section-title")), "7th Section is a TextSection but doesnot have a title");
                TRAssert.IsNotNull(this.careersPage.Sections[7].FindElement(By.ClassName("section-title")), "8th Section is a TextSection but doesnot have a title");
            }
            catch(Exception ex)
            {
                TRAssert.Fail("Error while Verifying Careers Page Sections.", ex);
            }
        }
        public void OpenAndSwitchToCanadianOpportunities()
        {
            try
            {
                this.careersPage.CanadianOpportunitiesBtn.Click();
                this.careersPage.SwitchToNewTab();
            }
            catch (Exception ex)
            {
                TRAssert.Fail("Error while opening or switching to Canadian opportunities", ex);
            }
        }
        
    }
}
