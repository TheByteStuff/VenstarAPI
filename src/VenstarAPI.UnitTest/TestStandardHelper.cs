using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Net;

using com.thebytestuff.VenstarAPI;

namespace VenstarAPI.UnitTest
{
    [TestClass]
    public class TestStandardHelper
    {
        private static string localHost = "127.0.0.1";
        private const int Port = 8080;
        private static string WebServer = String.Format("http://{0}:{1}/", localHost, Port);
        private static string VenstarClient = String.Format("http://{0}:{1}", localHost, Port);

        [ClassInitialize]
        //Runs once 
        public static void SuiteSetUp(TestContext context)
        {
           WebService.StartWebServer(@"TestData/ApiReplies.txt", WebServer);

        }

        [ClassCleanup]
        //Runs once 
        public static void SuiteTearDown()
        {
            WebService.StopWebServer();
        }


        [TestMethod]
        public void TestUnsecure_GetThermostatBaseInfo()
        {
            VenstarAPIHelper helper = VenstarAPIHelper.CreateHelper(VenstarClient);
            BaseTests.Test_GetThermostatBaseInfo(helper);
        }

        [TestMethod]
        public void TestUnsecure_GetThermostatDetailInfo()
        {
            VenstarAPIHelper helper = VenstarAPIHelper.CreateHelper(VenstarClient);
            BaseTests.Test_GetThermostatDetailInfo(helper);
        }

        [TestMethod]
        public void TestUnsecure_GetAlerts()
        {
            VenstarAPIHelper helper = VenstarAPIHelper.CreateHelper(VenstarClient);
            BaseTests.Test_GetAlerts(helper);
        }

        [TestMethod]
        public void TestUnsecure_GetRuntimes()
        {
            VenstarAPIHelper helper = VenstarAPIHelper.CreateHelper(VenstarClient);
            BaseTests.Test_GetRuntimes(helper);
        }

        [TestMethod]
        public void TestUnsecure_GetSensors()
        {
            VenstarAPIHelper helper = VenstarAPIHelper.CreateHelper(VenstarClient);
            BaseTests.Test_GetSensors(helper);
        }

        [TestMethod]
        public void TestUnsecure_Update()
        {
            VenstarAPIHelper helper = VenstarAPIHelper.CreateHelper(VenstarClient);
            BaseTests.Test_Update(helper);
        }

    }
}
