using System;
using System.Collections.Generic;
using Pki.eBusiness.WebApi.Entities.StoreFront.DataObjects;

namespace Pki.eBusiness.WebApi.Entities.Orders
{
    public class SimulateOrderErpResponse
    {
        public decimal ShippingCost { get; set; }
        public List<OrderErpLineItemResponse> LineItems { get; set; }
        public String ErrorMessage { get; set; }
        public List<FailedItem> FailedItems { get; set; }
        public string PaymentTerms { get; set; }
        public string INCOTerms { get; set; }
        public string INCOCode { get; set; }
        public string Currency { get; set; }
        public decimal TaxVAT { get; set; }
        public decimal OrderTotal { get; set; }
    }

    public class OrderErpLineItemResponse
    {
        public int OrderLineNumber { get; set; }
        public string ProductID { get; set; }
        public decimal Quantity { get; set; }
        public DateTime RequestedDate { get; set; }
        public string ShippingPoint { get; set; }
        public List<AvailabilityErp> Availability { get; set; }
        public decimal AdjustedPrice { get; set; }
        public decimal Discount { get; set; }
        public string Description { get; set; }
        public string SpecialShippingInstructions { get; set; }
        public decimal TaxVAT { get; set; }
    }

    public class AvailabilityErp
    {
        public AvailabilityErp()
        {
            
        }

        public AvailabilityErp(decimal qty, DateTime date)
        {
            AvailableQty = qty;
            AvailableDate = date;
        }
        public decimal AvailableQty { get; set; }
        public DateTime AvailableDate { get; set; }
    }
}