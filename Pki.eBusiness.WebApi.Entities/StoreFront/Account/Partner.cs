using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Pki.eBusiness.WebApi.Entities.StoreFront.Account
{
    [DataContract(Name = "Partner")]
    public class BasePartner
    {

        public BasePartner()
        {
            
        }

        public BasePartner(string partnerId, PartnerType type)
        {
            PartnerId = partnerId;
            PartnerType = type;
        }
        [JsonIgnore]
        [DataMember]
        public bool MarkedForDeletion;
        [DataMember]
        public string PartnerId;
        [DataMember]
        public PartnerType PartnerType;
    }

    [DataContract]
    public class Partner : BasePartner
    {
        [DataMember] public string Name1;
        [DataMember] public string Name2;
        [DataMember] public string Name3;
        [DataMember] public string Name4;
        [DataMember] public string RadIndicator;
        [DataMember]
        public List<Address> Addresses { get; set; }
    }

    public enum PartnerType
    {
        ShipTo = 1,
        BillTo = 2,
        SoldTo = 3,
        ContactID = 4
    }

}

