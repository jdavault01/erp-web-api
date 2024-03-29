﻿using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Pki.eBusiness.ErpApi.Contract.DAL;
using Pki.eBusiness.ErpApi.DataAccess.ErpApi;
using Pki.eBusiness.ErpApi.DataAccess.ErpApi.Model;
using Pki.eBusiness.ErpApi.Entities.DataObjects;
using Pki.eBusiness.ErpApi.Entities.Orders;
using Pki.eBusiness.ErpApi.Entities.Settings;
using RestSharp;
using RestSharp.Deserializers;
using Pki.eBusiness.ErpApi.DataAccess.Extensions;
using Pki.eBusiness.ErpApi.DataAccess.AtgApi;
using Pki.eBusiness.ErpApi.DataAccess.Model;
using atgApiClient = Pki.eBusiness.ErpApi.DataAccess.Client;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Pki.eBusiness.ErpApi.DataAccess.Models;
using Pki.eBusiness.ErpApi.Entities.Account;
using Pki.eBusiness.ErpApi.Entities.Constants;
using Pki.eBusiness.ErpApi.Entities.OrderLookUp.BasicRequest;

namespace Pki.eBusiness.ErpApi.DataAccess
{
    public class ERPRestGateway : IERPRestGateway
    {
        private ERPRestSettings _erpRestSettings;
        private IErpApi _erpApi;
        private IOrderApi _atgOrderApi;
        private readonly ILogger _logger;
        private readonly IBackupRepository _repository;
        private string _baseUrl;

        protected RestClient _restClient { get; set; }

        public ERPRestGateway(ERPRestSettings erpRestSettings, ILogger<ERPRestGateway> logger, IBackupRepository repository)
        {
            _restClient = new RestClient();
            _restClient.ClearHandlers();
            _restClient.AddHandler("application/json", new NewtonsoftJsonSerializer());
            _restClient.Timeout = erpRestSettings.Timeout; 
            _erpRestSettings = erpRestSettings;
            _erpApi = new ErpApi.ErpApi(erpRestSettings.IntegrationPlatformBaseUrl, erpRestSettings.UserName, erpRestSettings.PassWord);
            _atgOrderApi = new AtgApi.OrderApi(erpRestSettings);
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, errors) => true;
            _logger = logger;
            _repository = repository;
            _baseUrl = erpRestSettings.AtgBaseUrl;

        }


        public ContactCreateClientResponse CreateContact(ContactCreateClientRequest request)
        {
            var payLoad = new ContactCreateWebServiceRequest(request);
            var backup = new BackupLogEntry(payLoad, nameof(CreateContact));
            LogRequest(payLoad, nameof(CreateContact));
            var result = ExecuteCall<ContactCreateWebServiceResponse>(_erpRestSettings.BaseUrl, _erpRestSettings.GetContactCreateRequest, payLoad);
            backup.AddResponse(result);
            _repository.InsertOne(backup);
            LogResponse(result);
            return result.ToResponse();
        }

        public SimulateOrderErpResponse SimulateOrder(SimulateOrderErpRequest request)
        {
            var payLoad = new SimulateOrderRequestRoot(request);
            var backup = new BackupLogEntry(payLoad, nameof(SimulateOrder));
            LogRequest(payLoad, nameof(SimulateOrder));
            var result = _erpApi.SimulateOrderPost(payLoad);
            backup.AddResponse(result);
            _repository.InsertOne(backup);
            LogResponse(result);
            return result.ToResponse();
        }

        public ShippingNotificationResponse SendShippingNotifications(ShippingNotification request)
        {
            var payLoad = new ShippingNotificationOrderDto(request);
            var backup = new BackupLogEntry(payLoad, nameof(SendShippingNotifications));
            var shippingNotification = new ShippingNotificationResponse();
            LogRequest(payLoad, nameof(SendShippingNotifications));
            try
            {
                var result = _atgOrderApi.SendShippingNotifications(payLoad);
                backup.AddResponse(result);
                _repository.InsertOne(backup);
                LogResponse(result);
                if (string.IsNullOrEmpty(result))
                {
                    shippingNotification.EmailSent = false;
                    shippingNotification.ErrorMessage = "Server Error communcating with notification service.";
                }
                shippingNotification.EmailSent = Boolean.Parse(result);
            }
            catch (Exception ex)
            {
                shippingNotification.EmailSent = false;
                shippingNotification.ErrorMessage = ex.Message;
            }

            return shippingNotification;
        }


