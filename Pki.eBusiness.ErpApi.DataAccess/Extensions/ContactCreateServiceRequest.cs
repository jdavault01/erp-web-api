using System;
using Newtonsoft.Json;
using StorefrontContactCreateRequest = Pki.eBusiness.ErpApi.Entities.DataObjects.ContactCreateRequest;

namespace Pki.eBusiness.ErpApi.DataAccess.Extensions
{
    
    public class ContactCreateServiceRequest
    {
        
        public ContactCreateWebServiceRequest ContactCreateRequest;
        
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
