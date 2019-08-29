using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TestFrameworkWrapper.Selenium
{
    public abstract class SeleniumDriver
    {
        private IWebDriver driver;
        private string testCaseName;
        private string currentHandle = string.Empty;

        public IWebDriver Driver
        {
            get { return driver; }
        }
        public SeleniumDriver(string tcName, string title)
        {
            this.testCaseName = tcName;

            this.driver = TRBrowser.Instance[testCaseName];

            if (this.driver == null)
            {
                throw new Exception("Exception : Driver doesn't exist for test case : " + testCaseName + ". Please launch for the same");
            }
            this.currentHandle = this.driver.CurrentWindowHandle;
        }

        public void NavigateTO(string url)
        {
            try
            {
                this.driver.Navigate().GoToUrl(url);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void SwitchToWindow(string windowTitle)
        {
            try
            {
                var windowHandles = this.driver.WindowHandles;

                foreach (var handle in windowHandles)
                {
                    if (this.driver.SwitchTo().Window(handle).Title == windowTitle)
                    {
                        this.driver.SwitchTo().Window(handle);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void SwitchToNewTab()
        {
            try
            {
                string firstTabHandle = driver.CurrentWindowHandle;

                foreach (string handle in driver.WindowHandles)
                {
                    if (!handle.Equals(firstTabHandle))
                    {
                        driver.SwitchTo().Window(handle);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void SwitchToLatestTab()
        {
            try
            {
                string firstTabHandle = driver.CurrentWindowHandle;

                IReadOnlyCollection<string> handles = driver.WindowHandles;
                
                for(int i=handles.Count-1;i>=0;i++)
                {
                    if (!handles.ElementAt(i).Equals(firstTabHandle))
                    {
                        driver.SwitchTo().Window(handles.ElementAt(i));
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string GetTitle(bool newTab = false)
        {
            if (!newTab)
            {
                return this.driver.Title;
            }
            else
            {
                string firstTabHandle = driver.CurrentWindowHandle;

                // switch to the new tab
                foreach (string handle in driver.WindowHandles)
                {
                    if (!handle.Equals(firstTabHandle))
                    {
                        driver.SwitchTo().Window(handle);
                        break;
                    }
                }
                string title = driver.Title;
                driver.Close();
                driver.SwitchTo().Window(firstTabHandle);
                return title;
            }
        }
        public void WaitUntilElementIsvisible(By searchCondition, int timeoutInSeconds = 0)
        {
            try
            {
                if (timeoutInSeconds == 0)
                {
                    timeoutInSeconds = 30;
                }

                var wait = new WebDriverWait(this.driver, new TimeSpan(0, 0, timeoutInSeconds));
                wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(searchCondition));
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool WaitForElementLoad(By searchCondition, int waitInSeconds = 0)
        {
            bool found = false;
            try
            {
                if (waitInSeconds == 0)
                {
                    waitInSeconds = Convert.ToInt32(this.driver.Manage().Timeouts().ImplicitWait.TotalSeconds);
                }

                var wait = new WebDriverWait(this.driver, new TimeSpan(0, 0, waitInSeconds));

                wait.Until(ExpectedConditions.ElementToBeClickable(searchCondition));

                IWebElement element = driver.FindElement(searchCondition);

                if(element!=null)
                {
                    found = true;
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
            return found;
        }

        public void ScrollToElement(IWebElement element)
        {
            ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }
        public object ExecuteScript(string javascript, params object[] args)
        {
            try
            {
                var js = (IJavaScriptExecutor)this.driver;
                object result = js.ExecuteScript(javascript, args);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Refresh()
        {
            this.driver.Navigate().Refresh();
        }
        public void SwitchBack()
        {
            this.driver.SwitchTo().Window(this.currentHandle);
        }
    }
}
