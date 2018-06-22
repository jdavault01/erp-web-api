using PKI.eBusiness.WMService.BusinessServicesContracts.StoreFront;
using PKI.eBusiness.WMService.Entities.StoreFront.DataObjects;
using PKI.eBusiness.WMService.Logger;
using PKI.eBusiness.WMSHttpApi.Models;
using PKI.eBusiness.WMSHttpApi.UIHelpers;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PKI.eBusiness.WMSHttpApi.Controllers.StoreFront
{
    public class ProductController : ApiController
    {
        readonly IProductService _productService;
        readonly IPublisher _publisher = PublisherManager.Instance;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [Route("wms/product/getprice")]
        [HttpPost]
        public IHttpActionResult GetPrice([FromBody] PriceRequest request)
        {
            if (request == null)
            {
                Log(InfoMessage.ERROR_MSG_INVALID_PRICE_REQUEST);
                return BadRequest(InfoMessage.ERROR_MSG_INVALID_PRICE_REQUEST);
            }

            if (!ModelState.IsValid)
            {
                Log(InfoMessage.ERROR_MSG_INVALID_PRICE_REQUEST_MODEL);
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState));
            }

            var priceResponseEntity = _productService.GetPrice(request);

            if (priceResponseEntity == null)
            {
                Log(InfoMessage.ERROR_MSG_UNABLE_TO_GET_PRICE_RESPONSE);
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.NotFound, InfoMessage.ERROR_MSG_UNABLE_TO_GET_PRICE_RESPONSE));
            }

            return Ok(new PriceResponseModel(priceResponseEntity));
        }
        [Route("wms/orders/inventory")]
        [HttpPost]
        public IHttpActionResult GetInventory([FromBody] InventoryRequest request)
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

            var inventoryResponseEntity = _productService.GetInventory(request);
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
