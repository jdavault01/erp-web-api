using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Pki.eBusiness.ErpApi.Contract.BL;
using Pki.eBusiness.ErpApi.Entities.Account;
using Pki.eBusiness.ErpApi.Entities.DataObjects;
using Pki.eBusiness.ErpApi.Logger;
using Pki.eBusiness.ErpApi.Web.UIHelpers;

namespace Pki.eBusiness.ErpApi.Web.Controllers
{
    public class AccountController : ControllerBase
    {
        readonly IAccountService _accountService;
        readonly IPublisher _publisher = PublisherManager.Instance;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }


        [Route("wms/partners/create")]
        [HttpPost]
        public ActionResult<ContactCreateResponse> Partners([FromBody] ContactCreateRequest payload)
        {
            payload.SalesAreaInfo = new SalesArea(payload.SalesOrg);
            var phone = new PhoneNumber { Number = payload.PhoneNumber, Qualifier = "DayPhone"};
            payload.PhoneNumbers = new List<PhoneNumber>{phone}; 

            ContactCreateResponse createContentResponse = _accountService.CreateContact(payload);
            if (createContentResponse == null)
            {
                Log(InfoMessage.ERROR_MSG_UNABLE_TO_GET_CREATE_CONTENT_RESPONSE);
                return NotFound(InfoMessage.ERROR_MSG_UNABLE_TO_GET_CREATE_CONTENT_RESPONSE);
            }

            return Ok(createContentResponse);
        }


        [Route("wms/partners/{accountNumber}/{salesOrg}")]
        [HttpGet]
        public ActionResult<PartnerResponse> Partners(string accountNumber, string salesOrg)
        {
            SimplePartnerRequest payload = new SimplePartnerRequest(accountNumber, salesOrg);
            if (!ModelState.IsValid)
            {
                Log(InfoMessage.ERROR_MSG_INVALID_PARTNER_REQUEST_MODEL);
                return BadRequest(ModelState);
            }
            payload.PartnerId = accountNumber;

            PartnerResponse partnerResponseEntity = _accountService.GetPartnerDetails(payload);
            if (partnerResponseEntity == null)
            {
                Log(InfoMessage.ERROR_MSG_UNABLE_TO_GET_PARTNER_RESPONSE);
                return NotFound(InfoMessage.ERROR_MSG_UNABLE_TO_GET_PARTNER_RESPONSE);
            }
            if (!String.IsNullOrEmpty(partnerResponseEntity.ErrorMessage))
            {
                Log(partnerResponseEntity.ErrorMessage);
                return NotFound(partnerResponseEntity.ErrorMessage);
            }

            return Ok(partnerResponseEntity);
        }


        [Route("wms/partnerLookup/{accountNumber}/{salesOrg}")]
        [HttpGet]

        public PartnerResponse PartnerLookup(string accountNumber, string salesOrg)
        {
            SimplePartnerRequest payload = new SimplePartnerRequest(accountNumber, salesOrg);
            if (!ModelState.IsValid)
            {
                Log(InfoMessage.ERROR_MSG_INVALID_PARTNER_REQUEST_MODEL);
            }
            payload.PartnerId = accountNumber;

            return _accountService.PartnerLookup(payload);
        }

        //[Route("shop/account/GetPOSUser")]
        //[HttpPost]
        //public ActionResult<LoginInfo> GetPunchOutUser([FromBody] string companyCode)
        //{
        //    LoginInfo loginInfo;

        //    if (companyCode == null)
        //    {
        //        Log(InfoMessage.ERROR_MSG_INVALID_PARTNER_REQUEST);
        //        return BadRequest(InfoMessage.ERROR_MSG_INVALID_PARTNER_REQUEST);
        //    }
        //    if (!ModelState.IsValid)
        //    {
        //        Log(InfoMessage.ERROR_MSG_INVALID_PARTNER_REQUEST_MODEL);
        //        return BadRequest(ModelState);
        //    }

        //    try
        //    {
        //        loginInfo = _accountService.GetLoginInfo(companyCode);

        //        if (loginInfo == null)
        //        {
        //            Log(InfoMessage.ERROR_MSG_UNABLE_TO_GET_PARTNER_RESPONSE);
        //            return NotFound(InfoMessage.ERROR_MSG_UNABLE_TO_GET_PARTNER_RESPONSE);
        //        }

        //    }
        //    catch (Exception e)
        //    {
        //        Log(e.Message);
        //        return BadRequest(e.Message);
        //    }


        //    return Ok(loginInfo);
        //}

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
