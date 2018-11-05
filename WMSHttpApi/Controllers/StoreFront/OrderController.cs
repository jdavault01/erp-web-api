using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PKI.eBusiness.WMService.Logger;
//using PKI.eBusiness.WMService.Entities.Stubs.StoreFront;
using Newtonsoft.Json;
using System.IO;
using Pki.eBusiness.WebApi.Contracts.BL.StoreFront;
using Pki.eBusiness.WebApi.Entities.Orders;
using Pki.eBusiness.WebApi.Entities.StoreFront.DataObjects;
using PKI.eBusiness.WMSHttpApi.UIHelpers;
using Swagger.Net.Annotations;
using Pki.eBusiness.WebApi.Entities.OrderLookUp.BasicRequest;

namespace PKI.eBusiness.WMSHttpApi.Controllers.StoreFront
{

    [Route("wms/orders/{action}")]
    public class OrderController : ApiController
    {
        readonly IOrderService _orderService;
        readonly IPublisher _publisher = PublisherManager.Instance;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        //[HttpGet]
        //[Route("wms/orders/summary/{language}/{sellerOrderId}")]
        //public OrderSummaryResponse Summary([FromUri] string language, [FromUri] string sellerOrderId)
        //{
        //    var request = new OrderSummaryLookUpRequest(language, sellerOrderId);
        //    return _orderService.GetOrders(request);
        //}

        [HttpGet]
        [Route("wms/orders/{language}/{sellerOrderId}")]
        public OrderDetailResponse Details([FromUri] string language, [FromUri] string sellerOrderId)
        {
            var request = new OrderSummaryLookUpRequest(language, sellerOrderId);
            return _orderService.GetOrderDetails(request);
        }

        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(SimulateOrderResponse))]
        [HttpPost]
        public IHttpActionResult Simulate([FromBody] SimulateOrderRequest payload)
        {
            if (payload == null)
            {
                Log(InfoMessage.ERROR_MSG_INVALID_INVENTORY_REQUEST);
                return BadRequest(InfoMessage.ERROR_MSG_INVALID_INVENTORY_REQUEST);
            }

            if (!ModelState.IsValid)
            {
                Log(InfoMessage.ERROR_MSG_INVALID_INVENTORY_REQUEST_MODEL);
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState));
            }

            var inventoryResponseEntity = _orderService.SimulateOrder(payload);
            if (inventoryResponseEntity == null)
            {
                Log(InfoMessage.ERROR_MSG_UNABLE_TO_GET_INVENTORY_RESPONSE);
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.NotFound, InfoMessage.ERROR_MSG_UNABLE_TO_GET_INVENTORY_RESPONSE));
            }

            return Ok(inventoryResponseEntity);
        }

        [HttpPost]
        public SimulateOrderErpResponse SimulateOrder([FromBody] SimulateOrderErpRequest payload)
        {
            //if (payload.RequestedDate == DateTime.MinValue)
            //{
            //    payload.RequestedDate = DateTime.Now;
            //}

            foreach (var orderItem in payload.OrderItems)
            {
                if (orderItem.RequestedDate == DateTime.MinValue)
                    orderItem.RequestedDate = DateTime.Now;
            }

            return _orderService.SimulateErpOrder(payload);
        }

        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(CreateOrderResponse))]
        [HttpPost]
        public IHttpActionResult Create([FromBody] CreateOrderRequest payload)
        {
            if (payload == null)
            {
                Log(InfoMessage.ERROR_MSG_INVALID_CREATE_ORDER_REQUEST);
                return BadRequest(InfoMessage.ERROR_MSG_INVALID_CREATE_ORDER_REQUEST);
            }
            if (!ModelState.IsValid)
            {
                Log(InfoMessage.ERROR_MSG_INVALID_CREATE_ORDER_REQUEST_MODEL);
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState));
            }
            var orderCreateResponseEntity = _orderService.CreateOrder(payload);

            if (orderCreateResponseEntity == null)
            {
                Log(InfoMessage.ERROR_MSG_UNABLE_TO_GET_CREATE_ORDER_RESPONSE);
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.NotFound, InfoMessage.ERROR_MSG_UNABLE_TO_GET_CREATE_ORDER_RESPONSE));
            }
            return Ok(orderCreateResponseEntity);

        }

        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(InventoryResponse))]
        [HttpPost]
        public IHttpActionResult Inventory([FromBody] InventoryRequest request)
        {
            if (request == null)
            {
                Log(InfoMessage.ERROR_MSG_INVALID_INVENTORY_REQUEST);
                return BadRequest(InfoMessage.ERROR_MSG_INVALID_INVENTORY_REQUEST);
            }

            if (!ModelState.IsValid)
            {
                Log(InfoMessage.ERROR_MSG_INVALID_INVENTORY_REQUEST_MODEL);
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState));
            }

            var inventoryResponseEntity = _orderService.GetInventory(request);
            if (inventoryResponseEntity == null)
            {
                Log(InfoMessage.ERROR_MSG_UNABLE_TO_GET_INVENTORY_RESPONSE);
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.NotFound, InfoMessage.ERROR_MSG_UNABLE_TO_GET_INVENTORY_RESPONSE));
            }

            return Ok(inventoryResponseEntity);

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
