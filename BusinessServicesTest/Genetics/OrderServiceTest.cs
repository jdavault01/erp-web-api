using PKI.eBusiness.WMService.BusinessServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PKI.eBusiness.WMService.ServiceGatewaysContracts;
using PKI.eBusiness.WMService.ServiceGateways;
using PKI.eBusiness.WMService.Entities.Orders;
using PKI.eBusiness.WMService.Entities.Stubs;
using PKI.eBusiness.WMService.TestUtilities;
using Moq;
using AutoMapper;
using Microsoft.Practices.Unity;
using PKI.eBusiness.WMService.Utility;
using PKI.eBusiness.WMService.DAL;
using PediatrixService = PKI.eBusiness.WMService.ServiceGatewContracts.WMService;
namespace PKI.eBusiness.WMService.BusinessServicesTest
{
    /// <summary>
    ///This is a test class for OrderServiceTest and is intended
    ///to contain all OrderServiceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class OrderServiceTest
    {
        private Mock<IWebMethodClient> _webMethodClient;
        private Mock<IOrderDAL> _orderDAL;

        /// <summary>
        ///A test for OrderService Constructor
        ///</summary>
        [TestMethod()]
        public void OrderServiceConstructorTest()
        {
            _webMethodClient = new Mock<IWebMethodClient>();
            _orderDAL = new Mock<IOrderDAL>();
            OrderService target = new OrderService(_webMethodClient.Object, _orderDAL.Object);
        }

        internal virtual OrderService CreateOrderService()
        {
            // Instantiate an appropriate concrete class
            _webMethodClient = new Mock<IWebMethodClient>();
            _orderDAL = new Mock<IOrderDAL>();

            _webMethodClient.Setup<string>(o => o.ProcessOrderSubmission(It.IsAny<PediatrixService.Pediatrix>())).Returns(Utilities.EXPECTED_SERVICE_RESPONSE);
            _orderDAL.Setup(foo => foo.UpdateOrderStatus(It.IsAny<string>(), It.IsAny<int>())).Verifiable();

            return new OrderService(_webMethodClient.Object, _orderDAL.Object);
        }

        /// <summary>
        ///A test for ProcessSubmision
        ///</summary>
        [TestMethod()]
        public void ProcessSubmisionTest()
        {
            // Initialize Order To Pediatrix Mapper which is used for OrderService objects
            Mapper.CreateMap<PKI.eBusiness.WMService.Entities.Orders.OrderRequestHeader, OrderRequestHeader>();
            Mapper.CreateMap<PKI.eBusiness.WMService.Entities.Orders.OrderRequestDetail, OrderRequestDetail>();
            Mapper.CreateMap<PKI.eBusiness.WMService.Entities.Orders.OrderRequest, OrderRequest>();
            Mapper.CreateMap<PKI.eBusiness.WMService.Entities.Orders.Order,PediatrixService.Pediatrix>();

            OrderService target = CreateOrderService();

            string expected = Utilities.EXPECTED_SERVICE_RESPONSE;
            OrderSubmissionResponse response = target.ProcessSubmision(Utilities.GetExampleOrder());

            Assert.AreEqual("order entered", response.Message);
        }

        /// <summary>
        ///A test for UpdateOrderStatus
        ///</summary>
        [TestMethod()]
        public void UpdateOrderStatusTest()
        {
            OrderService target = CreateOrderService();

            string orderNumber = "435"; // TODO: Initialize to an appropriate value
            target.UpdateOrderStatus(orderNumber);

        }


    }
}
