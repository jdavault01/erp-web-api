using System.Runtime.InteropServices.ComTypes;
using PKI.eBusiness.WMService.Entities.Stubs.StoreFront;
using PKI.eBusiness.WMService.ServiceGateways;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PKI.eBusiness.WMService.Entities.Stubs;
using Moq;
using PKI.eBusiness.WMService.TestUtilities;
using System.ServiceModel;
using OrderInfoWebServiceRequest = PKI.eBusiness.WMService.Entities.Stubs.StoreFront.OrderInfoWebServiceRequest;
using OrderInfoWebServiceResponse = PKI.eBusiness.WMService.Entities.Stubs.StoreFront.OrderInfoWebServiceResponse;
using PediatrixService = PKI.eBusiness.WMService.ServiceGatewContracts.WMService;
namespace PKI.eBusiness.WMService.ServiceGatewaysTest
{
    
    
    /// <summary>
    ///This is a test class for WebMethodClientTest and is intended
    ///to contain all WebMethodClientTest Unit Tests
    ///</summary>
    [TestClass()]
    public class WebMethodClientTest
    {
        private Mock<PediatrixService.ProcessPediatrixOrder_WSD_PortTypeClient> _soapClient;
        private Mock<StorefrontWebServices_PortType> _soapStoreFrontClient;

        /// <summary>
        ///A test for WebMethodClient Constructor
        ///</summary>
        [TestMethod()]
        public void WebMethodClientConstructorTest()
        {
            _soapClient = new Mock<PediatrixService.ProcessPediatrixOrder_WSD_PortTypeClient>();
            _soapStoreFrontClient = new Mock<StorefrontWebServices_PortType>();
            WebMethodClient target = new WebMethodClient(_soapClient.Object, _soapStoreFrontClient.Object);
        }

        internal virtual WebMethodClient CreateWebMethodClient()
        {
            // Instantiate an appropriate concrete class
            _soapClient = new Mock<PediatrixService.ProcessPediatrixOrder_WSD_PortTypeClient>();
            _soapStoreFrontClient = new Mock<StorefrontWebServices_PortType>();
            _soapClient.Setup<string>(o => o.ProcessPediatrixOrder(It.IsAny<PediatrixService.Pediatrix>())).Returns(Utilities.EXPECTED_SERVICE_RESPONSE);
            OrderInfoWebServiceRequest request = new OrderInfoWebServiceRequest();
            request.xmlRequest = "<?xml version='1.0' encoding='utf-16'?><!DOCTYPE OrderDetailRequest SYSTEM 'OrderDetailRequestInput.dtd'><OrderDetailRequest><Header><Version value='001'>001</Version><Sender><LogicalID>SF</LogicalID><Task>DisplayOrderDetail</Task></Sender></Header><Body><OrderDetailRequestHeader><SellerOrderID>30340503</SellerOrderID></OrderDetailRequestHeader></Body></OrderDetailRequest>";
            _soapStoreFrontClient.Setup<string>(o => o.OrderInfoWebService(request).xmlResponse).Returns(Utilities.GetOrderInfoWebServiceResponse().xmlResponse);
            return new WebMethodClient(_soapClient.Object, _soapStoreFrontClient.Object);
        }

        /// <summary>
        ///A test for ProcessOrderSubmission
        ///</summary>
        [TestMethod()]
        public void ProcessOrderSubmissionTest()
        {
            WebMethodClient target = CreateWebMethodClient();

            string expected = Utilities.EXPECTED_SERVICE_RESPONSE;
            
            string actual = target.ProcessOrderSubmission(Utilities.GetExamplePediatrix());

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ProcessOrderLookUpTest()
        {
            WebMethodClient target = CreateWebMethodClient();
            OrderInfoWebServiceResponse actual = null;
            OrderInfoWebServiceResponse expected = Utilities.GetOrderInfoWebServiceResponse();
            actual=target.ProcessOrderLookUpRequest(new OrderInfoWebServiceRequest());
            Assert.AreEqual(actual.xmlResponse,expected.xmlResponse);
        }
    }
}