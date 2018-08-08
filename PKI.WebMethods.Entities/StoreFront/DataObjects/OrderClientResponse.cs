using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;
using PKI.eBusiness.WMService.Entities.StoreFront.Account;
using PKI.eBusiness.WMWebApi.BusinessServices.Models.StoreFront.Accounts;
using SimulateOrderWebServiceResponse1 = PKI.eBusiness.WMService.Entities.Stubs.StoreFront.SimulateOrderWebServiceResponse1;

using stubs = PKI.eBusiness.WMService.Entities.Stubs;

namespace PKI.eBusiness.WMService.Entities.StoreFront.DataObjects
{
    public class SimulateOrderClientResponse
    {
        [DataMember]
        public SimulateOrderResponse SimulateOrderResponse { get; set; }

        public SimulateOrderClientResponse(SimulateOrderWebServiceResponse1 response)
        {
            var orderLineItems = new List<OrderLineItem>();

            foreach (var item in response.OrderResponse.OrderResponse.Body.OrderResponseDetail)
            {
                var orderLineItem = new OrderLineItem()
                {
                    ShippingPoint = item.ShippingPoint,
                    OrderLineNumber = Convert.ToInt32((string)item.OrderLineNumber),
                    ProductID = item.ProductID,
                    AdjustedPrice = item.AdjustedPrice,
                    Discount = item.Discount,
                    TaxVAT = item.TaxVAT,
                    Availability = new Availability { 
                        AvailableQty = Convert.ToDecimal(item.ItemDetail[0].AvailableQty, CultureInfo.InvariantCulture),
                        AvailableDate = item.ItemDetail[0].AvailableDate
                    }

                };
                orderLineItems.Add(orderLineItem);
            }

            SimulateOrderResponse = new SimulateOrderResponse()
            {
                PaymentTerms = response.OrderResponse.OrderResponse.Body.OrderResponseHeader.PaymentTerms,
                INCOTerms = response.OrderResponse.OrderResponse.Body.OrderResponseHeader.INCOTerms,
                INCOCode = response.OrderResponse.OrderResponse.Body.OrderResponseHeader.INCOCode,
                Currency = response.OrderResponse.OrderResponse.Body.OrderResponseHeader.Currency,
                ShippingCost = Convert.ToDecimal(response.OrderResponse.OrderResponse.Body.OrderResponseHeader.ShippingCost, CultureInfo.InvariantCulture),
                TaxVAT = Convert.ToDecimal(response.OrderResponse.OrderResponse.Body.OrderResponseHeader.TaxVAT, CultureInfo.InvariantCulture),
                OrderTotal = Convert.ToDecimal(response.OrderResponse.OrderResponse.Body.OrderResponseHeader.OrderTotal, CultureInfo.InvariantCulture),
                LineItems = orderLineItems

            };
		}

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
