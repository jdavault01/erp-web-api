using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using Pki.eBusiness.ErpApi.Entities.Extensions;

namespace Pki.eBusiness.ErpApi.Entities.OrderLookUp.BasicRequest
{

    [DataContract]
    [XmlType(AnonymousType = true)]
    public class OrderDetailResponse 
    {
        [DataMember, XmlIgnore]
        public List<OrderItem> OrderItems { get; set; }
        [DataMember, XmlIgnore]
        public List<OrderAddress> PartnerInfo { get; set; }
        [DataMember, XmlIgnore]
        [XmlElement(ElementName = "CreditCardNumber")]
        public string CreditCardNumber { get; set; }
        [XmlIgnore]
        [XmlElement(ElementName = "CreditCardType")]
        public CreditCard Card { get; set; }
        [XmlElement(ElementName = "ItemList")]
        public ItemList ItemList { get; set; }
        [XmlElement(ElementName = "DateOfPlacingOrder", DataType = "string")]
        [DataMember(Name = "DateOrdered")]
        public string DateOfPlacingOrder { get; set; }
        public string OrderStatus { get; set; }
        [DataMember(Name = "PurchaseOrderNumber")]
        public string PurchaseOrderID { get; set; }
        //public string ShipTo { get; set; }
        [DataMember]
        public decimal VAT { get; set; }
        [DataMember(Name = "OrderTotal")]
        public decimal OrderValue { get; set; }
        public string ContactName { get; set; }
        [DataMember(Name = "OrderNumber")]
        public string SAPOrderNum { get; set; }
        [DataMember]
        public string Currency { get; set; }
        [DataMember(Name = "AttnRecipient")]
        public string ShipToAttention { get; set; }

        [XmlElement(ElementName = "BillTo")]
        public BillToAddress BillTo { get; set; }
        [XmlElement(ElementName = "ShipTo")]
        public ShipToAddress ShipTo { get; set; }

        [XmlIgnore]
        public string CreditCardType { get; set; }
        [DataMember]
        public decimal TotalPrice { get; set; }
        [DataMember]
        public string OrderType { get; set; }
        [DataMember]
        public decimal DeliveryCharges { get; set; }
        [DataMember]
        public decimal HandlingCharges { get; set; }
        [DataMember]
        public decimal OrderLevelTax { get; set; }
        [DataMember]
        public string PoNumber { get; set; }
        [DataMember]
        public string TelephoneNumber { get; set; }
        [DataMember]
        public string AdditionalInfo { get; set; }
        [DataMember]
        public string SpecialHandlingInstructions { get; set; }
        [DataMember]
        [XmlIgnore]
        public DateTime? EstShipDate { get; set; }
        [XmlElement("EstShipDate")]
        public string EstShipDateString
        {
            get { return EstShipDate.ToString(); }

            set { EstShipDate = value.GetDateTime(); }
        }

        [DataMember]
        [XmlIgnore]
        public DateTime? CustomerAcceptDate { get; set; }

        [XmlElement("CustomerAcceptDate")]
        public string CustomerAcceptDateString
        {
            get { return CustomerAcceptDate.ToString(); }

            set { CustomerAcceptDate = value.GetDateTime(); }
        }
        [DataMember]
        [XmlIgnore]
        public DateTime? ExpectedDeliveryDate { get; set; }

        [XmlElement("ExpectedDeliveryDate")]
        public string ExpectedDeliveryDateString
        {
            get { return ExpectedDeliveryDate.ToString(); }

            set { ExpectedDeliveryDate = value.GetDateTime(); }
        }

        [DataMember]
        public string CreditStatus { get; set; }
        [DataMember]
        public string DeliveryBlock { get; set; }

       public void AddOrderSummary(OrderSummaryResponse orderSummary)
        {
            DateOfPlacingOrder = orderSummary.DateOfPlacingOrder;
            OrderStatus = orderSummary.OrderStatus;
            PurchaseOrderID = orderSummary.PurchaseOrderID;
            OrderValue = orderSummary.OrderValue;
            SAPOrderNum = orderSummary.SAPOrderNum;
            Currency = orderSummary.Currency;
            ShipToAttention = orderSummary.ShipToAttention;
        }

