using PKI.eBusiness.WMService.Entities.OrderLookUp.OrderDetails;
using PKI.eBusiness.WMService.WMServiceLibrary;
using PKI.eBusiness.WMService.WMServiceLibraryContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PKI.eBusiness.WMService.BusinessServicesContracts;
using PKI.eBusiness.WMService.BusinessServices;
using PKI.eBusiness.WMService.Entities.Orders;
using Moq;
using PKI.eBusiness.WMService.TestUtilities;
using System.Collections.Generic;
using PKI.eBusiness.WMService.Entities.OrderLookUp.BasicRequest;

using GeneticsContracts = PKI.eBusiness.WMService.BusinessServicesContracts;
using StoreFrontContracts = PKI.eBusiness.WMService.BusinessServicesContracts.StoreFront;

namespace PKI.eBusiness.WMService.WMServiceLibraryTest
{


    /// <summary>
    ///This is a test class for WMServiceTest and is intended
    ///to contain all WMServiceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class WMServiceTest
    {
        private Mock<IOrderService> _orderService;
        private Mock<StoreFrontContracts.IOrderService> _orderLookUpService;

        /// <summary>
        ///A test for WMService Constructor
        ///</summary>
        [TestMethod()]
        public void WMServiceConstructorTest()
        {
            _orderService = new Mock<IOrderService>();
            _orderLookUpService = new Mock<StoreFrontContracts.IOrderService>();
            WMServiceLibrary.WMService target = new WMServiceLibrary.WMService(_orderService.Object,_orderLookUpService.Object);
        }

        internal virtual WMServiceLibrary.WMService CreateWMService()
        {
            // Instantiate an appropriate concrete class
            _orderService = new Mock<IOrderService>();
            _orderLookUpService = new Mock<StoreFrontContracts.IOrderService>();
         

            _orderService.Setup<OrderSubmissionResponse>(o => o.ProcessSubmision(It.IsAny<Order>())).Returns(Utilities.GetSampleResponse());
            _orderService.Setup(o => o.Log(It.IsAny<string>())).Verifiable();
            _orderService.Setup(o => o.UpdateOrderStatus(It.IsAny<string>())).Verifiable();


            return new WMService.WMServiceLibrary.WMService(_orderService.Object,_orderLookUpService.Object);
        }

        /// <summary>
        ///A test for ProcessOrderSubmission
        ///</summary>
        [TestMethod()]
        public void ProcessOrderSubmissionTest()
        {
            WMServiceLibrary.WMService target = CreateWMService();

            OrderSubmissionResponse expected = new OrderSubmissionResponse();
            expected.Code = 200;
            expected.Message = "order entered";
            OrderSubmissionResponse actual = target.ProcessOrderSubmission(Utilities.GetExampleOrder());

            bool equal = (expected.Code.Equals(actual.Code)) && (expected.Message.Equals(actual.Message));
            Assert.IsTrue(equal);
        }
        /// <summary>
        ///A test for ProcessOrderSubmission
        ///</summary>
        [TestMethod()]
        public void ProcessOrderSubmissionTestWithNullOrder()
        {
            WMServiceLibrary.WMService target = CreateWMService();

            OrderSubmissionResponse expected = new OrderSubmissionResponse();
            expected.Code = 200;
            expected.Message = "order entered";
            Order order = null;
            OrderSubmissionResponse actual = target.ProcessOrderSubmission(order);


            Assert.AreEqual(null, actual.Message);
        }
        [TestMethod()]
        public void ProcessOrderSubmissionTestWithFailResponse()
        {
            var mock = new Mock<IOrderService>();
            var lookUpMock = new Mock<StoreFrontContracts.IOrderService>();

            OrderSubmissionResponse expected = new OrderSubmissionResponse();
            expected.Code = 100;
            expected.Message = "order entered";

            WMService.WMServiceLibrary.WMService target = new WMService.WMServiceLibrary.WMService(mock.Object,lookUpMock.Object);
            mock.Setup<OrderSubmissionResponse>(o => o.ProcessSubmision(It.IsAny<Order>())).Returns(expected);
            mock.Setup(o => o.Log(It.IsAny<string>())).Verifiable();
            OrderSubmissionResponse actual = target.ProcessOrderSubmission(Utilities.GetExampleOrder());

            Assert.AreEqual(100, actual.Code);
        }

        /// <summary>
        ///A test for ProcessMultipleOrderSubmission
        ///</summary>
        [TestMethod()]
        public void ProcessMultipleOrderSubmissionTest()
        {
            WMServiceLibrary.WMService target = CreateWMService();

            List<Order> orders = new List<Order>();
            Order order = new Order();
            OrderRequest request = new OrderRequest();
            OrderRequestHeader header = new OrderRequestHeader();
            header.OrderID = "2001345";
            request.OrderRequestHeader = header;
            order.OrderRequest = request;
            orders.Add(order);

            // TODO: Initialize to an appropriate value
            target.ProcessMultipleOrderSubmission(orders);

        }
        [TestMethod()]
        public void GetOrderTest()
        {
            OrderLookUpResponse actual=null;
            WMServiceLibrary.WMService target = CreateWMService();

            OrderLookUpResponse expected = Utilities.GetLookUpResponse();
           
            _orderLookUpService.Setup<OrderLookUpResponse>(o => o.GetOrders(It.IsAny<OrderLookUpRequest>())).Returns(Utilities.GetLookUpResponse());
          
            actual=target.GetOrders(new OrderLookUpRequest());

            Assert.AreEqual(actual.OrderList[0].SAPOrderNum,expected.OrderList[0].SAPOrderNum);
            
        }
        [TestMethod()]
        public void GetOrderDetailTest()
        {
            OrderDetailResponse actual = null;
            WMServiceLibrary.WMService target = CreateWMService();

            OrderDetailResponse expected = Utilities.GetDetailResponse();

            _orderLookUpService.Setup<OrderDetailResponse>(o => o.GetOrderDetails(It.IsAny<string>())).Returns(Utilities.GetDetailResponse());

            actual = target.GetOrderDetails("test");

            Assert.AreEqual(actual.OrderType,expected.OrderType);

        }

     
    }
}
