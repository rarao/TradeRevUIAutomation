using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestFrameworkWrapper.Selenium
{
    public enum BrowserType
    {
        FireFox,
        Chrome,
        IE,
        Headless,
        Opera,
        Safari,
        Edge
    }

    //Singleton Class
    public class TRBrowser
    {
        private TRBrowser()
        {
        }

        public Dictionary<string, IWebDriver> drivers = new Dictionary<string, IWebDriver>();

        public static TRBrowser Instance
        {
            get
            {
                return Nested.instance;
            }
        }
        private class Nested
        {
            internal static readonly TRBrowser instance = new TRBrowser();
            static Nested()
            {
            }
        }
        public IWebDriver this[string tc]
        {
            get
            {
                if (drivers.ContainsKey(tc))
                {
                    return drivers[tc];
                }
                return null;
            }
        }
        public void Launch(string url, string tcName, BrowserType type = BrowserType.IE, int timeOut = 10, int implicitWait = 10)
        {
            IWebDriver driver = null;
            try
            {
                if (drivers.ContainsKey(tcName))
                {
                    throw new Exception("Browser instance already exist for testcase : " + tcName);
                }

                // Launch Browser and instantiate 
                driver = this.Launch(url, type);

                // Set wait and Timeout
                this.SetWaitAndTimeout(implicitWait, timeOut, driver);

                this.drivers.Add(tcName, driver);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        private IWebDriver Launch(string url, BrowserType type = BrowserType.IE)
        {
            IWebDriver webdriver = null;

            switch (type)
            {
                case BrowserType.Chrome:

                    ChromeOptions coptions = new ChromeOptions();

                    coptions.ToCapabilities();
                    webdriver = new ChromeDriver(coptions);
                    break;

                case BrowserType.FireFox:

                    FirefoxOptions foptions = new FirefoxOptions();

                    foptions.ToCapabilities();
                    webdriver = new FirefoxDriver(foptions);
                    break;

                case BrowserType.IE:

                    InternetExplorerOptions ieoptions = new InternetExplorerOptions();
                    ieoptions.ToCapabilities();
                    webdriver = new InternetExplorerDriver(ieoptions);

                    break;
            }

            Thread.Sleep(4000);

            return webdriver;
        }

        private void SetWaitAndTimeout(int wait, int timeOut, IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(wait);

            driver.Manage().Timeouts().PageLoad = (TimeSpan.FromSeconds(timeOut));

            driver.Manage().Window.Maximize();
        }

        public void Close(string tcName)
        {
            try
            {
                if (!this.drivers.ContainsKey(tcName) || this.drivers[tcName] == null)
                    return;

                this.drivers[tcName].Quit();
                this.drivers.Remove(tcName);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
