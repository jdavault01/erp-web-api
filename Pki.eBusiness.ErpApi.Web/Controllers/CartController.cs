using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Pki.eBusiness.ErpApi.Contract.BL;
using Pki.eBusiness.ErpApi.Entities.DataObjects;
using Pki.eBusiness.ErpApi.Logger;
using Pki.eBusiness.ErpApi.Web.UIHelpers;

namespace Pki.eBusiness.ErpApi.Web.Controllers
{
    [Route("shop/cart/{action}")]
    public class CartController : ControllerBase
    {
        readonly ICartService _cartservice;
        readonly IPublisher _publisher = PublisherManager.Instance;

        public CartController(ICartService cartService)
        {
            _cartservice = cartService;
        }

        //[Route("shop/cart/GetClearanceCode")]
        [HttpPost]
        public ActionResult<CartInfo> GetClearanceCode([FromBody] CartInfo cartInfo)
        {
            CartInfo _cartInfo;

            if (cartInfo == null)
            {
                Log(InfoMessage.ERROR_MSG_INVALID_PARTNER_REQUEST);
                return BadRequest(InfoMessage.ERROR_MSG_INVALID_PARTNER_REQUEST);
            }
            if (!ModelState.IsValid)
            {
                Log(InfoMessage.ERROR_MSG_INVALID_PARTNER_REQUEST_MODEL);
                return BadRequest(ModelState);
            }

            try
            {
                _cartInfo = _cartservice.GetClearanceCode(cartInfo);

                if (_cartInfo == null)
                {
                    Log(InfoMessage.ERROR_MSG_UNABLE_TO_GET_PARTNER_RESPONSE);
                    return NotFound($"{InfoMessage.ERROR_MSG_UNABLE_TO_GET_PARTNER_RESPONSE} {HttpStatusCode.NotFound}");
                }

            }
            catch (Exception e)
            {
                Log(e.Message);
                return BadRequest(e.Message);
            }

            return Ok(_cartInfo);
        }

        /// <summary>
        /// This method will log message to log file
        /// </summary>
        /// <param name="message">message</param>
        private void Log(string message)
        {
            _publisher.PublishMessage(message, System.Diagnostics.TraceLevel.Info, InfoMessage.WEBAPI_STOREFRONT_LOG_AREA_ACCOUNT);
        }

    }
}