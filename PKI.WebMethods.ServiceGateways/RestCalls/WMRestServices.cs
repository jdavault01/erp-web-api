using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Net;
using System.Web;
using System.Net;
using System.IO;
using PKI.eBusiness.WMService.ServiceGatewContracts.RestCalls;
using PKI.eBusiness.WMService.Entities.Stubs;
using Newtonsoft.Json;
using System.Configuration;
using PKI.eBusiness.WMService.Entities.Stubs.StoreFront;

namespace PKI.eBusiness.WMService.ServiceGateways.RestCalls
{
    public class WMRestServices : IWMRestServices
    {
        public string EndPoint { get; set; }
        public HttpVerb HttpMethod { get; set; }
        public string PayLoad { get; set; }

        public enum HttpVerb
        {
            GET,
            POST,
            PUT,
            DELETE
        }

        public WMRestServices()
        {
            EndPoint = ConfigurationManager.AppSettings["WMRestServiceEndPoint"];
            HttpMethod = HttpVerb.GET;
        }

        private string CallWMRestServices()
        {
            var request = (HttpWebRequest)WebRequest.Create(EndPoint);
            string restResponse = string.Empty;

            request.Method = HttpMethod.ToString();
            request.ContentType = "application/json";
            request.ContentLength = PayLoad.Length;
            using (var requestWriter = new StreamWriter(request.GetRequestStream(), System.Text.Encoding.ASCII))
            {
                requestWriter.Write(PayLoad);
            }

			using (var response = (HttpWebResponse)request.GetResponse())
			{
				if (response.StatusCode != HttpStatusCode.OK)
				{
					throw new ApplicationException("Error Code: " + response.StatusCode);
				}
				//Process the response stream (could be JSON, XML, or HTML)
				using (var responseStream =  response.GetResponseStream())
				{
					if (responseStream != null)
					{
						using (var responseReader = new StreamReader(responseStream))
						{
                            restResponse = responseReader.ReadToEnd();
									
						}//end using reader
					}
				}//end of responseStream
						
			}//end of using response

            return restResponse;
        }

        //List the individual method calls -- e.g CreateContact, GetCompanyContacts, GetCompanyPartnerInfo 
        public ContactCreateWebServiceResponse CreateContact(string request)
        {
            PayLoad = request;
            HttpMethod = HttpVerb.POST;
            var response = CallWMRestServices();
            return JsonConvert.DeserializeObject<ContactCreateWebServiceResponse>(response);
        }
    }

}
