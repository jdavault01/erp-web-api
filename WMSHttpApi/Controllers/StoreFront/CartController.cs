using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PKI.eBusiness.WMService.Logger;
using PKI.eBusiness.WMService.BusinessServicesContracts.StoreFront;
using PKI.eBusiness.WMService.Entities.StoreFront.DataObjects;
using PKI.eBusiness.WMSHttpApi.UIHelpers;


namespace PKI.eBusiness.WMSHttpApi.Controllers.StoreFront
{
    [Route("shop/cart/{action}")]
    public class CartController : ApiController
    {
        readonly ICartService _cartservice;
        readonly IPublisher _publisher = PublisherManager.Instance;

        public CartController(ICartService cartService)
        {
            _cartservice = cartService;
        }

        //[Route("shop/cart/GetClearanceCode")]
        [HttpPost]
        public IHttpActionResult GetClearanceCode([FromBody] CartInfo cartInfo)
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
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState));
            }

            try
            {
                _cartInfo = _cartservice.GetClearanceCode(cartInfo);

                if (_cartInfo == null)
                {
                    Log(InfoMessage.ERROR_MSG_UNABLE_TO_GET_PARTNER_RESPONSE);
                    return
                        ResponseMessage(
                            Request.CreateResponse(String.Format("{0} {1}",
                                InfoMessage.ERROR_MSG_UNABLE_TO_GET_PARTNER_RESPONSE, HttpStatusCode.NotFound)));
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