using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using MyRESTService.Endpoints;
using System.ServiceModel;

namespace WcfUnitTest
{
    [TestClass]    
    public class UnitTest1
    {
        [TestMethod]
        //[HostType("ASP.NET")]
        [AspNetDevelopmentServer("ProductService", @"D:\WORK\Shared\Wcf_Rest\MyRESTService\MyRESTService")]
        public void TestMethod1()
        {
            
        }
    }
}
