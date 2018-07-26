using System.Threading.Tasks;
using System.Runtime.Serialization;
using PKI.eBusiness.WMService.Entities.StoreFront.Account;
using PKI.eBusiness.WMWebApi.BusinessServices.Models.StoreFront.Accounts;
using System.Collections.Generic;

namespace PKI.eBusiness.WMService.Entities.StoreFront.DataObjects
{
    public class CompanyBaseResponse
    {
        [DataMember]
        public Error Error { get; set; }
    }

    [DataContract]
    public class CompanyAddressesResponse : CompanyBaseResponse
    {
        [DataMember]
        public List<ShipTo> ShipTos { get; set; }
        [DataMember]
        public List<BillTo> BillTos { get; set; }
    }

    [DataContract]
    public class CompanyContactsResponse : CompanyBaseResponse
    {
        [DataMember]
        public ContactList ContactList { get; set; }
    }

    [DataContract]
    public class CompanyNameResponse : CompanyBaseResponse
    {
        [DataMember]
        public ERPHierarchy ERPHierarchy { get; set; }
    }

    [DataContract]
    public class CompanyAddress
    {
        [DataMember]
        public string Name1 { get; set; }
        [DataMember]
        public string Name2 { get; set; }
        [DataMember]
        public string Street { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string District { get; set; }
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public string PostalCode { get; set; }
        [DataMember]
        public string Region { get; set; }
        [DataMember]
        public bool RADFlag { get; set; }
        [DataMember]
        public string ParentAccount { get; set; }
    }

    [DataContract]
    public class ShipTo
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public CompanyAddress Address { get; set; }
    }


    [DataContract]
    public class BillTo
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public CompanyAddress Address { get; set; }
    }

    [DataContract]
    public class Contact
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string EmailAddress { get; set; }
        [DataMember]
        public string ParentAccount { get; set; }
    }

    [DataContract]
    public class ContactList
    {
        [DataMember]
        public List<Contact> Contact { get; set; }
    }


    [DataContract]
    public class Error
    {
        [DataMember]
        public string ErrorNumber { get; set; }
        [DataMember]
        public string ErrorType { get; set; }
    }

    [DataContract]
    public class ERPHierarchy
    {
        [DataMember]
        public string Number { get; set; }
        [DataMember]
        public string Name { get; set; }

        public ERPHierarchy(string number, string name)
        {
            Name = name;
            Number = number;
        }
    }
}