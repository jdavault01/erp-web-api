﻿using Pki.eBusiness.ErpApi.DataAccess.StoreFrontWebServices;
using StorefrontCreateOrderRequest = Pki.eBusiness.ErpApi.Entities.DataObjects.CreateOrderRequest;

namespace Pki.eBusiness.ErpApi.DataAccess.Extensions
{
    public class CreateOrderServiceRequest
    {
        
        public OrderWebServiceRequest OrderWebServiceRequest { get; set; }

        
        public OrderRequest2 OrderRequestPayLoad { get; set; }

        
        public OrderRequest Request { get; set; }

        
        public OrderRequestHeader RequestHeader { get; set; }

        
        public OrderRequestDetail RequestDetail { get; set; }

        
        public OrderRequestDetail[] RequestDetails { get; set; }
        public CreateOrderServiceRequest(StorefrontCreateOrderRequest clientRequest)
        {
            this.OrderWebServiceRequest = new OrderWebServiceRequest();

            var partners = new Partner4[clientRequest.Partners.Count];
            for (var i = 0; i < clientRequest.Partners.Count; i++)
            {
                var partner = new Partner4
                {
                    id = clientRequest.Partners[i].PartnerType.ToString(),
                    PartnerID = clientRequest.Partners[i].PartnerId,
                    PartnerType = clientRequest.Partners[i].PartnerType.ToString()
                };
                partners[i] = partner;
            }

            var orderRequestHeader = new OrderRequestHeader2()
            {
                SalesOrgID = clientRequest.SalesAreaInfo.SalesOrgId,
                DistChannelID = clientRequest.SalesAreaInfo.DistChannelId,
                DivisionID = clientRequest.SalesAreaInfo.DivisionId,
                language = clientRequest.Language,
                DeliveryBlockText = clientRequest.DeliveryBlockText,
                DeliveryBlockStatus = clientRequest.DeliveryBlockStatus,
                PaymentType = clientRequest.PaymentType,
                PurchaseOrderID = clientRequest.PurchaseOrderID,
                WebOrderNumber = clientRequest.WebOrderNumber,
                NumberOfItems = clientRequest.OrderItems.Count.ToString(),
                AttentionLines = clientRequest.AttentionLines,
                AttentionLinesBillTo = clientRequest.AttentionLinesBillTo,
                TelephoneNumber = clientRequest.TelephoneNumber,
                AltTAX = clientRequest.AltTAX,
                VATNumber = clientRequest.VATNumber,
                VATExpirationDate = clientRequest.VATExpirationDate,
                AdditionalInfo = clientRequest.AdditionalInfo,
                Partner = partners
            };

            if (clientRequest.CreditCard != null)
            {
                orderRequestHeader.CreditCard = new CreditCard2()
                {
                    HolderName = clientRequest.CreditCard.CardHolderName,
                    CreditCardNumber = clientRequest.CreditCard.CardNumber,
                    CreditCardType = clientRequest.CreditCard.CardType,
                    ExpirationMonth = clientRequest.CreditCard.ExpirationMonth,
                    ExpirationYear = clientRequest.CreditCard.ExpirationYear,
                    SecurityNumber = clientRequest.CreditCard.SecurityCode
                };
            }

            var orderRequestDetail = new OrderRequestDetail2[clientRequest.OrderItems.Count];
            for (var i = 0; i < clientRequest.OrderItems.Count; i++)
            {
                var lineNum = i + 1;
                var requestDetail = new OrderRequestDetail2
                {
                    OrderLineNumber = lineNum.ToString(),
                    ProductID = clientRequest.OrderItems[i].ProductID,
                    Quantity = clientRequest.OrderItems[i].Quantity.ToString(),
                    RequestedDate = clientRequest.OrderItems[i].RequestedDate, //YYYMMDD
                    ShippingInstructions = clientRequest.OrderItems[i].SpecialShippingInstructions
                };

                orderRequestDetail[i] = requestDetail;
            }


            OrderRequestPayLoad = new OrderRequest2() { OrderRequestHeader = orderRequestHeader, OrderRequestDetail = orderRequestDetail };

            this.OrderWebServiceRequest.OrderRequest = OrderRequestPayLoad;
        }
    }
}
