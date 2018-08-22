﻿using System.Runtime.Serialization;

namespace Pki.eBusiness.WebApi.Entities.Orders
{    
    /// <summary>
    /// Order Request Detail
    /// </summary>
    [DataContract]
    public class OrderRequestDetail : EntityBase
    {
        #region Properties

        [DataMember]
        public string OrderItemID { get; set; }
        [DataMember]
        public string OrderItemSequence { get; set; }
        [DataMember]
        public string ItemID { get; set; }
        [DataMember]
        public string ItemPrice { get; set; }
        [DataMember]
        public string FilterPaperNumber { get; set; }
        [DataMember]
        public string OrigFilterPaperNumber { get; set; }
        [DataMember]
        public string GiftWrapMessage { get; set; }
        [DataMember]
        public string Qty { get; set; }

        [DataMember]
        public Patient[] Patients { get; set; }
        #endregion // Properties

    }
}