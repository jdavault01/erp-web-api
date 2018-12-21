using System;
using System.Collections.Generic;
using Pki.eBusiness.ErpApi.Entities.Account;

namespace Pki.eBusiness.ErpApi.Entities.DataObjects
{
    
    public class BaseOrderRequest
    {
        //public SalesArea SalesAreaInfo { get; set; }
        
        public string Language { get; set; }
        
        public List<OrderLineItem> OrderItems { get; set; }
        
        public string PromoCode { get; set; }
        
        public string PaymentType { get; set; }
        
        public WebOrderType OrderType { get; set; }
        
        public WebUserType UserType { get; set; }
        
        public bool ContainsInstrument { get; set; }
        
        public string CountryName { get; set; }

    }

    
    public class OrderLineItem : LineItem
    {
        
        public string SpecialShippingInstructions { get; set; }
        
        public string Description { get; set; }
        
        public string ShippingPoint { get; set; }
        
        public Availability Availability { get; set; }
        
        public string AdjustedPrice { get; set; }
        
        public string Discount { get; set; }
        
        public string TaxVAT { get; set; }

    }

    
    public class LineItem
    {
        
        public int OrderLineNumber { get; set; }
        
        public string ProductID { get; set; }
        
        public decimal Quantity { get; set; }
        
        public string RequestedDate { get; set; }

    }

    
    public class SimulateOrderRequest
    {
        
        public List<LineItem> OrderItems { get; set; }
        
        public string PromoCode { get; set; }
        
        public string SalesOrg { get; set; }
        public SalesArea SalesAreaInfo => new SalesArea(SalesOrg);
        
        public string Language { get; set; }
        
        public string ShipTo { get; set; }
        
        public string BillTo { get; set; }
        public List<IPartner> Partners => new List<IPartner>
        {
            new Partner(ShipTo, PartnerType.ShipTo),
            new Partner(BillTo, PartnerType.BillTo)
        };
    }

    
    public class CreateOrderRequest : BaseOrderRequest
    {
        
        public String SalesOrg { get; set; }
        public SalesArea SalesAreaInfo => new SalesArea(SalesOrg);
        
        public string ShipTo { get; set; }
        
        public string BillTo { get; set; }
        
        public string ContactId { get; set; }
        public List<IPartner> Partners => new List<IPartner>
        {
            new Partner(ShipTo, PartnerType.ShipTo),
            new Partner(BillTo, PartnerType.BillTo),
            new Partner(ContactId, PartnerType.ContactID)
        };
        
        public string AttentionLines { get; set; }
        
        public string AttentionLinesBillTo { get; set; }
        
        public string TelephoneNumber { get; set; }
        
        public string PromDeliveryBlockTextoCode { get; set; }
        
        public string DeliveryBlockStatus { get; set; }
        
        public string DeliveryBlockText { get; set; }
        
        public string PurchaseOrderID { get; set; }
        
        public CreditCardInfo CreditCard { get; set; }
        
        public string WebOrderNumber { get; set; }
        
        public string AltTAX { get; set; }
        
        public string VATNumber { get; set; }
        
        public string VATExpirationDate { get; set; }
        
        public string AdditionalInfo { get; set; }
        
        public string SpecialShippingInstuctions { get; set; }
        
        public string AgentOrderId { get; set; }
        
        public string DeliveryBlock { get; set; }

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

    
    public class CreditCardInfo
    {
        
        public string CardNumber { get; set; }
        
        public string CardHolderName { get; set; }
        
        public string SecurityCode { get; set; }
        
        public string ExpirationMonth { get; set; }
        
        public string ExpirationYear { get; set; }
        
        public string CardType { get; set; }

    }

    
    public class Availability
    {
        
        public decimal AvailableQty { get; set; }
        
        public DateTime AvailableDate { get; set; }
    }
}
