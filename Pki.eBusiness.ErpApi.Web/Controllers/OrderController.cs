using System;
using System.Net;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pki.eBusiness.ErpApi.Contract.BL;
using Pki.eBusiness.ErpApi.Entities.DataObjects;
using Pki.eBusiness.ErpApi.Entities.OrderLookUp.BasicRequest;
using Pki.eBusiness.ErpApi.Entities.Orders;
using Pki.eBusiness.ErpApi.Logger;
using Pki.eBusiness.ErpApi.Web.UIHelpers;

namespace Pki.eBusiness.ErpApi.Web.Controllers
{

    [Route("wms/orders/[action]")]
    [Produces("application/json")]
    public class OrderController : ControllerBase
    {
        readonly IOrderService _orderService;
        readonly IPublisher _publisher = PublisherManager.Instance;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        [Route("wms/orders/{language}/{sellerOrderId}")]
        public OrderDetailResponse Details( string language,  string sellerOrderId)
        {
            var request = new OrderSummaryLookUpRequest(language, sellerOrderId);
            return _orderService.GetOrderDetails(request);
        }

        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<SimulateOrderResponse> Simulate([FromBody] SimulateOrderRequest payload)
        {
            if (payload == null)
            {
                Log(InfoMessage.ERROR_MSG_INVALID_INVENTORY_REQUEST);
                return BadRequest(InfoMessage.ERROR_MSG_INVALID_INVENTORY_REQUEST);
            }

            if (!ModelState.IsValid)
            {
                Log(InfoMessage.ERROR_MSG_INVALID_INVENTORY_REQUEST_MODEL);
                return BadRequest(ModelState);
            }

            var inventoryResponseEntity = _orderService.SimulateOrder(payload);
            if (inventoryResponseEntity == null)
            {
                Log(InfoMessage.ERROR_MSG_UNABLE_TO_GET_INVENTORY_RESPONSE);
                return NotFound(InfoMessage.ERROR_MSG_UNABLE_TO_GET_INVENTORY_RESPONSE);
            }

            return inventoryResponseEntity;
        }

        [HttpPost]
        public SimulateOrderErpResponse SimulateOrder([FromBody] SimulateOrderErpRequest payload)
        {
            foreach (var orderItem in payload.OrderItems)
            {
                if (orderItem.RequestedDate == DateTime.MinValue)
                    orderItem.RequestedDate = DateTime.Now;
            }

            return _orderService.SimulateErpOrder(payload);
        }

        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<CreateOrderResponse> Create([FromBody] CreateOrderRequest payload)
        {
            if (payload == null)
            {
                Log(InfoMessage.ERROR_MSG_INVALID_CREATE_ORDER_REQUEST);
                return BadRequest(InfoMessage.ERROR_MSG_INVALID_CREATE_ORDER_REQUEST);
            }
            if (!ModelState.IsValid)
            {
                Log(InfoMessage.ERROR_MSG_INVALID_CREATE_ORDER_REQUEST_MODEL);
                return BadRequest(ModelState);
            }
            var orderCreateResponseEntity = _orderService.CreateOrder(payload);

            if (orderCreateResponseEntity == null)
            {
                Log(InfoMessage.ERROR_MSG_UNABLE_TO_GET_CREATE_ORDER_RESPONSE);
                return NotFound(InfoMessage.ERROR_MSG_UNABLE_TO_GET_CREATE_ORDER_RESPONSE);
            }
            return orderCreateResponseEntity;

        }

        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<InventoryResponse> Inventory([FromBody] InventoryRequest request)
        {
            if (request == null)
            {
                Log(InfoMessage.ERROR_MSG_INVALID_INVENTORY_REQUEST);
                return BadRequest(InfoMessage.ERROR_MSG_INVALID_INVENTORY_REQUEST);
            }

            if (!ModelState.IsValid)
            {
                Log(InfoMessage.ERROR_MSG_INVALID_INVENTORY_REQUEST_MODEL);
                return BadRequest(ModelState);
            }

            var inventoryResponseEntity = _orderService.GetInventory(request);
            if (inventoryResponseEntity == null)
            {
                Log(InfoMessage.ERROR_MSG_UNABLE_TO_GET_INVENTORY_RESPONSE);
                NotFound(InfoMessage.ERROR_MSG_UNABLE_TO_GET_INVENTORY_RESPONSE);
            }

            return Ok(inventoryResponseEntity);

        }

        //[SwaggerResponse(HttpStatusCode.OK, Type = typeof(PunchoutOrderMessageResponse))]
        [HttpPost]
        public ActionResult<PunchoutOrderMessageResponse> PunchoutOrderMessage([FromBody] PunchOutOrderMessageRequest payload)
        {
            if (!ModelState.IsValid)
            {
                Log("Invalid Model on PunchoutOrderMessage Request");
                return BadRequest("Invalid Model on PunchoutOrderMessage Request");
            }
            string filePath = Path.GetFullPath(Directory.GetCurrentDirectory() + @"\mocks\PunchoutOrderMessageResponse.json");
            var source = System.IO.File.ReadAllText(filePath);
            var orderResponseEntity = JsonConvert.DeserializeObject<PunchoutOrderMessageResponse>(source);
            return Ok(orderResponseEntity);
        }

        /// <summary>
        /// This method will log message to log file
        /// </summary>
        /// <param name="message">message</param>
        private void Log(string message)
        {
            _publisher.PublishMessage(message, System.Diagnostics.TraceLevel.Info, InfoMessage.WEBAPI_STOREFRONT_LOG_AREA_PRODUCT);
        }

    }
}
