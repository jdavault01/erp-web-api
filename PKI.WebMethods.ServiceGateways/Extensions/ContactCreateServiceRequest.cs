using System;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using StorefrontContactCreateRequest = PKI.eBusiness.WMService.Entities.StoreFront.DataObjects.ContactCreateRequest;

namespace PKI.eBusiness.WMService.ServiceGateways.Extensions
{
    [DataContract]
    public class ContactCreateServiceRequest
    {
        [DataMember]
        public ContactCreateWebServiceRequest ContactCreateRequest;
        [DataMember]
        public String JsonRequest { get; set; }

        public ContactCreateServiceRequest(StorefrontContactCreateRequest clientRequest)
        {
            var webServiceRequest = new ContactCreateWebServiceRequest();
            var contactCreateRequest = new ContactCreateRequest(clientRequest);
            webServiceRequest.ContactCreateRequest = contactCreateRequest;
            JsonRequest = JsonConvert.SerializeObject(webServiceRequest, Formatting.Indented);

        }
    }
}
