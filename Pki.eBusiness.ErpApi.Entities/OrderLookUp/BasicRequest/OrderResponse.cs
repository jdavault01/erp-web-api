using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using Pki.eBusiness.ErpApi.Entities.Extensions;

namespace Pki.eBusiness.ErpApi.Entities.OrderLookUp.BasicRequest
{

    
    [XmlType(AnonymousType = true)]
    public class OrderSummaryResponse // EntityBase
    {
        //[XmlElement("Order")]
        //
        //public List<PurchaseOrder> OrderList { get; set; }
        [XmlElement(ElementName = "DateOfPlacingOrder", DataType = "string")]
        [DataMember(Name = "DateOrdered")]
        public string DateOfPlacingOrder { get; set; }

        
        public string OrderStatus { get; set; }
        [DataMember(Name = "PurchaseOrderNumber")]
        public string PurchaseOrderID { get; set; }
        public string ShipTo { get; set; }

        // [XmlElement(ElementName = "VAT", DataType = "string", Type = typeof(string))]
        public decimal VAT { get; set; }

        // [XmlElement(ElementName = "OrderValue", DataType = "string")]
        [DataMember(Name = "OrderTotal")]
        public decimal OrderValue { get; set; }

        public string ContactName { get; set; }

        [DataMember(Name = "OrderNumber")]
        public string SAPOrderNum { get; set; }

        
        public string Currency { get; set; }

        [DataMember(Name = "AttnRecipient")]
        public string ShipToAttention { get; set; }


    }
    
    [XmlType(AnonymousType = true)]
    public class OrderDetailResponse //: EntityBase
    {
        
        public List<OrderItem> OrderItems { get; set; }

        
        public List<OrderAddress> PartnerInfo { get; set; }

        [XmlElement(ElementName = "DateOfPlacingOrder", DataType = "string")]
        [DataMember(Name = "DateOrdered")]
        public string DateOfPlacingOrder { get; set; }
        public string OrderStatus { get; set; }
        [DataMember(Name = "PurchaseOrderNumber")]
        public string PurchaseOrderID { get; set; }
        public string ShipTo { get; set; }
        // [XmlElement(ElementName = "VAT", DataType = "string", Type = typeof(string))]
        
        public decimal VAT { get; set; }
        // [XmlElement(ElementName = "OrderValue", DataType = "string")]
        [DataMember(Name = "OrderTotal")]
        public decimal OrderValue { get; set; }
        public string ContactName { get; set; }
        [DataMember(Name = "OrderNumber")]
        public string SAPOrderNum { get; set; }
        
        public string Currency { get; set; }
        [DataMember(Name = "AttnRecipient")]
        public string ShipToAttention { get; set; }
        public CreditCard Card { get; set; }
        
        public decimal TotalPrice { get; set; }
        
        public string OrderType { get; set; }
        
        public decimal DeliveryCharges { get; set; }
        
        public decimal HandlingCharges { get; set; }
        
        public decimal OrderLevelTax { get; set; }
        //
        //public string Currency { get; set; }
        
        //[XmlElement("PONumber")]
        public string PoNumber { get; set; }
        
        public string TelephoneNumber { get; set; }
        
        public string AdditionalInfo { get; set; }
        
        public string SpecialHandlingInstructions { get; set; }
        
        [XmlIgnore]
        public DateTime? EstShipDate { get; set; }
        [XmlElement("EstShipDate")]
        public string EstShipDateString
        { 
            get { return EstShipDate.ToString(); }

            set { EstShipDate = value.GetDateTime(); }
        }

        
        [XmlIgnore]
        public DateTime? CustomerAcceptDate { get; set; }

        [XmlElement("CustomerAcceptDate")]
        public string CustomerAcceptDateString
        {
            get { return CustomerAcceptDate.ToString(); }

            set { CustomerAcceptDate = value.GetDateTime(); }
        }
        
        [XmlIgnore]
        public DateTime? ExpectedDeliveryDate { get; set; }

