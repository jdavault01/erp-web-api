using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pki.eBusiness.ErpApi.Contract.BL;
using Pki.eBusiness.ErpApi.Entities.Account;
using Pki.eBusiness.ErpApi.Entities.DataObjects;
using Pki.eBusiness.ErpApi.Web.UIHelpers;

namespace Pki.eBusiness.ErpApi.Web.Controllers
{
    public class CompanyController : ControllerBase
    {
        readonly ICompanyService _companyService;
        private ILogger _logger;

        public CompanyController(ICompanyService companyService, ILogger<CompanyController> logger)
        {
            _companyService = companyService;
            _logger = logger;
        }


        [Route("wms/company")]
        [HttpPost]
        public ActionResult<CompanyInfoResponse> GetCompanyName([FromBody] CompanyInfoRequest payload)
        {
            if (!ModelState.IsValid)
            {
                Log(InfoMessage.ERROR_MSG_INVALID_GET_COMPANY_INFO_REQUEST_MODEL);
            }

            payload.SaleaAreaInfo = new SalesArea(payload.SalesOrg);
            var companyNameResponseEntity = _companyService.GetCompanyName(payload);
            if (companyNameResponseEntity == null)
            {
                Log(InfoMessage.ERROR_MSG_UNABLE_TO_GET_COMPANY_INFO_RESPONSE);
                return NotFound($"{InfoMessage.ERROR_MSG_UNABLE_TO_GET_COMPANY_INFO_RESPONSE} {HttpStatusCode.NotFound}");
            }

            return Ok(companyNameResponseEntity);
        }

        [Route("wms/company/addresses")]
        [HttpPost]
        public ActionResult<CompanyAddressesResponse> GetCompanyAddresses([FromBody] CompanyAddressesRequest payload)
        {
            if (!ModelState.IsValid)
            {
                Log(InfoMessage.ERROR_MSG_INVALID_GET_COMPANY_INFO_REQUEST_MODEL);
            }

            var companyAddressesResponseEntity = _companyService.GetCompanyAddresses(payload);
            if (companyAddressesResponseEntity == null)
            {
                Log(InfoMessage.ERROR_MSG_UNABLE_TO_GET_PARTNER_RESPONSE);
                return NotFound($"{InfoMessage.ERROR_MSG_UNABLE_TO_GET_PARTNER_RESPONSE} {HttpStatusCode.NotFound}");
            }

            return Ok(companyAddressesResponseEntity);
        }

        [Route("wms/company/contacts")]
        [HttpPost]
        public ActionResult<CompanyContactsResponse> getCompanyContacts([FromBody] CompanyContactsRequest payload)
        {
            if (!ModelState.IsValid)
            {
                Log(InfoMessage.ERROR_MSG_INVALID_GET_COMPANY_INFO_REQUEST_MODEL);
            }

            var companyContactsResponseEntity = _companyService.GetCompanyContacts(payload);
            if (companyContactsResponseEntity == null)
            {
                Log(InfoMessage.ERROR_MSG_UNABLE_TO_GET_PARTNER_RESPONSE);
                return NotFound(
                    $"{InfoMessage.ERROR_MSG_UNABLE_TO_GET_COMPANY_INFO_RESPONSE} {HttpStatusCode.NotFound}");
            }

            return Ok(companyContactsResponseEntity);

        }

        /// <summary>
        /// This method will log message to log file
        /// </summary>
        /// <param name="message">message</param>
        private void Log(string message)
        {
            _logger.LogInformation(message);
        }

    }
}