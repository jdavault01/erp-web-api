using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PKI.eBusiness.WMService.Entities;
using PKI.eBusiness.WMService.Entities.OrderLookUp.BasicRequest;
using PKI.eBusiness.WMService.Entities.OrderLookUp.OrderDetails;
using PKI.eBusiness.WMService.Entities.StoreFront.DataObjects;
using PKI.eBusiness.WMService.Logger;
using PKI.eBusiness.WMService.ServiceGatewaysContracts;
using PKI.eBusiness.WMService.BusinessServicesContracts.StoreFront;
using PKI.eBusiness.WMService.Entities.Stubs.StoreFront;
using PKI.eBusiness.WMService.Utility;
using InventoryRequest = PKI.eBusiness.WMService.Entities.StoreFront.DataObjects.InventoryRequest;
using InventoryResponse = PKI.eBusiness.WMService.Entities.StoreFront.DataObjects.InventoryResponse;


namespace PKI.eBusiness.WMService.BusinessServices.StoreFront
{
    /// <summary>
    /// This is the service for SAP order look up
    /// </summary>
    public class OrderService : IOrderService
    {
        private readonly IPublisher _publisher = PublisherManager.Instance;
        private readonly IWebMethodClient _webMethodClient;
        
        /// <summary>
        /// Class Constructor used for dependency injection
        /// </summary>
        /// <param name="webMethodClient"></param>
        public OrderService(IWebMethodClient webMethodClient)
        {
            _webMethodClient = webMethodClient;

        }
        /// <summary>
        /// This method gets orders for a given lookup request
        /// </summary>
        /// <param name="request">request</param>
        /// <returns>OrderLookUpResponse</returns>
        public OrderLookUpResponse GetOrders(OrderLookUpRequest request)
        {
            Log(ErrorMessages.SEND_DATA_INPUT_REQUEST);
            var summaryRequest = request.ToWmLookUpRequest();
            var xmlRequest = summaryRequest.SerializeToXml(Constants.ORDER_SUMMARY_REQUEST_ELEMENT,Constants.DTD_SUMMARY_REQUEST_SYSID,false);
            Log(xmlRequest.Replace("\r\n", ""));
            Log(ErrorMessages.INVOKING_SERVICE);
            var webServiceRequest = new OrderInfoWebServiceRequest {xmlRequest = xmlRequest};
            var webServiceResponse = _webMethodClient.ProcessOrderLookUpRequest(webServiceRequest);
            Log(webServiceResponse.xmlResponse);
            return webServiceResponse.ToOrderLookUpResponse();
            
        }
        /// <summary>
        /// This method gets order details for a given logicalId and orderId
        /// </summary>
        /// <param name="logicalId">logicalId</param>
        /// <param name="orderId">orderId</param>
        /// <returns>OrderDetailResponse</returns>
        public OrderDetailResponse GetOrderDetails(string orderId)
        {
            Log(ErrorMessages.SEND_DATA_INPUT_REQUEST);
            var detailRequest = new OrderDetailRequest(Constants.LOGICAL_ID, orderId);
            var webServiceRequest = new OrderInfoWebServiceRequest
            {
                xmlRequest = detailRequest.SerializeToXml(Constants.ORDER_DETAIL_REQUEST_ELEMENT,
                    Constants.DTD_DETAIL_REQUEST_SYSID, false)
            };

            Log(webServiceRequest.xmlRequest.Replace("\r\n", ""));
            Log(ErrorMessages.INVOKING_SERVICE);
            var webServiceResponse = _webMethodClient.ProcessOrderLookUpRequest(webServiceRequest);
            Log(webServiceResponse.xmlResponse);
            return webServiceResponse.ToOrderDetailResponse();
            
        }

        /// <summary>
        /// This method takes a client simulate order request model and calls the ERPGateway
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public SimulateOrderResponse SimulateOrder(SimulateOrderRequest request)
        {
            return _webMethodClient.SimulateOrder(request);

        }

        /// <summary>
        /// This method takes a client simulate order request model and calls the ERPGateway
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public CreateOrderResponse CreateOrder(CreateOrderRequest request)
        {
            return _webMethodClient.CreateOrder(request);

        }

        /// <summary>
        /// This method takes a client inventory request model and converts, makes calls and converts response
        /// back to client side model
        /// </summary>
        /// <param name="inventoryRequest"></param>
        /// <returns></returns>
        public InventoryResponse GetInventory(InventoryRequest inventoryRequest)
        {
            return _webMethodClient.GetInventory(inventoryRequest);
        }

        /// <summary>
        /// This method will log message to log file
        /// </summary>
        /// <param name="message">message</param>
        private void Log(string message)
        {
            _publisher.PublishMessage(message, System.Diagnostics.TraceLevel.Info, Constants.LOG_AREA);
        }

    }
}
