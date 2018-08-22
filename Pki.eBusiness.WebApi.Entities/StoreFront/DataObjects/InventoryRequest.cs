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
