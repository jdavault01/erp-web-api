using PKI.eBusiness.WMService.WMServiceLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;
using PKI.eBusiness.WMService.Entities.Orders;
using PKI.eBusiness.WMService.BusinessServices;
using PKI.eBusiness.WMService.BusinessServicesContracts;
using PKI.eBusiness.WMService.Utility;
using PKI.eBusiness.WMService.WMServiceLibrary;
using PKI.eBusiness.WMService.WMServiceLibraryContracts;


namespace PKI.eBusiness.WMService.WMServiceLibraryTest
{       
    /// <summary>
    ///This is a test class for IWMServiceTest and is intended
    ///to contain all IWMServiceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IWMServiceTest
    {
        private TestContext testContextInstance;
        private Mock<IOrderService> _orderService;        

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

        internal virtual IWMService CreateIWMService()
        { 
            // Instantiate an appropriate concrete class
            _orderService = new Mock<IOrderService>();
            _orderService.Setup<string>(o => o.ProcessSubmision(It.IsAny<Order>())).Returns(TestUtilities.EXPECTED_SERVICE_RESPONSE);
            
            return new WMService.WMServiceLibrary.WMService(_orderService.Object);
        }

        /// <summary>
        ///A test for ProcessOrderSubmission
        ///</summary>
        [TestMethod()]
        public void ProcessOrderSubmissionTest()
        {
            IWMService target = CreateIWMService();            

            string expected = TestUtilities.EXPECTED_SERVICE_RESPONSE;
            string actual = target.ProcessOrderSubmission((TestUtilities.GetMockOrder())); 
            
            Assert.AreEqual(expected, actual);
        }
    }
}