using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFrameworkWrapper
{
    public class TRAssert
    {
        public static void Pass(string message = null)
        {
            if (message == null)
            {
                message = string.Empty;
            }

            Assert.IsTrue(true, message);
        }
        public static void Fail(string message = null)
        {
            if (message == null)
            {
                message = string.Empty;
            }

            Assert.Fail(message);
        }
        public static void Fail(string message = null ,Exception ex = null)
        {
            if (message == null)
            {
                message = string.Empty;
            }
            if (ex != null)
            {
                Assert.Fail(message + " Inner Exception : " + ex.Message + " StackTrace : " + ex.StackTrace);
            }
            else
            {
                Assert.Fail(message);
            }
            
        }
        public static void AreEqual(object expected, object actual,string message = null)
        {
            if (message == null)
            {
                message = string.Empty;
            }

            Assert.AreEqual(expected,actual,message);
        }
        public static void IsTrue(bool condition, string message = null)
        {
            if (message == null)
            {
                message = string.Empty;
            }

            Assert.IsTrue(condition, message);
        }
        public static void IsFalse(bool condition, string message = null)
        {
            if (message == null)
            {
                message = string.Empty;
            }

            Assert.IsFalse(condition, message);
        }
        public static void IsNotNull(object obj, string message = null)
        {
            if (message == null)
            {
                message = string.Empty;
            }

            Assert.IsNotNull(obj, message);
        }
        public static void IsNull(object obj, string message = null)
        {
            if (message == null)
            {
                message = string.Empty;
            }

            Assert.IsNull(obj, message);
        }
    }
}
