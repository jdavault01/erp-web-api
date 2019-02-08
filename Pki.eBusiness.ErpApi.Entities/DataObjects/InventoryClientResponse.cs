using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Pki.eBusiness.ErpApi.Entities.DataObjects
{
    
    public class InventoryClientResponse
    {
        
        public String ErrorResponse { get; set; }

        public InventoryResponse InventoryResponse { get; set; }

        public InventoryClientResponse()
        {
            
        }

    }

    
    public class InventoryResponse
    {
        
        public InventoryResponseItem[] InventoryResponseItems { get; set; }

        
        public String ErrorMessage { get; set; }

        
        public List<FailedItem> FailedItems { get; set; }

    }

    
    public class FailedItem : InventoryItem
    {
        
        public string ErrorMessage { get; set; }
    }

    
    public class InventoryResponseItem : InventoryItem
    {
        
        public String ShippingPoint { get; set; }

        
        public string OrderLineNumber { get; set; }

        
        [JsonProperty(PropertyName = "Availability")]
        public Availability[] Availabilities { get; set; }

    }

    
    public class InventoryItem
    {
        
        public string ProductId { get; set; }

        
        public decimal Quantity { get; set; }

    }
}
