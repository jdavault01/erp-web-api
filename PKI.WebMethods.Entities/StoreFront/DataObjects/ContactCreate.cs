using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;
using PKI.eBusiness.WMService.Entities.StoreFront.Account;
using PKI.eBusiness.WMWebApi.BusinessServices.Models.StoreFront.Accounts;

namespace PKI.eBusiness.WMService.Entities.StoreFront.DataObjects
{

    [DataContract]
    public class ContactCreateRequest
    {
        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string AccountNumber { get; set; }

        [DataMember]
        public SalesArea SalesAreaInfo { get; set; }

        [DataMember]
        public List<PhoneNumbers> Telephone { get; set; }

    }

    [DataContract]
    public struct PhoneNumbers
    {
        [DataMember]
        public string Number { get; set; }

        [DataMember]
        public string Qualifier { get; set; }
    }

    [DataContract]
    public class ContactCreateResponse
    {
        [DataMember]
        public string ContactNameId { get; set; }

        public ContactCreateResponse(string contactNameId)
        {
            ContactNameId = contactNameId;
        }
    }
}
