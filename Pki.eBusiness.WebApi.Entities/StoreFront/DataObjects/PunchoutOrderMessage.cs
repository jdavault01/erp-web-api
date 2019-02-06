using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Pki.eBusiness.WebApi.Entities.StoreFront.DataObjects
{

    [DataContract]
    public class PunchoutOrderMessageResponse
    {
        [DataMember]
        public String PunchoutOrderMessage { get; set; }
    }

    [DataContract]
    public class PunchOutOrderMessageRequest
    {
        [DataMember]
        public string Source { get; set; }
        [DataMember,Required]
        public string CustomerCode { get; set; }
        [DataMember, Required]
        public string BuyerCookie { get; set; }
        [DataMember]
        public string Operation { get; set; }
        [DataMember]
        public string Currency { get; set; }
        [DataMember]
        public decimal OrderTotal { get; set; }
        [DataMember]
        public decimal Tax { get; set; }
        [DataMember]
        public string ShippingCost { get; set; }
        [DataMember,Required]
        public List<Item> Items { get; set; }
        [DataMember,Required]
        public string Format { get; set; }
    }

    [DataContract]
    public class Extrinsic
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Value { get; set; }
    }

    [DataContract]
    public class Item
    {
        [DataMember]
        public string SupplierPartID { get; set; }
        [DataMember]
        public string SupplierPartAuxilaryID { get; set; }
        [DataMember]
        public decimal UnitPrice { get; set; }
        [DataMember]
        public decimal Quantity { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string UnitOfMeasure { get; set; }
        [DataMember]
        public int LeadTime { get; set; }
        [DataMember]
        public string InternalSupplierID { get; set; }
        [DataMember]
        public string UNSPSC { get; set; }
        [DataMember]
        public string ManufacturerPartID { get; set; }
        [DataMember]
        public string ManufacturerName { get; set; }
        [DataMember]
        public string ItemText { get; set; }
        [DataMember]
        public string Hazardous { get; set; }
        [DataMember]
        public List<Extrinsic> Extrinsics { get; set; }
    }
}
