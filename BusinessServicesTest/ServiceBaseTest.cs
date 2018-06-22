using PKI.eBusiness.WMService.BusinessServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PKI.eBusiness.WMService.Entities;
using PKI.eBusiness.WMService.Entities.Orders;
using PKI.eBusiness.WMService.TestUtilities;

namespace PKI.eBusiness.WMService.BusinessServicesTest
{
    
    
    /// <summary>
    ///This is a test class for ServiceBaseTest and is intended
    ///to contain all ServiceBaseTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ServiceBaseTest
    {
        [TestMethod()]
        public void ServiceBaseConstructorTest()
        {
            try
            {
                ServiceBase<Order> orderService = new ServiceBase<Order>();                
                Assert.IsNotNull(orderService);
            }
            catch (Exception)
            {
                Assert.Fail();
            }            
        }

        [TestMethod()]
        public void GenerateObject()
        {
            string xml = Utilities.EXPECTED_SERVICE_RESPONSE;
            
            ServiceBase<OrderSubmissionResponse> target = new ServiceBase<OrderSubmissionResponse>();

            OrderSubmissionResponse expected = new OrderSubmissionResponse();
            expected.Code = 200;
            expected.Message = "order entered";
            OrderSubmissionResponse actual = target.GenerateObject(xml);

            bool equal = (expected.Code.Equals(actual.Code)) && (expected.Message.Equals(actual.Message));
            Assert.IsTrue(equal);
        }
    }
}