        [XmlElement("ExpectedDeliveryDate")]
        public string ExpectedDeliveryDateString
        {
            get { return ExpectedDeliveryDate.ToString(); }

            set { ExpectedDeliveryDate = value.GetDateTime(); }
        }

        
        public string CreditStatus { get; set; }
        
        public string DeliveryBlock { get; set; }

        public void UpdateDetails (OrderSummaryResponse orderSummary)
        {
            DateOfPlacingOrder = orderSummary.DateOfPlacingOrder;
            OrderStatus = orderSummary.OrderStatus;
            PurchaseOrderID = orderSummary.PurchaseOrderID;
            OrderValue = orderSummary.OrderValue;
            SAPOrderNum = orderSummary.SAPOrderNum;
            Currency = orderSummary.Currency;
            ShipToAttention = orderSummary.ShipToAttention;
        }

    }

    
    public class PurchaseOrder
    {
        [XmlElement(ElementName = "DateOfPlacingOrder",DataType = "string")]
        [DataMember(Name = "DateOrdered")]
        public string DateOfPlacingOrder { get; set; }

        
        public string OrderStatus { get; set; }
        [DataMember(Name = "PurchaseOrderNumber")]
        public string PurchaseOrderID { get; set; }
        public string ShipTo { get; set; }

        // [XmlElement(ElementName = "VAT", DataType = "string", Type = typeof(string))]
        public decimal VAT { get; set; }

        // [XmlElement(ElementName = "OrderValue", DataType = "string")]
        [DataMember(Name = "OrderTotal")]
        public decimal OrderValue { get; set; }

        public string ContactName { get; set; }

        [DataMember(Name = "OrderNumber")]
        public string SAPOrderNum { get; set; }

        
        public string Currency { get; set; }

        [DataMember(Name = "AttnRecipient")]
        public string ShipToAttention { get; set; }



    }

    
    public class OrderItem
    {
        [XmlAttribute]
        
        public string Id { get; set; }

        
        public string WebLineItemNO { get; set; }
        
        public string SAPLineItemNO { get; set; }
        
        public string Description { get; set; }
        
        public decimal Quantity { get; set; }
        
        public decimal AdjustedUnitPrice { get; set; }
        
        public decimal VAT { get; set; }
        
        public string ShippingPoint { get; set; }
        
        public string ExpectedShipDate { get; set; }
        
        public string Status { get; set; }
        
        public string Carrier { get; set; }
        
        public string TrackingNO { get; set; }
        
        public decimal PromotionalDiscount { get; set; }
        
        public string IsCourse { get; set; }
        
        public string ShipmentRoute { get; set; }
        
        public DateTime? ReceivedAtMIT { get; set; }
        
        public DateTime? ReleasedFromMIT { get; set; }
        
        public DateTime? PickedUpFromMIT { get; set; }
        
        public DateTime? ShipmentCreatedOn { get; set; }
        
        public DateTime? IssuedDate { get; set; }
        
        public decimal ExtendedPrice { get; set; }



    }
    
    public class CreditCard
    {
        
        public string Number { get; set; }

        //change to enum
        
        public string CardType { get; set; }


    }
    

    public class OrderAddress
    {
        //change to enum
        
        public Enumerations.AddressType Type { get; set; }

        
        public string Id { get; set; }

        
        public string Attention { get; set; }
        
        public string Name1 { get; set; }
        
        public string Name2 { get; set; }
        
        public string Name3 { get; set; }
        
        public string Name4 { get; set; }
        
        public bool RADIndicator { get; set; }
        
        public bool MarkedForDeletion { get; set; }
        
        public string Street { get; set; }
        
        public string PoBox { get; set; }

        
        public string PoBoxCity { get; set; }
        
        public string City { get; set; }
        
        public string District { get; set; }
        
        public string Country { get; set; }
        
        public string Fax { get; set; }
        
        public string PostalCode { get; set; }
        
        public string Region { get; set; }
        
        public string CityCode { get; set; }
        
        public string Telephone { get; set; }


    }
}


