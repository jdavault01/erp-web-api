using Newtonsoft.Json;
using Pki.eBusiness.ErpApi.Entities.Account;

namespace Pki.eBusiness.ErpApi.Entities.DataObjects
{
    
    public class CompanyInfoRequest
    {
        
        public string ERPHierarchyNumber { get; set; }

        
        public string SalesOrg { get; set; }

        [JsonIgnore]
         public SalesArea SaleaAreaInfo{ get; set; }

    }
    public class CompanyContactsRequest : CompanyInfoRequest
    {
        
        public string Name { get; set; }
    }
    public class CompanyAddressesRequest : CompanyInfoRequest
    {
        
        public string ShipTo { get; set; }
        
        public string BillTo { get; set; }

    }
}
