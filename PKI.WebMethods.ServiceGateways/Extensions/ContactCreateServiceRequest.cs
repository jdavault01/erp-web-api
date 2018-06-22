using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using PKI.eBusiness.WMService.Entities.Stubs.StoreFront;
using StorefrontContactCreateRequest = PKI.eBusiness.WMService.Entities.StoreFront.DataObjects.ContactCreateRequest;


namespace PKI.eBusiness.WMService.ServiceGateways.Extensions
{
    [DataContract]
    public class ContactCreateServiceRequest
    {
        [DataMember]
        public String JsonResponse { get; set; }

        public ContactCreateServiceRequest(StorefrontContactCreateRequest clientRequest)
        {
            var WebServiceRequest = new ContactCreateWebServiceRequest();
            var contactCreateRequest = new Request(clientRequest);
            WebServiceRequest.ContactCreateRequest = contactCreateRequest;
            JsonResponse = JsonConvert.SerializeObject(WebServiceRequest, Formatting.Indented);
        }
    }
}
