﻿using System.Collections.Generic;
using System.Runtime.Serialization;
using Pki.eBusiness.WebApi.Entities.StoreFront.Account;

namespace Pki.eBusiness.WebApi.Entities.StoreFront.DataObjects
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