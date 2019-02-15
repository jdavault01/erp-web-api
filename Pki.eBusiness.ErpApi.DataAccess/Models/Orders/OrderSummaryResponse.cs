using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using Pki.eBusiness.ErpApi.DataAccess.Extensions;

namespace Pki.eBusiness.ErpApi.DataAccess.Models.Orders
{
    [DataContract]
    [XmlType(AnonymousType = true)]
    public class OrderSummaryResponse // EntityBase
    {
        //[XmlElement("Order")]
        //[DataMember]
        //public List<PurchaseOrder> OrderList { get; set; }
        [XmlElement(ElementName = "DateOfPlacingOrder", DataType = "string")]
        [DataMember(Name = "DateOrdered")]
        public string DateOfPlacingOrder { get; set; }

        [DataMember]
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

        [DataMember]
        public string Currency { get; set; }

        [DataMember(Name = "AttnRecipient")]
        public string ShipToAttention { get; set; }


    }
    //[DataContract]
    //[XmlType(AnonymousType = true)]
    //public class OrderDetailResponse //: EntityBase
    //{
    //    [DataMember]
    //    public List<OrderItem> OrderItems { get; set; }

    //    [DataMember]
    //    public List<OrderAddress> PartnerInfo { get; set; }

    //    [XmlElement(ElementName = "DateOfPlacingOrder", DataType = "string")]
    //    [DataMember(Name = "DateOrdered")]
    //    public string DateOfPlacingOrder { get; set; }
    //    public string OrderStatus { get; set; }
    //    [DataMember(Name = "PurchaseOrderNumber")]
    //    public string PurchaseOrderID { get; set; }
    //    public string ShipTo { get; set; }
    //    // [XmlElement(ElementName = "VAT", DataType = "string", Type = typeof(string))]
    //    [DataMember]
    //    public decimal VAT { get; set; }
    //    // [XmlElement(ElementName = "OrderValue", DataType = "string")]
    //    [DataMember(Name = "OrderTotal")]
    //    public decimal OrderValue { get; set; }
    //    public string ContactName { get; set; }
    //    [DataMember(Name = "OrderNumber")]
    //    public string SAPOrderNum { get; set; }
    //    [DataMember]
    //    public string Currency { get; set; }
    //    [DataMember(Name = "AttnRecipient")]
    //    public string ShipToAttention { get; set; }
    //    public CreditCard Card { get; set; }
    //    [DataMember]
    //    public decimal TotalPrice { get; set; }
    //    [DataMember]
    //    public string OrderType { get; set; }
    //    [DataMember]
    //    public decimal DeliveryCharges { get; set; }
    //    [DataMember]
    //    public decimal HandlingCharges { get; set; }
    //    [DataMember]
    //    public decimal OrderLevelTax { get; set; }
    //    //[DataMember]
    //    //public string Currency { get; set; }
    //    [DataMember]
    //    //[XmlElement("PONumber")]
    //    public string PoNumber { get; set; }
    //    [DataMember]
    //    public string TelephoneNumber { get; set; }
    //    [DataMember]
    //    public string AdditionalInfo { get; set; }
    //    [DataMember]
    //    public string SpecialHandlingInstructions { get; set; }
    //    [DataMember]
    //    [XmlIgnore]
    //    public DateTime? EstShipDate { get; set; }
    //    [XmlElement("EstShipDate")]
    //    public string EstShipDateString
    //    {
    //        get { return EstShipDate.ToString(); }

    //        set { EstShipDate = value.GetDateTime(); }
    //    }

    //    [DataMember]
    //    [XmlIgnore]
    //    public DateTime? CustomerAcceptDate { get; set; }

    //    [XmlElement("CustomerAcceptDate")]
    //    public string CustomerAcceptDateString
    //    {
    //        get { return CustomerAcceptDate.ToString(); }

    //        set { CustomerAcceptDate = value.GetDateTime(); }
    //    }
    //    [DataMember]
    //    [XmlIgnore]
    //    public DateTime? ExpectedDeliveryDate { get; set; }

