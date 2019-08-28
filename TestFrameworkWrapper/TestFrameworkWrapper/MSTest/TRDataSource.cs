using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using System.Xml.Linq;

namespace TestFrameworkWrapper.MSTest
{
    public class TRDataSource : Attribute, ITestDataSource
    {
        public IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
            yield return testData(methodInfo);
        }
        public string GetDisplayName(MethodInfo methodInfo, object[] data)
        {
            return null;
        }
        public object[] testData(MethodInfo methodInfo)
        {
            XDocument docXDocument = XDocument.Load(TRGlobals.TestdataPath + methodInfo.Name + ".xml");
            Map localMap = new Map(methodInfo.Name);
            foreach (var attribute in docXDocument.Descendants("TestCaseData"))
            {
                foreach (var node in attribute.Descendants().ToArray())
                {
                    localMap.Put(node.Name.ToString(), node.Value);
                }
            }
            
            return new object[] { localMap };
        }

    }

}
