using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pki.eBusiness.ErpApi.Contract.BL;
using Pki.eBusiness.ErpApi.Entities.DataObjects;
using Pki.eBusiness.ErpApi.Web.Models;
using Pki.eBusiness.ErpApi.Web.UIHelpers;

namespace Pki.eBusiness.ErpApi.Web.Controllers
{
    [Route("wms/products/[action]")]

    public class ProductController : ControllerBase
    {
        readonly IProductService _productService;
        private ILogger _logger;

        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
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

            return Ok(priceResponseEntity);
           //return Ok(new PriceResponseModel(priceResponseEntity));
        }

        private void Log(string message)
        {
            _logger.LogInformation(message);
        }
    }
}