    //    [XmlElement("ExpectedDeliveryDate")]
    //    public string ExpectedDeliveryDateString
    //    {
    //        get { return ExpectedDeliveryDate.ToString(); }

    //        set { ExpectedDeliveryDate = value.GetDateTime(); }
    //    }

    //    [DataMember]
    //    public string CreditStatus { get; set; }
    //    [DataMember]
    //    public string DeliveryBlock { get; set; }

    //    public void UpdateDetails(OrderSummaryResponse orderSummary)
    //    {
    //        DateOfPlacingOrder = orderSummary.DateOfPlacingOrder;
    //        OrderStatus = orderSummary.OrderStatus;
    //        PurchaseOrderID = orderSummary.PurchaseOrderID;
    //        OrderValue = orderSummary.OrderValue;
    //        SAPOrderNum = orderSummary.SAPOrderNum;
    //        Currency = orderSummary.Currency;
    //        ShipToAttention = orderSummary.ShipToAttention;
    //    }

    //}

    [DataContract]
    public class PurchaseOrder
    {
        [XmlElement(ElementName = "DateOfPlacingOrder", DataType = "string")]
        [DataMember(Name = "DateOrdered")]
        public string DateOfPlacingOrder { get; set; }

        [DataMember]
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

        [DataMember]
        public string Currency { get; set; }

        [DataMember(Name = "AttnRecipient")]
        public string ShipToAttention { get; set; }



    }

    [DataContract]
    public class OrderItem
    {
        [XmlAttribute]
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string WebLineItemNO { get; set; }
        [DataMember]
        public string SAPLineItemNO { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public decimal Quantity { get; set; }
        [DataMember]
        public decimal AdjustedUnitPrice { get; set; }
        [DataMember]
        public decimal VAT { get; set; }
        [DataMember]
        public string ShippingPoint { get; set; }
        [DataMember]
        public string ExpectedShipDate { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public string Carrier { get; set; }
        [DataMember]
        public string TrackingNO { get; set; }
        [DataMember]
        public decimal PromotionalDiscount { get; set; }
        [DataMember]
        public string IsCourse { get; set; }
        [DataMember]
        public string ShipmentRoute { get; set; }
        [DataMember]
        public DateTime? ReceivedAtMIT { get; set; }
        [DataMember]
        public DateTime? ReleasedFromMIT { get; set; }
        [DataMember]
        public DateTime? PickedUpFromMIT { get; set; }
        [DataMember]
        public DateTime? ShipmentCreatedOn { get; set; }
        [DataMember]
        public DateTime? IssuedDate { get; set; }
        [DataMember]
        public decimal ExtendedPrice { get; set; }



    }
    [DataContract]
    public class CreditCard
    {
        [DataMember]
        public string Number { get; set; }

        //change to enum
        [DataMember]
        public string CardType { get; set; }


    }

    public class Enumerations
    {
        public enum AddressType
        {
            BillEng = 1,
            BillTo = 2,
            ShipTo = 3,
            ShipEng = 4,
            SoldTo = 5

        }


    }
    [DataContract]

    public class OrderAddress
    {
        //change to enum
        [DataMember]
        public Enumerations.AddressType Type { get; set; }

        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string Attention { get; set; }
        [DataMember]
        public string Name1 { get; set; }
        [DataMember]
        public string Name2 { get; set; }
        [DataMember]
        public string Name3 { get; set; }
        [DataMember]
        public string Name4 { get; set; }
        [DataMember]
        public bool RADIndicator { get; set; }
        [DataMember]
        public bool MarkedForDeletion { get; set; }
        [DataMember]
        public string Street { get; set; }
        [DataMember]
        public string PoBox { get; set; }

        [DataMember]
        public string PoBoxCity { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string District { get; set; }
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public string Fax { get; set; }
        [DataMember]
        public string PostalCode { get; set; }
        [DataMember]
        public string Region { get; set; }
        [DataMember]
        public string CityCode { get; set; }
        [DataMember]
        public string Telephone { get; set; }


    }
}
