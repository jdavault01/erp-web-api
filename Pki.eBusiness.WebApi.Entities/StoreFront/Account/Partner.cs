using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Pki.eBusiness.WebApi.Entities.StoreFront.Account
{
    [DataContract]
    public class Partner : Address, IPartner
    {
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public bool RadIndicator { get; set; }
        [DataMember]
        public string PartnerId { get; set; }
        [DataMember]
        public PartnerType PartnerType { get; set; }

        public Partner()
        {
            
        }

        public Partner(string partnerId, PartnerType partnerType)
        {
            PartnerId = partnerId;
            PartnerType = partnerType;
        }
    }



}

