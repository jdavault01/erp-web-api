﻿using PKI.eBusiness.WMService.BusinessServicesContracts.StoreFront;
using PKI.eBusiness.WMService.Entities.StoreFront.DataObjects;
using PKI.eBusiness.WMService.Logger;
using PKI.eBusiness.WMSHttpApi.UIHelpers;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using System.IO;

namespace PKI.eBusiness.WMSHttpApi.Controllers.StoreFront
{
    public class CompanyController : ApiController
    {
        //readonly ICompanyService _companyService;
        readonly IPublisher _publisher = PublisherManager.Instance;


        [Route("wms/company/{hierchyNumber}/name")]
        [HttpPost]
        public IHttpActionResult getCompanyName([FromUri]string hierchyNumber, [FromBody] CompanyNameRequest payload)
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
            payload.ERPHierarchyNumber = hierchyNumber;

            //var companyNameResponseEntity = _companyService.GetName(payload);

            string filePath = System.IO.Path.GetFullPath(Directory.GetCurrentDirectory() + @"\mocks\CompanyName.json");
            var source = File.ReadAllText(filePath);
            var companyNameResponseEntity = JsonConvert.DeserializeObject<CompanyNameResponse>(source);
            
            if (companyNameResponseEntity == null)
            {
                Log(InfoMessage.ERROR_MSG_UNABLE_TO_GET_PARTNER_RESPONSE);
                return ResponseMessage(Request.CreateResponse(String.Format("{0} {1}", InfoMessage.ERROR_MSG_UNABLE_TO_GET_PARTNER_RESPONSE, HttpStatusCode.NotFound)));
            }

            return Ok(companyNameResponseEntity);
        }

        [Route("wms/company/{hierchyNumber}/addresses")]
        [HttpPost]
        public IHttpActionResult getCompanyAddresses([FromUri]string hierchyNumber, [FromBody] CompanyAddressesRequest payload)
        {
            //var companyAddressesResponseEntity = _companyService.GetAddresses(payload);

            string filePath = System.IO.Path.GetFullPath(Directory.GetCurrentDirectory() + @"\mocks\CompanyAddresses.json");
            var source = File.ReadAllText(filePath);
            var companyAddressesResponseEntity = JsonConvert.DeserializeObject<CompanyAddressesResponse>(source);
            return Ok(companyAddressesResponseEntity);
        }

        [Route("wms/company/{hierchyNumber}/contacts")]
        [HttpPost]
        public IHttpActionResult getCompanyContacts([FromUri]string hierchyNumber, [FromBody] CompanyContactsRequest payload)
        {
            //var companyContactsResponseEntity = _companyService.GetContacts(payload);

            string filePath = System.IO.Path.GetFullPath(Directory.GetCurrentDirectory() + @"\mocks\CompanyContacts.json");
            var source = File.ReadAllText(filePath);
            var companyContactsResponseEntity = JsonConvert.DeserializeObject<CompanyContactsResponse>(source);
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