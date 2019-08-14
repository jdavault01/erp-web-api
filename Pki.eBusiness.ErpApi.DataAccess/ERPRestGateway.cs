using System;
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
using Pki.eBusiness.ErpApi.Entities.Constants;

namespace Pki.eBusiness.ErpApi.DataAccess
{
    public class ERPRestGateway : IERPRestGateway
    {
        private ERPRestSettings _erpRestSettings;
        private IErpApi _erpApi;
        private IOrderApi _atgOrderApi;
        private readonly ILogger _logger;
        private string _baseUrl;

        protected RestClient _restClient { get; set; }

        public ERPRestGateway(ERPRestSettings erpRestSettings, ILogger<ERPRestGateway> logger)
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
            _baseUrl = erpRestSettings.AtgBaseUrl;

        }


        public ContactCreateClientResponse CreateContact(ContactCreateClientRequest request)
        {
            var payLoad = new ContactCreateWebServiceRequest(request);
            LogRequest(payLoad, "CreateContact");
            var result = ExecuteCall<ContactCreateWebServiceResponse>(_erpRestSettings.BaseUrl, _erpRestSettings.GetContactCreateRequest, payLoad);
            LogResponse(result);
            return result.ToResponse();
        }

        public SimulateOrderErpResponse SimulateOrder(SimulateOrderErpRequest request)
        {
            var payLoad = new SimulateOrderRequestRoot(request);
            LogRequest(payLoad, "SimulateOrder");
            var result = _erpApi.SimulateOrderPost(payLoad);
            LogResponse(result);
            return result.ToResponse();
        }

        public ShippingNotificationResponse SendShippingNotifications(ShippingNotification request)
        {
            var payLoad = new ShippingNotificationOrderDto(request);
            var shippingNotification = new ShippingNotificationResponse();
            LogRequest(payLoad, "SendShippingNotifications");
            try
            {
                var result = _atgOrderApi.SendShippingNotifications(payLoad);
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


        public PartnerResponse PartnerLookup(SimplePartnerRequest request)
        {
            var payLoad = new PartnerLookupRequestRoot(request);
            LogRequest(payLoad, "SimplePartnerLookup");
            var result = _erpApi.PartnerLookupPost(payLoad);
            LogResponse(result);
            return result.ToPartnerResponse();
        }

        private T ExecuteCall<T>(string baseUrl, Resource resource, object payLoad) where T : new()
        {
            if (Enum.TryParse(resource.Method.ToUpper(), out Method method))
            {
                _restClient.BaseUrl = new Uri(baseUrl);
                var request = new RestSharp.RestRequest(resource.Path, method)
                {
                    JsonSerializer = new NewtonsoftJsonSerializer()
                };
                request.AddJsonBody(payLoad);
                IRestResponse<T> response = _restClient.Execute<T>(request);
                if (response.StatusCode == HttpStatusCode.NotFound)
                    return default(T);
                return response.Data;

            }
            return default(T);
        }

        public CompanyContactsResponse GetCompanyContacts(CompanyContactsRequest request)
        {
            var payLoad = new PartnerLookupRequestRoot(request);
            LogRequest(payLoad, "CompanyContacts");
            var result = _erpApi.PartnerLookupPost(payLoad);
            LogResponse(result);
            if (result.PARTNERS_OUT == null || result.ADDRESS_OUT == null)
            {
                var companyContactsResponse = new CompanyContactsResponse
                {
                    Error = new Error { Description = "Last name provided not found in this Hiearchy" }
                };
                return companyContactsResponse;
            }
            return result.ToCompanyContactsResponse(request.Name);
        }

        public CompanyAddressesResponse GetCompanyAddresses(CompanyAddressesRequest request)
        {
            var payLoad = new PartnerLookupRequestRoot(request);
            LogRequest(payLoad, "CompanyAddresses");
            var result = _erpApi.PartnerLookupPost(payLoad);
            LogResponse(result);
            return result.ToCompanyAddressesResponse(request.ShipTo, request.BillTo);
        }

        public CompanyInfoResponse GetCompanyInfo(CompanyInfoRequest request)
        {
            var payLoad = new PartnerLookupRequestRoot(request);
            LogRequest(payLoad, "CompanyInfo");
            var result = _erpApi.PartnerLookupPost(payLoad);
            LogResponse(result);
            return result.ToCompanyInfoResponse();
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
