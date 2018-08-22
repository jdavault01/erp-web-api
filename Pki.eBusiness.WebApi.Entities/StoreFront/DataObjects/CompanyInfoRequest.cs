using System.Runtime.Serialization;
using Pki.eBusiness.WebApi.Entities.StoreFront.Account;

namespace Pki.eBusiness.WebApi.Entities.StoreFront.DataObjects
{
    [DataContract]
    public class CompanyNameRequest
    {
        [DataMember]
        public string CompanyName { get; set; }
        [DataMember]
        public string ERPHierarchyNumber { get; set; }
        [DataMember]
        public SalesArea SalesAreaInfo { get; set; }
    }

    [DataContract]
    public class CompanyContactsRequest : CompanyNameRequest
    {
        [DataMember]
        public string LastName { get; set; }
      
    }

    [DataContract]
    public class CompanyAddressesRequest : CompanyNameRequest
    {
        [DataMember]
        public string ShipTo { get; set; }
        [DataMember]
        public string BillTo { get; set; }
    }

}
