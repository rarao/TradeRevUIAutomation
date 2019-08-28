using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestFrameworkWrapper.Selenium;

namespace TestFrameworkWrapper
{
    //To be used for writting common things between POMs
    public class POMBase : SeleniumDriver
    {
        public POMBase(string testCaseName,string title) : base(testCaseName,title)
        {

        }
    }
}
