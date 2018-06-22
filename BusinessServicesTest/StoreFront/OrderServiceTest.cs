using Moq;
using PKI.eBusiness.WMService.BusinessServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PKI.eBusiness.WMService.BusinessServicesContracts;
using PKI.eBusiness.WMService.Entities.OrderLookUp.OrderDetails;
using PKI.eBusiness.WMService.Entities.Stubs;
using PKI.eBusiness.WMService.Entities.Stubs.StoreFront;
using PKI.eBusiness.WMService.ServiceGatewaysContracts;
using PKI.eBusiness.WMService.Entities.OrderLookUp.BasicRequest;
using PKI.eBusiness.WMService.TestUtilities;
using GeneticsSerivces = PKI.eBusiness.WMService.BusinessServices;
using StoreFrontServices = PKI.eBusiness.WMService.BusinessServices.StoreFront;
using GeneticsContracts = PKI.eBusiness.WMService.BusinessServicesContracts;
using StoreFrontContracts = PKI.eBusiness.WMService.BusinessServicesContracts.StoreFront;

namespace PKI.eBusiness.WMService.BusinessServicesTest.StoreFront
{
    /// <summary>
    ///This is a test class for SAPOrderServiceTest and is intended
    ///to contain all SAPOrderServiceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class OrderServiceTest
    {
        private TestContext testContextInstance;
        private Mock<IWebMethodClient> _webMethodClient;
        private Mock<IWebMethodClient> _webMethodDetailClient;

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

        internal virtual StoreFrontServices.OrderService CreateOrderService()
        {
            // Instantiate an appropriate concrete class
            _webMethodClient = new Mock<IWebMethodClient>();
            _webMethodClient.Setup<OrderInfoWebServiceResponse>(o => o.ProcessOrderLookUpRequest(It.IsAny<OrderInfoWebServiceRequest>())).Returns(Utilities.GetOrderInfoWebServiceResponse());
            return new StoreFrontServices.OrderService(_webMethodClient.Object);
        }

        internal virtual StoreFrontServices.OrderService CreateDetailOrderService()
        {
            _webMethodDetailClient = new Mock<IWebMethodClient>();
            _webMethodDetailClient.Setup<OrderInfoWebServiceResponse>(o => o.ProcessOrderLookUpRequest(It.IsAny<OrderInfoWebServiceRequest>())).Returns(Utilities.GetDetailedOrderInfoWebServiceResponse());
            return new StoreFrontServices.OrderService(_webMethodDetailClient.Object);
          
        }
        /// <summary>
        ///A test for GetOrders
        ///</summary>
        [TestMethod()]
        public void GetOrdersTest()
        {
            StoreFrontContracts.IOrderService target = CreateOrderService(); // TODO: Initialize to an appropriate value
            OrderLookUpRequest request = new OrderLookUpRequest(); // TODO: Initialize to an appropriate value
            OrderLookUpResponse expected =Utilities.GetLookUpResponse(); // TODO: Initialize to an appropriate value
            OrderLookUpResponse actual;
            actual = target.GetOrders(request);
            Assert.AreEqual(expected.OrderList[0].SAPOrderNum, actual.OrderList[0].SAPOrderNum);
        }

        [TestMethod]
        public void GetOrderDetailsTest()
        {
            StoreFrontContracts.IOrderService target = CreateDetailOrderService();
            OrderDetailRequest request=new OrderDetailRequest();
            OrderDetailResponse expected = Utilities.GetDetailResponse();
            OrderDetailResponse actual = target.GetOrderDetails("");
            Assert.AreEqual(actual.OrderType,expected.OrderType);
        }
    }
}
