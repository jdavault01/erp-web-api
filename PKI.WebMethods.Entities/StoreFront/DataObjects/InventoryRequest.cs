using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using PKI.eBusiness.WMService.Entities.StoreFront.Account;
using PKI.eBusiness.WMService.Entities.StoreFront.ProductCatalog;
using PKI.eBusiness.WMWebApi.BusinessServices.Models.StoreFront.Accounts;

namespace PKI.eBusiness.WMService.Entities.StoreFront.DataObjects
{
    [DataContract]
    public class InventoryRequest : EntityBase
    {
        #region Properties

        [DataMember]
        public List<BasePartner> PartnerInfo { get; set; }

        [DataMember]
        public SalesArea SalesAreaInfo { get; set; }

        [DataMember]
        public List<InventoryRequestItem> Products { get; set; }

        #endregion


    }

    [DataContract]
    public class InventoryRequestItem : InventoryItem
    {
        [DataMember]
        public DateTime RequestedDate { get; set; }

    }
}
