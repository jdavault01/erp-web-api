using System.Collections.Generic;
using Newtonsoft.Json;
using Pki.eBusiness.ErpApi.Entities.Account;

namespace Pki.eBusiness.ErpApi.Entities.DataObjects
{
    public class CompanyBaseResponse
    {
        
        public Error Error { get; set; }
    }

    
    public class CompanyAddressesResponse : CompanyBaseResponse
    {
        public List<Partner> ShipTos { get; set; }
        public List<Partner> BillTos { get; set; }
        //For now this is not needed but good chance it will be in the future
        [JsonIgnore]
        public List<Partner> SoldTos { get; set; }

    }

    
    public class CompanyContactsResponse : CompanyBaseResponse
    {
        
        public List<Contact> ContactList { get; set; }
    }

    
    public class CompanyInfoResponse : CompanyBaseResponse
    {
        
        public ERPHierarchy ERPHierarchy { get; set; }
    }

    
    public class CompanyAddress
    {
        
        public string Name1 { get; set; }
        
        public string Name2 { get; set; }
        
        public string Street { get; set; }
        
        public string City { get; set; }
        
        public string District { get; set; }
        
        public string Country { get; set; }
        
        public string PostalCode { get; set; }
        
        public string Region { get; set; }
        
        public bool RADFlag { get; set; }
        
        public string ParentAccount { get; set; }
    }

    
    public class Contact
    {
        
        public string Id { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string EmailAddress { get; set; }
        
        public string ParentAccount { get; set; }
    }

    
    public class ContactList
    {
        
        public List<Contact> Contact { get; set; }
    }


    
    public class Error
    {
        public string Description { get; set; }

        public string ErrorNumber { get; set; }
        
        public string ErrorType { get; set; }
    }

    
    public class ERPHierarchy
    {
        
        public string Number { get; set; }
        
        public string Name { get; set; }

        public ERPHierarchy(string number, string name)
        {
            Name = name;
            Number = number;
        }
    }
}