        public List<OrderAddress> GetOrderAddresses()
        {
            var addrList = new List<OrderAddress>();
            var billToAddress = new OrderAddress
            {
                Type = Enumerations.AddressType.BillTo,
                Id = BillTo.Id,
                Attention = BillTo.BillToAttention,
                Name1 = BillTo.Name1,
                Name2 = BillTo.Name2,
                Name3 = BillTo.Name3,
                Name4 = BillTo.Name4,
                RADIndicator = BillTo.RADIndicator.ToLower() == "true" ? true : false,
                MarkedForDeletion = BillTo.MarkedForDeletion.ToLower() == "true" ? true : false,
                Street = BillTo.Address.Street,
                PoBox = BillTo.Address.POBox,
                PoBoxCity = BillTo.Address.POBoxCity,
                City = BillTo.Address.City,
                District = BillTo.Address.District,
                Country = BillTo.Address.Country,
                Fax = BillTo.Address.Fax,
                PostalCode = BillTo.Address.PostalCode,
                Region = BillTo.Address.Region,
                CityCode = BillTo.Address.CityCode,
                Telephone = BillTo.Address.Telephone.Text

            };

            var shipToAddress = new OrderAddress
            {
                Type = Enumerations.AddressType.ShipTo,
                Id = ShipTo.Id,
                Attention = ShipTo.ShipToAttention,
                Name1 = ShipTo.Name1,
                Name2 = ShipTo.Name2,
                Name3 = ShipTo.Name3,
                Name4 = ShipTo.Name4,
                RADIndicator = ShipTo.RADIndicator.ToLower() == "true" ? true : false,
                MarkedForDeletion = ShipTo.MarkedForDeletion.ToLower() == "true" ? true : false,
                Street = ShipTo.Address.Street,
                PoBox = ShipTo.Address.POBox,
                PoBoxCity = ShipTo.Address.POBoxCity,
                City = ShipTo.Address.City,
                District = ShipTo.Address.District,
                Country = ShipTo.Address.Country,
                Fax = ShipTo.Address.Fax,
                PostalCode = ShipTo.Address.PostalCode,
                Region = ShipTo.Address.Region,
                CityCode = ShipTo.Address.CityCode,
                Telephone = ShipTo.Address.Telephone.Text

            };

            addrList.Add(billToAddress);
            addrList.Add(shipToAddress);
            return addrList;
        }
        public List<OrderItem> GetProducts()
        {
            var products = new List<OrderItem>();
            var item = new OrderItem();
            foreach( Product p in ItemList.Products)
            {
                item.AdjustedUnitPrice = Convert.ToDecimal(p.AdjustedUnitPrice);
                item.Id = p.Id;
                item.WebLineItemNO = p.WebLineItemNO;
                item.SAPLineItemNO = p.SAPLineItemNO;
                item.Description = p.Description;
                item.Quantity = Decimal.Parse(p.Quantity);
                item.VAT = Decimal.Parse(p.VAT);
                item.ShippingPoint = p.ShippingPoint;
                item.ExpectedShipDate = p.ExpectedShipDate;
                item.Status = p.Status;
                item.Carrier = p.Carrier;
                item.TrackingNO = p.TrackingNO;
                item.PromotionalDiscount = Convert.ToDecimal(p.PromotionalDiscount);
                item.IsCourse = p.IsCourse;
                item.ShipmentRoute = p.ShipmentRoute;
                item.ReceivedAtMIT = String.IsNullOrEmpty(p.ReceivedAtMIT) ? (DateTime?)null : DateTime.Parse(p.ReceivedAtMIT);
                item.ReleasedFromMIT = String.IsNullOrEmpty(p.ReleasedFromMIT) ? (DateTime?)null : DateTime.Parse(p.ReleasedFromMIT);
                item.PickedUpFromMIT = String.IsNullOrEmpty(p.PickedUpFromMIT) ? (DateTime?)null : DateTime.Parse(p.PickedUpFromMIT);
                item.ShipmentCreatedOn = String.IsNullOrEmpty(p.ShipmentCreatedOn) ? (DateTime?)null : DateTime.Parse(p.ShipmentCreatedOn);
                item.ExtendedPrice = Decimal.Parse(p.ExtendedPrice);
                products.Add(item);
            };

            return products;
        }

        public CreditCard GetCreditCard()
        {
            return new CreditCard
            {
                Number = this.CreditCardNumber,
                CardType = this.CreditCardType
            };
        }



    }

    [XmlRoot(ElementName = "ItemList")]
    public class ItemList
    {
        [XmlElement(ElementName = "Product")]
        public Product[] Products { get; set; }
    }

