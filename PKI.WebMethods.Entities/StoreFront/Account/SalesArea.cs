using System.Runtime.Serialization;

namespace PKI.eBusiness.WMWebApi.BusinessServices.Models.StoreFront.Accounts
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
