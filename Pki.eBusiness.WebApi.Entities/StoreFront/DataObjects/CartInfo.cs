using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Pki.eBusiness.WebApi.Entities.StoreFront.DataObjects
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
