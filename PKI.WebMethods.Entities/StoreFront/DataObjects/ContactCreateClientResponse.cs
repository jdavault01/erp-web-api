using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using PKI.eBusiness.WMService.Entities.StoreFront.DataObjects;

using WebMethodsContactCreateResponse = PKI.eBusiness.WMService.Entities.Stubs.StoreFront.ContactCreateWebServiceResponse;

namespace PKI.eBusiness.WMService.Entities.StoreFront.DataObjects
{
    [DataContract]
    public class ContactCreateClientResponse
    {
        [DataMember]
        public ContactCreateResponse ContactCreateResponse { get; set; }

        public ContactCreateClientResponse(WebMethodsContactCreateResponse response)
        {
            ContactCreateResponse = new ContactCreateResponse(response);
        }

    }
}
