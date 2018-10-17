using System.Runtime.Serialization;

namespace Pki.eBusiness.WebApi.Entities.StoreFront.Account
{
     [DataContract]
    public class SalesArea
    {
        private string salesOrg;

        public SalesArea(string salesOrg)
        {
            this.SalesOrgId = salesOrg;
            DistChannelId = "01";
            DivisionId = "02";
        }

        [DataMember]
        public string SalesOrgId { get; set; }
        [DataMember]
        public string DistChannelId { get; set; }
        [DataMember]
        public string DivisionId { get; set; }

    }
}
