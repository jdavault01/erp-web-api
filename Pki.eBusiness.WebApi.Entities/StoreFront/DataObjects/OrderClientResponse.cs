using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Pki.eBusiness.WebApi.Entities.StoreFront.DataObjects
{
    public class SimulateOrderClientResponse
    {
        [DataMember]
        public SimulateOrderResponse SimulateOrderResponse { get; set; }

  //      public SimulateOrderClientResponse(SimulateOrderWebServiceResponse1 response)
  //      {

		//}

    }

    public class OrderClientResponse
    {
        [DataMember]
        public CreateOrderResponse OrderResponse { get; set; }

        //public OrderClientResponse(OrderWebServiceResponse1 response)
        //{
        //    OrderResponse = new CreateOrderResponse(response);
        //}

    }


    [DataContract]
    public class BaseOrderResponse
    {
        [DataMember]
        public decimal ShippingCost { get; set; }
        [DataMember]
        public List<OrderLineItem> LineItems { get; set; }
        [DataMember]
        public String ErrorMessage { get; set; }
        [DataMember]
        public List<FailedItem> FailedItems { get; set; }

    }

    [DataContract]
    public class SimulateOrderResponse : BaseOrderResponse
    {
        [DataMember]
        public string PaymentTerms { get; set; }
        [DataMember]
        public string INCOTerms { get; set; }
        [DataMember]
        public string INCOCode { get; set; }
        [DataMember]
        public string Currency { get; set; }
        [DataMember]
        public decimal TaxVAT { get; set; }
        [DataMember]
        public decimal OrderTotal { get; set; }

        public SimulateOrderResponse()
        {

        }

        public SimulateOrderResponse(List<OrderLineItem> lineItems, string paymentTerms, string iNCOTerms, string iNCOCode,
            string currency, decimal shippingCost, decimal taxVat, decimal orderTotal)
        {
            LineItems = lineItems;
            PaymentTerms = paymentTerms;
            INCOTerms = iNCOTerms;
            INCOCode = iNCOCode;
            Currency = currency;
            ShippingCost = shippingCost;
            TaxVAT = taxVat;
            OrderTotal = orderTotal;
        }
    }

    [DataContract]
    public class CreateOrderResponse : BaseOrderResponse
    {
        [DataMember]
        public string SellerorderID { get; set; }
    }


}
