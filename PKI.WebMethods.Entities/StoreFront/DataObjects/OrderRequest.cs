using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;
using PKI.eBusiness.WMService.Entities.StoreFront.Account;
using PKI.eBusiness.WMWebApi.BusinessServices.Models.StoreFront.Accounts;


namespace PKI.eBusiness.WMService.Entities.StoreFront.DataObjects
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
        public string TaxVAT { get; set; }
    }

    [DataContract]
    public class SimulateOrderRequest : BaseOrderRequest
    {
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
        public string PaymentType { get; set; }
        [DataMember]
        public string PurchaseOrderID { get; set; }
        //[DataMember]
        public CreditCardInfo CreditCard { get; set; }

    }

    [DataContract]
    public class CreditCardInfo
    {
        [DataMember]
        public decimal CardNumber { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string CCV { get; set; }
        [DataMember]
        public DateTime ExpirationDate { get; set; }
    }

    [DataContract]
    public class Availability
    {
        [DataMember]
        public decimal AvailableQty { get; set; }
        [DataMember]
        public string AvailableDate { get; set; }
    }
}
