using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
namespace PKI.eBusiness.WMService.Entities.StoreFront.DataObjects
{
    [DataContract]
    public class InventoryClientResponse
    {
        [DataMember]
        public String ErrorResponse { get; set; }

        public InventoryResponse InventoryResponse { get; set; }

        public InventoryClientResponse()
        {
            
        }

    }

    [DataContract]
    public class InventoryResponse
    {
        [DataMember]
        public InventoryResponseItem[] InventoryResponseItems { get; set; }

        [DataMember]
        public String ErrorMessage { get; set; }

        [DataMember]
        public List<FailedItem> FailedItems { get; set; }

    }

    [DataContract]
    public class FailedItem : InventoryItem
    {
        [DataMember]
        public string ErrorMessage { get; set; }
    }

    [DataContract]
    public class InventoryResponseItem : InventoryItem
    {
        [DataMember]
        public String ShippingPoint { get; set; }

        [DataMember]
        public string OrderLineNumber { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "Availability")]
        public Availability[] Availabilities { get; set; }

    }

    [DataContract]
    public class InventoryItem
    {
        [DataMember]
        public string ProductId { get; set; }

        [DataMember]
        public decimal Quantity { get; set; }

    }
}
