using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TestFrameworkWrapper
{
    public class Map
    {
        private Dictionary<string, object> _testData;
        private string TestScriptName = string.Empty;

        public Map()
        {
            ConfigDetail();
            this._testData = new Dictionary<string, object>();
        }
        public Map(string testScriptName)
        {
            ConfigDetail();
            this._testData = new Dictionary<string, object>();
            this.TestScriptName = testScriptName;
        }

        internal void ConfigDetail()
        {
            List<XElement> config = TRCommonUtilities.GetXElementFromXml(TRGlobals.ConfigXmlPath);
            
            TRGlobals.SiteUrl = config.Find(x => x.Name.ToString().Equals("SiteUrl", StringComparison.InvariantCultureIgnoreCase)).Value;
            TRGlobals.Browser = config.Find(x => x.Name.ToString().Equals("Browser", StringComparison.InvariantCultureIgnoreCase)).Value;
        }
        public void Put(string key, object value)
        {
            try
            {
                if (!this._testData.ContainsKey(key))
                {
                    if (key != string.Empty)
                    {
                        this._testData.Add(key, value);
                    }
                }
                else
                {
                    this._testData[key] = value;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool ContainsKey(string key)
        {
            return key != string.Empty && this._testData.ContainsKey(key);
        }
        public string Get(string key)
        {
            return this._testData.ContainsKey(key) ? this._testData[key].ToString() : string.Empty;
        }
        public object GetObject(string key)
        {
            return this._testData.ContainsKey(key) ? this._testData[key] : default(object);
        }
        public void RemoveKey(string key)
        {
            if (key != string.Empty)
            {
                this._testData.Remove(key);
            }
        }
        public void ClearMap()
        {
            this._testData.Clear();
        }
    }
}
