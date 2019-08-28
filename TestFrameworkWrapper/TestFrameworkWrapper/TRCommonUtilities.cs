using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace TestFrameworkWrapper
{
    public static class TRCommonUtilities
    {
        public static dynamic GetXElementFromXml(string path, string nodeName = "")
        {
            List<XElement> result = new List<XElement>();
            List<KeyValuePair<string, object>> attributesValues = new List<KeyValuePair<string, object>>();
            try
            {
                using (XmlReader reader = XmlReader.Create(path))
                {
                    reader.MoveToContent();

                    while (reader.Read())
                    {
                        if (reader.MoveToContent() != XmlNodeType.Element)
                        {
                            reader.Read();
                            continue;
                        }

                            if (!reader.Name.Equals(nodeName, StringComparison.OrdinalIgnoreCase))
                            {
                                continue;
                            }

                            var element = (XElement)XNode.ReadFrom(reader);
                            if (!element.HasAttributes)
                            {
                                continue;
                            }

                            result.Add(element);
                    }

                    if (result.Count == 0)
                    {
                        result.Add(XElement.Parse("<Error>" + "No such node found in Xml" + "</Error>"));
                        return result;
                    }

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GetTimeStamp(string format = "yyMMddHHmmss")
        {
            try
            {
                return DateTime.Now.ToString(format);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