        public PartnerResponse SimplePartnerLookup(SimplePartnerRequest request)
        {
            var payLoad = new PartnerLookupRequestRoot(request);
            var backup = new BackupLogEntry(payLoad, nameof(SimplePartnerLookup));
            LogRequest(payLoad, nameof(SimplePartnerLookup));
            var result = _erpApi.PartnerLookupPost(payLoad);
            var partnerResponse = result.ToPartnerResponse();
            backup.AddResponse(partnerResponse);
            _repository.InsertOne(backup);
            LogResponse(partnerResponse);
            return partnerResponse;
        }

        public Partner GetShipToAddress(SimplePartnerRequest request)
        {
            var payLoad = new PartnerLookupRequestRoot(request, Enumerations.AddressType.ShipTo);
            LogRequest(payLoad, "GetShipToAddressLookup");
            var result = _erpApi.PartnerLookupPost(payLoad);
            var partnerAddress = result.ToShipToAddressResponse(request.PartnerId);
            LogResponse(partnerAddress);
            return partnerAddress;
        }

        public Partner GetBillToAddress(SimplePartnerRequest request)
        {
            var payLoad = new PartnerLookupRequestRoot(request, Enumerations.AddressType.BillTo);
            LogRequest(payLoad, "GetBillToAddressLookup");
            var result = _erpApi.PartnerLookupPost(payLoad);
            var partnerAddress = result.ToBillToAddressResponse(request.PartnerId);
            LogResponse(partnerAddress);
            return partnerAddress;
        }

        private T ExecuteCall<T>(string baseUrl, Resource resource, object payLoad) where T : new()
        {
            if (!Enum.TryParse(resource.Method.ToUpper(), out Method method)) return default(T);
            _restClient.BaseUrl = new Uri(baseUrl);
            var request = new RestSharp.RestRequest(resource.Path, method)
            {
                JsonSerializer = new NewtonsoftJsonSerializer()
            };
            request.AddJsonBody(payLoad);
            var response = _restClient.Execute<T>(request);
            return response.StatusCode == HttpStatusCode.NotFound ? default(T) : response.Data;
        }


        public CompanyContactsResponse CompanyContacts(CompanyContactsRequest request)
        {
            var payLoad = new PartnerLookupRequestRoot(request);
            var backup = new BackupLogEntry(payLoad, nameof(CompanyContacts));
            LogRequest(payLoad, nameof(CompanyContacts));
            var result = _erpApi.PartnerLookupPost(payLoad);
            if (result.PARTNERS_OUT == null || result.ADDRESS_OUT == null)
            {
                var companyContactsResponse = new CompanyContactsResponse
                {
                    Error = new Error { Description = "Last name provided not found in this Hiearchy" }
                };
                return companyContactsResponse;
            }
            var companyContactResponse = result.ToCompanyContactsResponse(request.Name);
            backup.AddResponse(companyContactResponse);
            _repository.InsertOne(backup);
            LogResponse(companyContactResponse);
            return companyContactResponse;
        }

        public CompanyAddressesResponse CompanyAddresses(CompanyAddressesRequest request)
        {
            var payLoad = new PartnerLookupRequestRoot(request);
            var backup = new BackupLogEntry(payLoad, nameof(CompanyAddresses));
            LogRequest(payLoad, "CompanyAddresses");
            var result = _erpApi.PartnerLookupPost(payLoad);
            var companyAddressResponse = result.ToCompanyAddressesResponse(request.ShipTo, request.BillTo);
            backup.AddResponse(companyAddressResponse);
            _repository.InsertOne(backup);
            LogResponse(companyAddressResponse);
            return companyAddressResponse;
        }

        public CompanyInfoResponse CompanyInfo(CompanyInfoRequest request)
        {
            var payLoad = new PartnerLookupRequestRoot(request);
            var backup = new BackupLogEntry(payLoad, nameof(CompanyInfo));
            LogRequest(payLoad, nameof(CompanyInfo));
            var result = _erpApi.PartnerLookupPost(payLoad);
            var companyInfoResponse =  result.ToCompanyInfoResponse();
            backup.AddResponse(companyInfoResponse);
            _repository.InsertOne(backup);
            LogResponse(companyInfoResponse);
            return companyInfoResponse;
        }


        private void LogRequest<T>(T request, string nameOfMethod)
        {
            string jsonRequest = request.SerializeToJson(OutPutType.Unformatted);
            Log($"{ErrorMessages.SEND_DATA_INPUT_REQUEST} for {nameOfMethod} using {_baseUrl}");
            Log(jsonRequest.Replace("\r\n", ""));
            Log(InfoMessages.INVOKING_SERVICE_REQUEST);
        }

        private void LogResponse<T>(T response)
        {
            var newJsonResponse = JsonConvert.SerializeObject(response, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            Log(InfoMessages.RESPONSE_FROM_SERVICE);
            Log(newJsonResponse);
        }

        private void Log(string message)
        {
            _logger.LogInformation(message);
        }


    }
}
