using PKI.eBusiness.WMService.BusinessServicesContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PKI.eBusiness.WMService.Entities.Stubs;
using PKI.eBusiness.WMService.Entities.Orders;
using PKI.eBusiness.WMService.ServiceGateways;
using PKI.eBusiness.WMService.ServiceGatewaysContracts;
using PKI.eBusiness.WMService.Utility;
using AutoMapper;
using Moq;

namespace PKI.eBusiness.WMService.BusinessServicesTest
{
    
    
    /// <summary>
    ///This is a test class for IOrderServiceTest and is intended
    ///to contain all IOrderServiceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IOrderServiceTest
    {        
        private TestContext testContextInstance;
        private Mock<IWebMethodClient> _webMethodClient;

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

        internal virtual IOrderService CreateIOrderService()
        {
            // Instantiate an appropriate concrete class
            _webMethodClient = new Mock<IWebMethodClient>();
            _webMethodClient.Setup<string>(o => o.ProcessOrderSubmission(It.IsAny<Pediatrix>())).Returns(TestUtilities.EXPECTED_SERVICE_RESPONSE);

            return new PKI.eBusiness.WMService.BusinessServices.OrderService(_webMethodClient.Object);
        }  

        /// <summary>
        ///A test for ProcessSubmision
        ///</summary>
        [TestMethod()]
        public void ProcessSubmisionTest()
        {
            // Initialize Order To Pediatrix Mapper which is used for OrderService objects
            Mapper.CreateMap<PKI.eBusiness.WMService.Entities.Orders.OrderRequestHeader, PKI.eBusiness.WMService.Entities.Stubs.OrderRequestHeader>();
            Mapper.CreateMap<PKI.eBusiness.WMService.Entities.Orders.OrderRequestDetail, PKI.eBusiness.WMService.Entities.Stubs.OrderRequestDetail>();
            Mapper.CreateMap<PKI.eBusiness.WMService.Entities.Orders.OrderRequest, PKI.eBusiness.WMService.Entities.Stubs.OrderRequest>();
            Mapper.CreateMap<PKI.eBusiness.WMService.Entities.Orders.Order, PKI.eBusiness.WMService.Entities.Stubs.Pediatrix>();

            IOrderService target = CreateIOrderService();

            string expected = TestUtilities.EXPECTED_SERVICE_RESPONSE;
            string actual = target.ProcessSubmision(TestUtilities.GetMockOrder());

            Assert.AreEqual(expected, actual);
        }
    }
}
