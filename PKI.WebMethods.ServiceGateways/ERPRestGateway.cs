using Newtonsoft.Json;
using PKI.eBusiness.WMService.Entities.Settings;
using PKI.eBusiness.WMService.Entities.Stubs.StoreFront;
using PKI.eBusiness.WMService.ServiceGatewContracts;
using System;
using System.Configuration;
using System.IO;
using System.Net;

namespace PKI.eBusiness.WMService.ServiceGateways
{
    public class ERPRestGateway : IERPRestGateway
    {
        private ERPRestSettings _erpRestSettings;

        public ERPRestGateway(ERPRestSettings erpRestSettings)
        {
            _erpRestSettings = erpRestSettings;
        }

        //List the individual method calls -- e.g CreateContact, GetCompanyContacts, GetCompanyPartnerInfo 
        public ContactCreateWebServiceResponse CreateContact(string payLoad, string resourceName)
        {
            //var response = CallWMRestServices(payLoad, resourceName);  
            var response = CallERPService(payLoad, resourceName);
            return JsonConvert.DeserializeObject<ContactCreateWebServiceResponse>(response);
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
    }
}
