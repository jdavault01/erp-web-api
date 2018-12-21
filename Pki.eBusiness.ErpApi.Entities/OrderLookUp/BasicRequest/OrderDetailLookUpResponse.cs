using System;
using System.Collections.Generic;

namespace Pki.eBusiness.ErpApi.Entities.OrderLookUp.BasicRequest
{
    public class OrderDetailLookUpResponse
    {
        //
        public List<OrderItem> ProductList { get; set; }
        //public List<OrderAddress> PartnerInfo { get; set; }
        public CreditCard Card { get; set; }
        public decimal TotalPrice { get; set; }
        public string OrderType { get; set; }
        public decimal DeliveryCharges { get; set; }
        public decimal HandlingCharges { get; set; }
        public decimal OrderLevelTax { get; set; }
        public string Currency { get; set; }
        public string PoNumber { get; set; }
        public string TelephoneNumber { get; set; }
        public string AdditionalInfo { get; set; }
        public string SpecialHandlingInstructions { get; set; }
        public string CreditStatus { get; set; }
        public string DeliveryBlock { get; set; }

    }

    public class MyProduct
    {
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
        //
        public DateTime? ReleasedFromMIT { get; set; }
        //
        public DateTime? PickedUpFromMIT { get; set; }
        //
        public DateTime? ShipmentCreatedOn { get; set; }
        //
        public DateTime? IssuedDate { get; set; }
        //
        public decimal ExtendedPrice { get; set; }

    }

    //public class MyCreditCard
    //{
    //    public string Number { get; set; }
    //    public string CardType { get; set; }

    //}
}
