using Pki.eBusiness.ErpApi.Contract.BL;
using Pki.eBusiness.ErpApi.Contract.DAL;
using Pki.eBusiness.ErpApi.Entities.Constants;
using Pki.eBusiness.ErpApi.Entities.DataObjects;
using Pki.eBusiness.ErpApi.Entities.Extensions;
using Pki.eBusiness.ErpApi.Entities.OrderLookUp.BasicRequest;
using Pki.eBusiness.ErpApi.Entities.OrderLookUp.OrderDetails;
using Pki.eBusiness.ErpApi.Entities.Orders;
using Pki.eBusiness.ErpApi.Logger;
using InventoryRequest = Pki.eBusiness.ErpApi.Entities.DataObjects.InventoryRequest;
using InventoryResponse = Pki.eBusiness.ErpApi.Entities.DataObjects.InventoryResponse;


namespace Pki.eBusiness.ErpApi.Business.Services
{
    /// <summary>
    /// This is the service for SAP order look up
    /// </summary>
    public class OrderService : IOrderService
    {
        private readonly IPublisher _publisher = PublisherManager.Instance;
        private readonly IWebMethodClient _webMethodClient;
        private readonly IERPRestGateway _erpGateway;


        /// <summary>
        /// Class Constructor used for dependency injection
        /// </summary>
        /// <param name="webMethodClient"></param>
        public OrderService(IWebMethodClient webMethodClient, IERPRestGateway erpGateway)
        {
            _webMethodClient = webMethodClient;
            _erpGateway = erpGateway;
        }
        /// <summary>
        /// This method gets order details for a given logicalId and orderId
        /// </summary>
        /// <param name="logicalId">logicalId</param>
        /// <param name="orderId">orderId</param>
        /// <returns>OrderDetailResponse</returns>
        public OrderDetailResponse GetOrderDetails(OrderSummaryLookUpRequest request)
        {
            return _webMethodClient.GetOrderDetails(request);
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

        public SimulateOrderErpResponse SimulateErpOrder(SimulateOrderErpRequest request)
        {
            return _erpGateway.SimulateOrder(request);
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
