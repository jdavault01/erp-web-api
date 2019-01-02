using System.Net;
using Microsoft.AspNetCore.Mvc;
using Pki.eBusiness.ErpApi.Contract.BL;
using Pki.eBusiness.ErpApi.Entities.DataObjects;
using Pki.eBusiness.ErpApi.Logger;
using Pki.eBusiness.ErpApi.Web.Models;
using Pki.eBusiness.ErpApi.Web.UIHelpers;

namespace Pki.eBusiness.ErpApi.Web.Controllers
{
    [Route("wms/products/[action]")]

    public class ProductController : ControllerBase
    {
        readonly IProductService _productService;
        readonly IPublisher _publisher = PublisherManager.Instance;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public ActionResult<PriceResponseModel> GetPrice([FromBody] PriceRequest request)
        {
            if (request == null)
            {
                Log(InfoMessage.ERROR_MSG_INVALID_PRICE_REQUEST);
                return BadRequest(InfoMessage.ERROR_MSG_INVALID_PRICE_REQUEST);
            }

            if (!ModelState.IsValid)
            {
                Log(InfoMessage.ERROR_MSG_INVALID_PRICE_REQUEST_MODEL);
                return BadRequest(ModelState);
            }

            var priceResponseEntity = _productService.GetPrice(request);

            if (priceResponseEntity == null)
            {
                Log(InfoMessage.ERROR_MSG_UNABLE_TO_GET_PRICE_RESPONSE);
                return NotFound(InfoMessage.ERROR_MSG_UNABLE_TO_GET_PRICE_RESPONSE);
            }

            return new PriceResponseModel(priceResponseEntity);
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
