using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestFrameworkWrapper;
using TestFrameworkWrapper.MSTest;
using TradeRevUtilities.Structures;

namespace TradeRevUITest.TestScripts
{
    [TestClass]
    public class CareersTests : TestBase
    {
        [WorkItem(1)]
        [Description("check whether Canada TradeRev career page is displayed properly")]
        [DataTestMethod]
        [TRDataSource]
        public void VerifyCareerPage(Map map)
        {            
            this.TRFuncUIUtilities.ValidateCareersPage(map);
            this.TRFuncUIUtilities.ValidateJobsite(map);
        }

        [WorkItem(2)]
        [Description("check whether job filter (city) is working properly")]
        [DataTestMethod]
        [TRDataSource]
        public void VerifyJobFilterCity(Map map)
        {
            this.TRFuncUIUtilities.NavigateTo(TradeRevURL.jobsite);
            this.TRFuncUIUtilities.FilterJobs(map);
            this.TRFuncUIUtilities.VerifyFilter(map);
        }

        [WorkItem(3)]
        [Description("check whether job filter (city) and (team) is working properly")]
        [DataTestMethod]
        [TRDataSource]
        public void VerifyJobFilterCityAndTeam(Map map)
        {
            this.TRFuncUIUtilities.NavigateTo(TradeRevURL.jobsite);
            this.TRFuncUIUtilities.FilterJobs(map);
            this.TRFuncUIUtilities.VerifyFilter(map);
            map.Put("JobFilter", "Toronto, Ontario, Canada!All#Engineering!All#work type!All");
            this.TRFuncUIUtilities.FilterJobs(map);
            this.TRFuncUIUtilities.RetrieveAvailablePositions(map);

            this.TestContext.WriteLine("Available positions are : " + map.Get("AvailablePositions").ToString());
        }
    }
}
