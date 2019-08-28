using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestFrameworkWrapper;
using System.Collections.ObjectModel;

namespace TradeRevUtilities.POMs
{
    public class HomePage : POMBase
    {
        public string TestCaseName { get; set; }
        public HomePage(string tcName):base(tcName,"")
        {
            this.TestCaseName = tcName;
        }
        public ReadOnlyCollection<IWebElement> NavigationItems
        {
            get
            {
                return this.Driver.FindElements(By.ClassName("nav-site__item"));               
            }
        }
        public IWebElement CareersButton
        {
            get
            {
                foreach(var navigationItem in NavigationItems)
                {
                    if (navigationItem.Text.Trim().Equals("Careers"))
                        return navigationItem;
                }
                return null;
            }
        }
    }
}
