using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using PKI.eBusiness.WMService.Entities.StoreFront.Account;
using PKI.eBusiness.WMWebApi.BusinessServices.Models.StoreFront.Accounts;

namespace PKI.eBusiness.WMService.Entities.StoreFront.DataObjects
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
