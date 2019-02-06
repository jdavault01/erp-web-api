using System;
using System.Collections.Generic;

namespace Pki.eBusiness.ErpApi.Entities.DataObjects
{
    public class PunchoutOrderMessageResponse
    {
        public String PunchoutOrderMessage { get; set; }
    }

    public class PunchOutOrderMessageRequest
    {
        public string Source { get; set; }
        [Required]
        public string CustomerCode { get; set; }
        [Required]
        public string BuyerCookie { get; set; }
        public string Operation { get; set; }
        public string Currency { get; set; }
        public decimal OrderTotal { get; set; }
        public decimal Tax { get; set; }
        public string ShippingCost { get; set; }
        [Required]
        public List<Item> Items { get; set; }
        [Required]
        public string Format { get; set; }
    }

    //[DataContract]
    public class Extrinsic
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    //[DataContract]
    public class Item
    {
        public string SupplierPartID { get; set; }
        public string SupplierPartAuxilaryID { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Quantity { get; set; }
        public string Description { get; set; }
        public string UnitOfMeasure { get; set; }
        public int LeadTime { get; set; }
        public string InternalSupplierID { get; set; }
        public string UNSPSC { get; set; }
        public string ManufacturerPartID { get; set; }
        public string ManufacturerName { get; set; }
        public string ItemText { get; set; }
        public string Hazardous { get; set; }
        public List<Extrinsic> Extrinsics { get; set; }
    }
}