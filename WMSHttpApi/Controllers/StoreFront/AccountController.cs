using PKI.eBusiness.WMService.Entities.StoreFront.DataObjects;
using PKI.eBusiness.WMService.Logger;
using PKI.eBusiness.WMSHttpApi.UIHelpers;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PKI.eBusiness.WMService.Entities.Interfaces.BL.StoreFront;

namespace PKI.eBusiness.WMSHttpApi.Controllers.StoreFront
{
    public class AccountController : ApiController
    {
        readonly IAccountService _accountService;
        readonly IPublisher _publisher = PublisherManager.Instance;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }


        [Route("wms/partners/{accountNumber}/create")]
        [HttpPost]
        public IHttpActionResult Partners([FromUri]string accountNumber, [FromBody] ContactCreateRequest payload)
        {
            //get account number from url parameter
            payload.AccountNumber = accountNumber;
            var createContentResponse = _accountService.CreateContact(accountNumber, payload);
            if (createContentResponse == null)
            {
                Log(InfoMessage.ERROR_MSG_UNABLE_TO_GET_CREATE_CONTENT_RESPONSE);
                return ResponseMessage(Request.CreateResponse(String.Format("{0} {1}", InfoMessage.ERROR_MSG_UNABLE_TO_GET_CREATE_CONTENT_RESPONSE, HttpStatusCode.NotFound)));
            }

            return Ok(createContentResponse);
        }


        [Route("wms/partners/{accountNumber}")]
        [HttpPost]
        public IHttpActionResult Partners([FromUri]string accountNumber, [FromBody] SimplePartnerRequest payload)
        {
            if (payload == null)
            {
                Log(InfoMessage.ERROR_MSG_INVALID_PARTNER_REQUEST);
                return BadRequest(InfoMessage.ERROR_MSG_INVALID_PARTNER_REQUEST);
            }
            if (!ModelState.IsValid)
            {
                Log(InfoMessage.ERROR_MSG_INVALID_PARTNER_REQUEST_MODEL);
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState));
            }
            payload.PartnerId = accountNumber;

            var partnerResponseEntity = _accountService.GetPartnerDetails(payload);
            if (partnerResponseEntity == null)
            {
                Log(InfoMessage.ERROR_MSG_UNABLE_TO_GET_PARTNER_RESPONSE);
                return ResponseMessage(Request.CreateResponse(String.Format("{0} {1}", InfoMessage.ERROR_MSG_UNABLE_TO_GET_PARTNER_RESPONSE, HttpStatusCode.NotFound)));
            }

            return Ok(partnerResponseEntity);
        }

        //Legacy .. remove after cart project
        [Route("wms/account/getpartner")]
        [HttpPost]
        public IHttpActionResult Partner([FromBody] PartnerRequest request)
        {

            if (request == null)
            {
                Log(InfoMessage.ERROR_MSG_INVALID_PARTNER_REQUEST);
                return BadRequest(InfoMessage.ERROR_MSG_INVALID_PARTNER_REQUEST);
            }
            if (!ModelState.IsValid)
            {
                Log(InfoMessage.ERROR_MSG_INVALID_PARTNER_REQUEST_MODEL);
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState));
            }

            var partnerResponseEntity = _accountService.GetPartnerInfo(request);
            if (partnerResponseEntity == null)
            {
                Log(InfoMessage.ERROR_MSG_UNABLE_TO_GET_PARTNER_RESPONSE);
                return ResponseMessage(Request.CreateResponse(String.Format("{0} {1}", InfoMessage.ERROR_MSG_UNABLE_TO_GET_PARTNER_RESPONSE, HttpStatusCode.NotFound)));
            }

            return Ok(partnerResponseEntity);
        }

        [Route("shop/account/GetPOSUser")]
        [HttpPost]
        public IHttpActionResult GetPunchOutUser([FromBody] string companyCode)
        {
            LoginInfo loginInfo;

            if (companyCode == null)
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
                loginInfo = _accountService.GetLoginInfo(companyCode);

                if (loginInfo == null)
                {
                    Log(InfoMessage.ERROR_MSG_UNABLE_TO_GET_PARTNER_RESPONSE);
                    return ResponseMessage(Request.CreateResponse(String.Format("{0} {1}", InfoMessage.ERROR_MSG_UNABLE_TO_GET_PARTNER_RESPONSE, HttpStatusCode.NotFound)));
                }

            }
            catch (Exception e)
            {
                Log(e.Message);
                return BadRequest(e.Message);
            }


            return Ok(loginInfo);
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
