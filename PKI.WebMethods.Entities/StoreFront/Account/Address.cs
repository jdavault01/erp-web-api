using System;
using System.Runtime.Serialization;

namespace PKI.eBusiness.WMService.Entities.StoreFront.Account
{
    [DataContract]
    public class Address
    {
        [DataMember]
        public Guid Id;

        [DataMember]
        public string Street;

        [DataMember]
        public string POBox;

        [DataMember]
        public string POBoxCity;

        [DataMember]
        public string City;

        [DataMember]
        public string Country;

        [DataMember]
        public string Fax;

        [DataMember]
        public string PostalCode;

        [DataMember]
        public string Telephone;

        [DataMember]
        public string State;

        [DataMember]
        public string Region;

        [DataMember]
        public string District;

    }
}
