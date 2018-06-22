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
        public string PromoCode { get; set; }
        [DataMember]
        public List<Partner> Partners { get; set; }
        [DataMember]
        public List<OrderLineItem> OrderItems { get; set; }
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
    public class Availability
    {
        [DataMember]
        public decimal AvailableQty { get; set; }
        [DataMember]
        public string AvailableDate { get; set; }
    }
}
