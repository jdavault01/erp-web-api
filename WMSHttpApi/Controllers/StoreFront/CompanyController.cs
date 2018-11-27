using PKI.eBusiness.WMService.Logger;
using PKI.eBusiness.WMSHttpApi.UIHelpers;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using System.IO;
using Pki.eBusiness.WebApi.Entities.StoreFront.DataObjects;
using Swagger.Net.Annotations;
using Pki.eBusiness.WebApi.Contracts.BL.StoreFront;

namespace PKI.eBusiness.WMSHttpApi.Controllers.StoreFront
{
    public class CompanyController : ApiController
    {
        readonly ICompanyService _companyService;
        readonly IPublisher _publisher = PublisherManager.Instance;


        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }


        [Route("wms/company")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(CompanyInfoResponse))]
        [HttpPost]
        public IHttpActionResult getCompanyName([FromBody] CompanyInfoRequest payload)
        {
            if (!ModelState.IsValid)
            {
                Log(InfoMessage.ERROR_MSG_INVALID_GET_COMPANY_INFO_REQUEST_MODEL);
            }

            var companyNameResponseEntity = _companyService.GetCompanyName(payload);
            if (companyNameResponseEntity == null)
            {
                Log(InfoMessage.ERROR_MSG_UNABLE_TO_GET_COMPANY_INFO_RESPONSE);
                return ResponseMessage(Request.CreateResponse(String.Format("{0} {1}", InfoMessage.ERROR_MSG_UNABLE_TO_GET_COMPANY_INFO_RESPONSE, HttpStatusCode.NotFound)));
            }

            return Ok(companyNameResponseEntity);
        }

        [Route("wms/company/addresses")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(CompanyAddressesResponse))]
        [HttpPost]
        public IHttpActionResult getCompanyAddresses([FromBody] CompanyAddressesRequest payload)
        {
            if (!ModelState.IsValid)
            {
                Log(InfoMessage.ERROR_MSG_INVALID_GET_COMPANY_INFO_REQUEST_MODEL);
            }

            var companyAddressesResponseEntity = _companyService.GetCompanyAddresses(payload);
            if (companyAddressesResponseEntity == null)
            {
                Log(InfoMessage.ERROR_MSG_UNABLE_TO_GET_PARTNER_RESPONSE);
                return ResponseMessage(Request.CreateResponse(String.Format("{0} {1}", InfoMessage.ERROR_MSG_UNABLE_TO_GET_PARTNER_RESPONSE, HttpStatusCode.NotFound)));
            }

            return Ok(companyAddressesResponseEntity);
        }

        [Route("wms/company/contacts")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(CompanyContactsResponse))]
        [HttpPost]
        public IHttpActionResult getCompanyContacts([FromBody] CompanyContactsRequest payload)
        {
            if (!ModelState.IsValid)
            {
                Log(InfoMessage.ERROR_MSG_INVALID_GET_COMPANY_INFO_REQUEST_MODEL);
            }

            var companyContactsResponseEntity = _companyService.GetCompanyContacts(payload);
            if (companyContactsResponseEntity == null)
            {
                Log(InfoMessage.ERROR_MSG_UNABLE_TO_GET_PARTNER_RESPONSE);
                return ResponseMessage(Request.CreateResponse(String.Format("{0} {1}", InfoMessage.ERROR_MSG_UNABLE_TO_GET_COMPANY_INFO_RESPONSE, HttpStatusCode.NotFound)));
            }

            return Ok(companyContactsResponseEntity);

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