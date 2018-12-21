using System.Collections.Generic;
using Pki.eBusiness.ErpApi.Entities.Account;

namespace Pki.eBusiness.ErpApi.Entities.DataObjects
{

    
    public class ContactCreateRequest
    {
        
        public string FirstName { get; set; }

        
        public string LastName { get; set; }

        
        public string Email { get; set; }

        
        public string AccountNumber { get; set; }

        
        public string SalesOrg { get; set; }

        public SalesArea SalesAreaInfo { get; set; }

        
        public string PhoneNumber { get; set; }

        public List<PhoneNumber> PhoneNumbers { get; set; }

    }

    
    public struct PhoneNumber
    {
        
        public string Number { get; set; }

        
        public string Qualifier { get; set; }
    }

    
    public class ContactCreateResponse
    {
        
        public string ContactNameId { get; set; }

        public ContactCreateResponse(string contactNameId)
        {
            ContactNameId = contactNameId;
        }
    }
}
