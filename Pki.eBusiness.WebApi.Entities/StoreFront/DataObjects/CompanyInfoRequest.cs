using System.Runtime.Serialization;
using Pki.eBusiness.WebApi.Entities.StoreFront.Account;

namespace Pki.eBusiness.WebApi.Entities.StoreFront.DataObjects
{
    [DataContract]
    public class CompanyInfoRequest
    {
        [DataMember]
        public string ERPHierarchyNumber { get; set; }

        [DataMember]
        public string SalesOrg { get; set; }

        public SalesArea SaleaAreaInfo{ get; set; }

    }
    public class CompanyContactsRequest : CompanyInfoRequest
    {
        [DataMember]
        public string LastName { get; set; }
        public CompanyContactsRequest(string erpHierarchyNumber, string lastName) 
        {
            LastName = lastName;
        }
    }
    public class CompanyAddressesRequest : CompanyInfoRequest
    {
        [DataMember]
        public string ShipTo { get; set; }
        [DataMember]
        public string BillTo { get; set; }

    }
}
