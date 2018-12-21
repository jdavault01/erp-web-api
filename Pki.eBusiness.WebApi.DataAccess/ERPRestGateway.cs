using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using Pki.eBusiness.ErpApi.Contracts.DAL;
using Pki.eBusiness.ErpApi.DataAccess.ErpApi.Api;
using Pki.eBusiness.ErpApi.DataAccess.ErpApi.Model;
using Pki.eBusiness.ErpApi.Entities.Orders;
using Pki.eBusiness.ErpApi.Entities.Settings;
using Pki.eBusiness.ErpApi.Entities.DataObjects;

namespace Pki.eBusiness.ErpApi.DataAccess
{
    public class ERPRestGateway : IERPRestGateway
    {
        private ERPRestSettings _erpRestSettings;
        private IErpApi _erpApi;
        public ERPRestGateway(ERPRestSettings erpRestSettings, IErpApi erpApi)
        {
            _erpRestSettings = erpRestSettings;
            _erpApi = erpApi;
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, errors) => true;
        }

        //List the individual method calls -- e.g CreateContact, GetCompanyContacts, GetCompanyPartnerInfo 
        public ContactCreateWebServiceResponse CreateContact(string payLoad, string resourceName)
        {
            var response = CallERPService(payLoad, resourceName);
            return JsonConvert.DeserializeObject<ContactCreateWebServiceResponse>(response);
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

        private string CallERPService(string payLoad, string resourceName)
        {
            var endPoint = _erpRestSettings.BaseUrl + "/" + _erpRestSettings.Resources[resourceName].Path;
            var method = _erpRestSettings.Resources[resourceName].Method;
            string restResponse = "Error";
            try
            {
                using (var client = new WebClient())
                {
                    client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                    client.Headers.Add(HttpRequestHeader.Accept, "application/json");
                    restResponse = client.UploadString(new Uri(endPoint), method, payLoad);
                }
            }
            catch (Exception ex)
            {
                restResponse = "Error: " + ex.Message;
            }
            return restResponse;
        }

        private string CallWMRestServices(string payLoad, string resourceName)
        {
            var endPoint = _erpRestSettings.BaseUrl + "/" + _erpRestSettings.Resources[resourceName].Path;
            var method = _erpRestSettings.Resources[resourceName].Method;

            var request = (HttpWebRequest)WebRequest.Create(endPoint);
            string restResponse = "Error";

            request.Method = method;
            request.ContentType = "application/json";
            request.ContentLength = payLoad.Length;
            using (var requestWriter = new StreamWriter(request.GetRequestStream(), System.Text.Encoding.ASCII))
            {
                requestWriter.Write(payLoad);
            }

			using (var response = (HttpWebResponse)request.GetResponse())
			{
				if (response.StatusCode != HttpStatusCode.OK)
				{
					throw new ApplicationException("Error Code: " + response.StatusCode);
				}
				using (var responseStream =  response.GetResponseStream())
				{
					if (responseStream != null)
					{
						using (var responseReader = new StreamReader(responseStream))
						{
                            restResponse = responseReader.ReadToEnd();
									
						}
					}
				}
			}

            return restResponse;
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
