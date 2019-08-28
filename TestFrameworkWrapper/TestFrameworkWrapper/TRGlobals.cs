using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFrameworkWrapper
{
    public static class TRGlobals
    {
        public static string ConfigXmlPath
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory + "\\Configuration\\Config.xml";
            }
        }
        public static string TestdataPath
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory + "\\TestData\\";
            }
        }
        public static string SiteUrl
        {
            get;
            set;
        }

        [DefaultValue("Chrome")]
        public static string Browser { get; set; }
    }
}
