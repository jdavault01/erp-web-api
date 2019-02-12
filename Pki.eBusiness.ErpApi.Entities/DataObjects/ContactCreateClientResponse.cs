using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Pki.eBusiness.ErpApi.Entities.Account;

namespace Pki.eBusiness.ErpApi.Entities.DataObjects
{

    public class ContactCreateClientRequest
    {
        public string FirstName { get; set; }

        
        public string LastName { get; set; }

        
        public string Email { get; set; }

        
        public string AccountNumber { get; set; }

        
        public string SalesOrg { get; set; }

        [JsonIgnore]
        public SalesArea SalesAreaInfo { get; set; }

        
        public string PhoneNumber { get; set; }

        [JsonIgnore]
        public List<PhoneNumber> PhoneNumbers { get; set; }

    }


    public struct PhoneNumber
    {
        
        public string Number { get; set; }

        
        public string Qualifier { get; set; }
    }


    public class ContactCreateClientResponse
    {
        
        public string ContactNameId { get; set; }

        public ContactCreateClientResponse(string contactNameId)
        {
            ContactNameId = contactNameId;
        }
    }
}