    [XmlType("Product")]
    [XmlRoot(ElementName = "Product")]
    public class Product
    {
        //[XmlAttribute(AttributeName = "id")]
        [XmlAttribute("id", DataType = "string")]
        public string Id { get; set; }
        //[XmlText]
        //public string Text { get; set; }
        [XmlElement(ElementName = "WebLineItemNO")]
        public string WebLineItemNO { get; set; }
        [XmlElement(ElementName = "SAPLineItemNO")]
        public string SAPLineItemNO { get; set; }
        [XmlElement(ElementName = "Description")]
        public string Description { get; set; }
        [XmlElement(ElementName = "Quantity")]
        public string Quantity { get; set; }
        [XmlElement(ElementName = "AdjustedUnitPrice")]
        public string AdjustedUnitPrice { get; set; }
        [XmlElement(ElementName = "VAT")]
        public string VAT { get; set; }
        [XmlElement(ElementName = "ShippingPoint")]
        public string ShippingPoint { get; set; }
        [XmlElement(ElementName = "ExpectedShipDate")]
        public string ExpectedShipDate { get; set; }
        [XmlElement(ElementName = "Status")]
        public string Status { get; set; }
        [XmlElement(ElementName = "Carrier")]
        public string Carrier { get; set; }
        [XmlElement(ElementName = "TrackingNO")]
        public string TrackingNO { get; set; }
        [XmlElement(ElementName = "PromotionalDiscount")]
        public string PromotionalDiscount { get; set; }
        [XmlElement(ElementName = "IsCourse")]
        public string IsCourse { get; set; }
        [XmlElement(ElementName = "ShipmentRoute")]
        public string ShipmentRoute { get; set; }
        [XmlElement(ElementName = "ReceivedAtMIT")]
        public string ReceivedAtMIT { get; set; }
        [XmlElement(ElementName = "ReleasedFromMIT")]
        public string ReleasedFromMIT { get; set; }
        [XmlElement(ElementName = "PickedUpFromMIT")]
        public string PickedUpFromMIT { get; set; }
        [XmlElement(ElementName = "ShipmentCreatedOn")]
        public string ShipmentCreatedOn { get; set; }
        [XmlElement(ElementName = "IssuedDate")]
        public string IssuedDate { get; set; }
        [XmlElement(ElementName = "ExtendedPrice")]
        public string ExtendedPrice { get; set; }

    }

    [XmlRoot(ElementName = "ShipTo")]
    public class ShipToAddress
    {
        [XmlElement(ElementName = "ShipToAttention")]
        public string ShipToAttention { get; set; }
        [XmlElement(ElementName = "Name1")]
        public string Name1 { get; set; }
        [XmlElement(ElementName = "Name2")]
        public string Name2 { get; set; }
        [XmlElement(ElementName = "Name3")]
        public string Name3 { get; set; }
        [XmlElement(ElementName = "Name4")]
        public string Name4 { get; set; }
        [XmlElement(ElementName = "RADIndicator")]
        public string RADIndicator { get; set; }
        [XmlElement(ElementName = "MarkedForDeletion")]
        public string MarkedForDeletion { get; set; }
        [XmlElement(ElementName = "Address")]
        public Address Address { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
    }

    [XmlRoot(ElementName = "BillTo")]
    public class BillToAddress
    {
        [XmlElement(ElementName = "BillToAttention")]
        public string BillToAttention { get; set; }
        [XmlElement(ElementName = "Name1")]
        public string Name1 { get; set; }
        [XmlElement(ElementName = "Name2")]
        public string Name2 { get; set; }
        [XmlElement(ElementName = "Name3")]
        public string Name3 { get; set; }
        [XmlElement(ElementName = "Name4")]
        public string Name4 { get; set; }
        [XmlElement(ElementName = "RADIndicator")]
        public string RADIndicator { get; set; }
        [XmlElement(ElementName = "MarkedForDeletion")]
        public string MarkedForDeletion { get; set; }
        [XmlElement(ElementName = "Address")]
        public Address Address { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
    }

    [XmlRoot(ElementName = "Address")]
    public class Address
    {
        [XmlElement(ElementName = "Street")]
        public string Street { get; set; }
        [XmlElement(ElementName = "POBox")]
        public string POBox { get; set; }
        [XmlElement(ElementName = "POBoxCity")]
        public string POBoxCity { get; set; }
        [XmlElement(ElementName = "City")]
        public string City { get; set; }
        [XmlElement(ElementName = "District")]
        public string District { get; set; }
        [XmlElement(ElementName = "Country")]
        public string Country { get; set; }
        [XmlElement(ElementName = "Fax")]
        public string Fax { get; set; }
        [XmlElement(ElementName = "PostalCode")]
        public string PostalCode { get; set; }
        [XmlElement(ElementName = "Region")]
        public string Region { get; set; }
        [XmlElement(ElementName = "CityCode")]
        public string CityCode { get; set; }
        [XmlElement(ElementName = "Telephone")]
        public Telephone Telephone { get; set; }
    }

    [XmlRoot(ElementName = "Telephone")]
    public class Telephone
    {
        [XmlAttribute(AttributeName = "qualifier")]
        public string Qualifier { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

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
    [DataContract]

    public class Enumerations
    {
        public enum AddressType
        {
            BillEng = 1,
            BillTo = 2,
            ShipTo=3,
            ShipEng=4,
            SoldTo=5
        }
    }

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
 


