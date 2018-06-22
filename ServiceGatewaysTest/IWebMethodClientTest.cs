using PKI.eBusiness.WMService.ServiceGateways;
using PKI.eBusiness.WMService.ServiceGatewaysContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;
using PKI.eBusiness.WMService.Entities.Stubs;
using PKI.eBusiness.WMService.Utility;

namespace PKI.eBusiness.WMService.ServiceGatewaysTest
{
    /// <summary>
    ///This is a test class for IWebMethodClientTest and is intended
    ///to contain all IWebMethodClientTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IWebMethodClientTest
    {
        private TestContext testContextInstance;
        private Mock<IProcessPiedatirxOrder_PortTypeClient> _soapClient;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }


        internal virtual IWebMethodClient CreateIWebMethodClient()
        {
            // Instantiate an appropriate concrete class
            _soapClient = new Mock<IProcessPiedatirxOrder_PortTypeClient>();
            _soapClient.Setup<string>(o => o.ProcessPediatrixOrder(It.IsAny<Pediatrix>())).Returns(TestUtilities.EXPECTED_SERVICE_RESPONSE);

            return new WebMethodClient(_soapClient.Object);
        }

        

        /// <summary>
        ///A test for ProcessOrderSubmission
        ///</summary>
        [TestMethod()]
        public void ProcessOrderSubmissionTest()
        {
            IWebMethodClient target = CreateIWebMethodClient();

            string expected = TestUtilities.EXPECTED_SERVICE_RESPONSE;
            string actual = target.ProcessOrderSubmission(TestUtilities.GetMockPediatrix());

            Assert.AreEqual(expected, actual);
        }
    }
}