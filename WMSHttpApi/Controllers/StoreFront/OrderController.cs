using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PKI.eBusiness.WMService.Logger;
using PKI.eBusiness.WMService.BusinessServicesContracts.StoreFront;
using PKI.eBusiness.WMService.Entities.StoreFront.DataObjects;
using PKI.eBusiness.WMService.Entities.Stubs.StoreFront;
using Newtonsoft.Json;
using System.IO;
using PKI.eBusiness.WMSHttpApi.UIHelpers;

namespace PKI.eBusiness.WMSHttpApi.Controllers.StoreFront
{
    public class OrderController : ApiController
    {
        readonly IOrderService _orderService;
        readonly IPublisher _publisher = PublisherManager.Instance;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        
        [Route("wms/orders/simulate")]
        [HttpPost]
        public IHttpActionResult SimulateOrder([FromBody] SimulateOrderRequest payload)
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

        [Route("wms/orders/simulateMock")]
        [HttpPost]
        public IHttpActionResult SimulateOrderMock([FromBody] SimulateOrderRequest payload)
        {
            var source = File.ReadAllText("SimulateResponse.json");
            var simulateOrderResponseEntity  = JsonConvert.DeserializeObject<SimulateOrderResponse>(source);
            return Ok(simulateOrderResponseEntity);
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
