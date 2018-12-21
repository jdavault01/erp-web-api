using System;
using System.Collections.Generic;

namespace Pki.eBusiness.ErpApi.Entities.DataObjects
{
    public class SimulateOrderClientResponse
    {
        
        public SimulateOrderResponse SimulateOrderResponse { get; set; }
    }

    public class OrderClientResponse
    {
        
        public CreateOrderResponse OrderResponse { get; set; }
    }


    
    public class BaseOrderResponse
    {
        
        public decimal ShippingCost { get; set; }
        
        public List<OrderLineItem> OrderItems { get; set; }
        
        public String ErrorMessage { get; set; }
        
        public List<FailedItem> FailedItems { get; set; }

    }

    
    public class SimulateOrderResponse : BaseOrderResponse
    {
        
        public string PaymentTerms { get; set; }
        
        public string INCOTerms { get; set; }
        
        public string INCOCode { get; set; }
        
        public string Currency { get; set; }
        
        public decimal TaxVAT { get; set; }
        
        public decimal OrderTotal { get; set; }

        public SimulateOrderResponse()
        {

        }

        public SimulateOrderResponse(List<OrderLineItem> lineItems, string paymentTerms, string iNCOTerms, string iNCOCode,
            string currency, decimal shippingCost, decimal taxVat, decimal orderTotal)
        {
            OrderItems = lineItems;
            PaymentTerms = paymentTerms;
            INCOTerms = iNCOTerms;
            INCOCode = iNCOCode;
            Currency = currency;
            ShippingCost = shippingCost;
            TaxVAT = taxVat;
            OrderTotal = orderTotal;
        }
    }

    
    public class CreateOrderResponse : BaseOrderResponse
    {
        
        public string SellerorderID { get; set; }
    }


}
