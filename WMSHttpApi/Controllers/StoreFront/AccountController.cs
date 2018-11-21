using PKI.eBusiness.WMService.Logger;
using PKI.eBusiness.WMSHttpApi.UIHelpers;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Pki.eBusiness.WebApi.Contracts.BL.StoreFront;
using Pki.eBusiness.WebApi.Entities.StoreFront.DataObjects;
using Swagger.Net.Annotations;
using Pki.eBusiness.WebApi.Entities.StoreFront.Account;
using System.Collections.Generic;

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


        [Route("wms/partners/create")]
        [HttpPost]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(ContactCreateResponse))]
        public IHttpActionResult Partners([FromBody] ContactCreateRequest payload)
        {
            payload.SalesAreaInfo = new SalesArea(payload.SalesOrg);
            var phone = new PhoneNumber { Number = payload.PhoneNumber, Qualifier = "DayPhone"};
            payload.PhoneNumbers = new List<PhoneNumber>{phone}; 

            var createContentResponse = _accountService.CreateContact(payload);
            if (createContentResponse == null)
            {
                Log(InfoMessage.ERROR_MSG_UNABLE_TO_GET_CREATE_CONTENT_RESPONSE);
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.NotFound, InfoMessage.ERROR_MSG_UNABLE_TO_GET_CREATE_CONTENT_RESPONSE));
            }

            return Ok(createContentResponse);
        }


        //[Route("wms/partners/{accountNumber}/{salesOrg}")]
        //[HttpGet]
        //[SwaggerResponse(HttpStatusCode.OK, Type = typeof(PartnerResponse))]
        //public IHttpActionResult Partners([FromUri]string accountNumber, [FromUri] string salesOrg)
        //{
        //    SimplePartnerRequest payload = new SimplePartnerRequest(accountNumber, salesOrg);
        //    if (!ModelState.IsValid)
        //    {
        //        Log(InfoMessage.ERROR_MSG_INVALID_PARTNER_REQUEST_MODEL);
        //        return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState));
        //    }
        //    payload.PartnerId = accountNumber;

        //    PartnerResponse partnerResponseEntity = _accountService.GetPartnerDetails(payload);
        //    if (partnerResponseEntity == null)
        //    {
        //        Log(InfoMessage.ERROR_MSG_UNABLE_TO_GET_PARTNER_RESPONSE);
        //        return ResponseMessage(Request.CreateResponse(HttpStatusCode.NotFound, InfoMessage.ERROR_MSG_UNABLE_TO_GET_PARTNER_RESPONSE));
        //    }
        //    if (!String.IsNullOrEmpty(partnerResponseEntity.ErrorMessage))
        //    {
        //        Log(partnerResponseEntity.ErrorMessage);
        //        var httpResponseMessage = Request.CreateResponse(HttpStatusCode.NotFound, partnerResponseEntity.ErrorMessage);
        //        return ResponseMessage(httpResponseMessage);
        //    }

        //    return Ok(partnerResponseEntity);
        //}


        //[Route("wms/company/{accountNumber}/{salesOrg}")]
        //[HttpGet]

        //public PartnerResponse PartnerLookup([FromUri]string accountNumber, [FromUri] string salesOrg)
        //{
        //    SimplePartnerRequest payload = new SimplePartnerRequest(accountNumber, salesOrg);
        //    if (!ModelState.IsValid)
        //    {
        //        Log(InfoMessage.ERROR_MSG_INVALID_PARTNER_REQUEST_MODEL);
        //    }
        //    payload.PartnerId = accountNumber;

        //    return _accountService.PartnerLookup(payload);
        //}

        [Route("wms/partners/{accountNumber}/{salesOrg}")]
        [HttpGet]

        public PartnerResponse PartnerLookup([FromUri]string accountNumber, [FromUri] string salesOrg)
        {
            SimplePartnerRequest payload = new SimplePartnerRequest(accountNumber, salesOrg);
            if (!ModelState.IsValid)
            {
                Log(InfoMessage.ERROR_MSG_INVALID_PARTNER_REQUEST_MODEL);
            }
            payload.PartnerId = accountNumber;

            return _accountService.PartnerLookup(payload);
        }

        [Route("shop/account/GetPOSUser")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(LoginInfo))]
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
                    return ResponseMessage(Request.CreateResponse(HttpStatusCode.NotFound, InfoMessage.ERROR_MSG_UNABLE_TO_GET_PARTNER_RESPONSE));
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
