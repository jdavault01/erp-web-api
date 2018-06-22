using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

using System.Linq;
using System.Text;

namespace PKI.eBusiness.WMService.Entities.StoreFront.Orders
{
    [DataContract]
    public class CartInfo
    {
        [DataMember(IsRequired = true)]
        public List<CartInfoItem> CartItems { get; set; }
    }

    [DataContract]
    public class CartInfoItem
    {
        [DataMember(IsRequired = true)]
        public string CartId { get; set; }

        [DataMember(IsRequired = true)]
        public string ItemId { get; set; }

        [DataMember]
        public string ClearanceCode { get; set; }
    }
}
