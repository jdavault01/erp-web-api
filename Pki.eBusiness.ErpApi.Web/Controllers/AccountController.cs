using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pki.eBusiness.ErpApi.Contract.BL;
using Pki.eBusiness.ErpApi.Entities.Account;
using Pki.eBusiness.ErpApi.Entities.DataObjects;
using Pki.eBusiness.ErpApi.Web.UIHelpers;

namespace Pki.eBusiness.ErpApi.Web.Controllers
{
    public class AccountController : ControllerBase
    {
        readonly IAccountService _accountService;
        readonly ILogger _logger;

        public AccountController(IAccountService accountService, ILogger<AccountController> logger)
        {
            _accountService = accountService;
            _logger = logger;
        }


        [Route("wms/partners/create")]
        [HttpPost]
        public ActionResult<ContactCreateClientResponse> Partners([FromBody] ContactCreateClientRequest payload)
        {
            payload.SalesAreaInfo = new SalesArea(payload.SalesOrg);
            var phone = new PhoneNumber { Number = payload.PhoneNumber, Qualifier = "DayPhone"};
            payload.PhoneNumbers = new List<PhoneNumber>{phone}; 

            ContactCreateClientResponse createContentResponse = _accountService.CreateContact(payload);
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

        private void Log(string message)
        {
            _logger.LogInformation(message);
        }
    }
}
