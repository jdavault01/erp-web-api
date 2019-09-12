using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Pki.eBusiness.ErpApi.Entities.Account
{
    public class Partner : Address, IPartner
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string Name3 { get; set; }
        public string Name4 { get; set; }
        public bool RadIndicator { get; set; }
        public string PartnerId { get; set; }

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

