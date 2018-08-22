using System.Runtime.Serialization;

namespace Pki.eBusiness.WebApi.Entities.StoreFront.Account
{
     [DataContract]
    public class SalesArea
    {
        [DataMember]
        public string SalesOrgId { get; set; }
        [DataMember]
        public string DistChannelId { get; set; }
        [DataMember]
        public string DivisionId { get; set; }

    }
}
