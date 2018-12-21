using System;
using System.Collections.Generic;
using Pki.eBusiness.ErpApi.Entities.Account;

namespace Pki.eBusiness.ErpApi.Entities.DataObjects
{
    
    public class InventoryRequest : EntityBase
    {
        #region Properties
        public List<IPartner> PartnerInfo => new List<IPartner>
        {
            new Partner(ShipTo, PartnerType.ShipTo),
            new Partner(BillTo, PartnerType.BillTo)
        };

        
        public string SalesOrg { get; set; }

        
        public string ShipTo { get; set; }
        
        public string BillTo { get; set; }

        public SalesArea SalesAreaInfo => new SalesArea(SalesOrg);

        
        public List<InventoryRequestItem> Products { get; set; }

        #endregion


    }

    
    public class InventoryRequestItem : InventoryItem
    {
        
        public DateTime RequestedDate { get; set; }

    }
}
