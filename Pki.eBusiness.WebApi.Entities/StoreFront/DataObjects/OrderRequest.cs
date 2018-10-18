using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Pki.eBusiness.WebApi.Entities.StoreFront.Account;

namespace Pki.eBusiness.WebApi.Entities.StoreFront.DataObjects
{
    [DataContract]
    public class BaseOrderRequest
    {
        [DataMember]
        public SalesArea SalesAreaInfo { get; set; }
        [DataMember]
        public string Language { get; set; }
        [DataMember]
        public int NumberOfItems { get; set; }
        [DataMember]
        public List<Partner> Partners { get; set; }
        [DataMember]
        public List<OrderLineItem> OrderItems { get; set; }
        [DataMember]
        public string PromoCode { get; set; }
        [DataMember]
        public string PaymentType { get; set; }
        [DataMember]
        public WebOrderType OrderType { get; set; }
        [DataMember]
        public WebUserType UserType { get; set; }
        [DataMember]
        public bool ContainsInstrument { get; set; }
        [DataMember]
        public string CountryName { get; set; }

    }

    [DataContract]
    public class OrderLineItem
    {
        [DataMember]
        public int OrderLineNumber { get; set; }
        [DataMember]
        public string ProductID { get; set; }
        [DataMember]
        public decimal Quantity { get; set; }
        [DataMember]
        public string RequestedDate { get; set; }
        [DataMember]
        public string ShippingPoint { get; set; }
        [DataMember]
        public Availability Availability { get; set; }
        [DataMember]
        public string AdjustedPrice { get; set; }
        [DataMember]
        public string Discount { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string SpecialShippingInstructions { get; set; }
        [DataMember]
        public string TaxVAT { get; set; }
    }

    [DataContract]
    public class LineItem
    {
        [DataMember]
        public int OrderLineNumber { get; set; }
        [DataMember]
        public string ProductID { get; set; }
        [DataMember]
        public decimal Quantity { get; set; }
        [DataMember]
        public string RequestedDate { get; set; }
    }

    [DataContract]
    public class SimulateOrderRequest
    {
        [DataMember]
        public List<LineItem> OrderItems { get; set; }
        [DataMember]
        public string PromoCode { get; set; }
        [DataMember]
        public string SalesOrg { get; set; }
        public SalesArea SalesAreaInfo => new SalesArea(SalesOrg);
        [DataMember]
        public string Language { get; set; }
        [DataMember]
        public string ShipTo { get; set; }
        [DataMember]
        public string BillTo { get; set; }
        public List<IPartner> Partners => new List<IPartner>
        {
            new Partner(ShipTo, PartnerType.ShipTo),
            new Partner(BillTo, PartnerType.BillTo)
        };
    }

    [DataContract]
    public class CreateOrderRequest : BaseOrderRequest
    {
        [DataMember]
        public string AttentionLines { get; set; }
        [DataMember]
        public string AttentionLinesBillTo { get; set; }
        [DataMember]
        public string TelephoneNumber { get; set; }
        [DataMember]
        public string PromDeliveryBlockTextoCode { get; set; }
        [DataMember]
        public string DeliveryBlockStatus { get; set; }
        [DataMember]
        public string DeliveryBlockText { get; set; }
        [DataMember]
        public string PurchaseOrderID { get; set; }
        [DataMember]
        public CreditCardInfo CreditCard { get; set; }
        [DataMember]
        public string WebOrderNumber { get; set; }
        [DataMember]
        public string AltTAX { get; set; }
        [DataMember]
        public string VATNumber { get; set; }
        [DataMember]
        public string VATExpirationDate { get; set; }
        [DataMember]
        public string AdditionalInfo { get; set; }

    }

    public enum WebOrderType
    {
        Standard,
        Scheduled,
        MPO
    }

    public enum WebUserType
    {
        B2B,
        Dealer,
        Punchout
    }

    [DataContract]
    public class CreditCardInfo
    {
        [DataMember]
        public string CardNumber { get; set; }
        [DataMember]
        public string CardHolderName { get; set; }
        [DataMember]
        public string SecurityCode { get; set; }
        [DataMember]
        public string ExpirationMonth { get; set; }
        [DataMember]
        public string ExpirationYear { get; set; }
        [DataMember]
        public string CardType { get; set; }

    }

    [DataContract]
    public class Availability
    {
        [DataMember]
        public decimal AvailableQty { get; set; }
        [DataMember]
        public DateTime AvailableDate { get; set; }
    }
}
