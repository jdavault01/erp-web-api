using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Pki.eBusiness.WebApi.Entities.StoreFront.Account;

namespace Pki.eBusiness.WebApi.Entities.StoreFront.DataObjects
{
    [DataContract]
    public class InventoryRequest : EntityBase
    {
        #region Properties
        public List<IPartner> PartnerInfo => new List<IPartner>
        {
            new Partner(ShipTo, PartnerType.ShipTo),
            new Partner(BillTo, PartnerType.BillTo)
        };

        [DataMember]
        public string SalesOrg { get; set; }

        [DataMember]
        public string ShipTo { get; set; }
        [DataMember]
        public string BillTo { get; set; }

        public SalesArea SalesAreaInfo => new SalesArea(SalesOrg);

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
