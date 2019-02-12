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

namespace Pki.eBusiness.ErpApi.DataAccess
{
    public class ERPRestGateway : IERPRestGateway
    {
        private ERPRestSettings _erpRestSettings;
        private IErpApi _erpApi;
        protected RestClient _restClient { get; set; }

        public ERPRestGateway(ERPRestSettings erpRestSettings, IErpApi erpApi)
        {
            _restClient = new RestClient();
            _restClient.ClearHandlers();
            _restClient.AddHandler("application/json", new NewtonsoftJsonSerializer());
            _erpRestSettings = erpRestSettings;
            _erpApi = erpApi;
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, errors) => true;
        }


        public ContactCreateClientResponse CreateContact(ContactCreateClientRequest request)
        {
            var payLoad = new ContactCreateWebServiceRequest(request);
            var result = ExecuteCall<ContactCreateWebServiceResponse>(_erpRestSettings.BaseUrl, _erpRestSettings.GetContactCreateRequest, payLoad);
            return result.ToResponse();
        }

        public SimulateOrderErpResponse SimulateOrder(SimulateOrderErpRequest request)
        {
            SimulateOrderRequestRoot req = new SimulateOrderRequestRoot(request);
            var result = _erpApi.SimulateOrderPost(req);
            return result.ToResponse();
        }

        public PartnerResponse PartnerLookup(SimplePartnerRequest request)
        {
            PartnerLookupRequestRoot req = new PartnerLookupRequestRoot(request);
            var result = _erpApi.PartnerLookupPost(req);
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
            PartnerLookupRequestRoot req = new PartnerLookupRequestRoot(request);
            var result = _erpApi.PartnerLookupPost(req);
            return result.ToCompanyContactsResponse(request.Name);
        }

        public CompanyAddressesResponse GetCompanyAddresses(CompanyAddressesRequest request)
        {
            PartnerLookupRequestRoot req = new PartnerLookupRequestRoot(request);
            var result = _erpApi.PartnerLookupPost(req);
            return result.ToCompanyAddressesResponse(request.ShipTo, request.BillTo);
        }

        public CompanyInfoResponse GetCompanyInfo(CompanyInfoRequest request)
        {
            PartnerLookupRequestRoot req = new PartnerLookupRequestRoot(request);
            var result = _erpApi.PartnerLookupPost(req);
            return result.ToCompanyInfoResponse();
        }

    }
}
