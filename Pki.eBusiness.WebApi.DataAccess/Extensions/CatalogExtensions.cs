using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Pki.eBusiness.WebApi.DataAccess.StoreFrontWebServices;
using Pki.eBusiness.WebApi.Entities.StoreFront.DataObjects;
using Pki.eBusiness.WebApi.Entities.StoreFront.ProductCatalog;
using InventoryResponse = Pki.eBusiness.WebApi.Entities.StoreFront.DataObjects.InventoryResponse;
using StorefrontInventoryRequest = Pki.eBusiness.WebApi.Entities.StoreFront.DataObjects.InventoryRequest;
using StorefrontPriceRequest = Pki.eBusiness.WebApi.Entities.StoreFront.DataObjects.PriceRequest;
using StorefrontSimulateOrderRequest = Pki.eBusiness.WebApi.Entities.StoreFront.DataObjects.SimulateOrderRequest;
using StorefrontCreateOrderRequest = Pki.eBusiness.WebApi.Entities.StoreFront.DataObjects.CreateOrderRequest;
using Pki.eBusiness.WebApi.DataAccess.Models;

namespace Pki.eBusiness.WebApi.DataAccess.Extensions
{
    public static class CatalogExtensions
    {
        private const string SAP_HEADER_VERSION = "001";
        private const string TASK_SIMULATE_REQUEST = "OrderSimulateRequest";
        private const string TASK_ORDER_REQUEST = "OrderEntryRequest";
        private const string PARTNER_TYPE_SHIPTO = "ShipTo";
        private const string PARTNER_TYPE_BILLTO = "BillTo";

        public static PriceWebServiceRequest ToWmPriceRequest(this StorefrontPriceRequest request)
        {
            PriceWebServiceRequest result = new PriceWebServiceRequest();
            var productLists = new ProductList[request.Products.Count];

            for (int i = 0; i < request.Products.Count; i++)
            {
                var productList = new ProductList { ProductID = request.Products[i].PartNumber };
                productLists[i] = productList;
            }

            var pricingRequest = new ProductPricingRequest
            {
                ShipTo = request.PartnerInfo[0].PartnerId,
                BillTo = request.PartnerInfo[1].PartnerId,
                DistChannelID = request.SalesAreaInfo.DistChannelId,
                DivisionID = request.SalesAreaInfo.DivisionId,
                SalesOrgID = request.SalesAreaInfo.SalesOrgId,
                ProductList = productLists
            };

            result.PricingRequest = pricingRequest;
            return result;
        }

        public static PriceResponse ToPriceResponse(this PriceWebServiceResponse1 response)
        {
            var result = new PriceResponse();
            result = new PriceResponse { Products = new List<Product>() };
            foreach (var product in response.ProductList)
            {
                var p = new Product
                {
                    PartNumber = product.ProductID,
                    Price = Convert.ToDecimal(product.Price, CultureInfo.InvariantCulture),
                    Currency = product.Currency
                };
                result.Products.Add(p);
            }

            return result;
        }

        public static InventoryWebServiceRequest ToWmInventoryRequest(this StorefrontInventoryRequest request)
        {
            var result = new InventoryWebServiceRequest();
            var invReq = new StoreFrontWebServices.InventoryRequest
            {
                InventoryRequestDetail = new InventoryRequestDetail[request.Products.Count]
            };

            var partners = new Partner2[2];
            var partner0 = new Partner2 { PartnerID = request.PartnerInfo[0].PartnerId, PartnerType = PARTNER_TYPE_SHIPTO };
            partners[0] = partner0;
            var partner = new Partner2 { PartnerID = request.PartnerInfo[1].PartnerId, PartnerType = PARTNER_TYPE_BILLTO };
            partners[1] = partner;

            invReq.InventoryRequestHeader = new InventoryRequestHeader
            {
                SalesOrgID = request.SalesAreaInfo.SalesOrgId,
                DistChannelID = request.SalesAreaInfo.DistChannelId,
                DivisionID = request.SalesAreaInfo.DivisionId,
                Partner = partners
            };

            var lineNum = 0;
            foreach (var p in request.Products)
            {
                var inventoryRequestDetail = new InventoryRequestDetail
                {
                    OrderLineNumber = (lineNum + 1).ToString(CultureInfo.InvariantCulture),
                    ProductID = p.ProductId,
                    Quantity = p.Quantity.ToString(CultureInfo.InvariantCulture),
                    RequestedDate = p.RequestedDate.ToString("yyyyMMdd")
                };

                invReq.InventoryRequestDetail[lineNum] = inventoryRequestDetail;
                lineNum++;
            }
            result.InventoryRequest = invReq;
            return result;
        }

        public static InventoryResponse ToInventoryResponse(this InventoryWebServiceResponse1 response)
        {
            var result = new InventoryResponse();
            if (response.InventoryResponse == null)
            {
                return result;
            }
            result = new InventoryResponse
            {
                InventoryResponseItems = new InventoryResponseItem[response.InventoryResponse.InventoryResponseDetail.Length]
            };

            int itemNum = 0;
            foreach (var serviceInventoryResponseDetail in response.InventoryResponse.InventoryResponseDetail)
            {
                //Values comes in as a string with decimal formatting, e.g "1.00"
                var quantity = Convert.ToDecimal(serviceInventoryResponseDetail.Quantity, CultureInfo.InvariantCulture);
                var inventoryResponseDetail = new InventoryResponseItem
                {
                    OrderLineNumber = serviceInventoryResponseDetail.OrderLineNumber,
                    ProductId = serviceInventoryResponseDetail.ProductID,
                    Quantity = quantity, 
                    ShippingPoint = serviceInventoryResponseDetail.ShippingPoint,
                };

                var numOfAvailQty = 0;
                var availableQtyWithDollarValue = serviceInventoryResponseDetail.ItemDetail.Where(itemDetail => Decimal.Parse(itemDetail.AvailableQty, CultureInfo.InvariantCulture) != 0.00M);
                inventoryResponseDetail.Availabilities = new Availability[availableQtyWithDollarValue.ToList().Count];

                foreach (var avaialblity in availableQtyWithDollarValue.Select(itemDetail => new Availability
                {
                    AvailableDate = DateTime.ParseExact(itemDetail.AvailableDate, "yyyyMMdd", CultureInfo.InvariantCulture),
                    AvailableQty = Convert.ToDecimal(itemDetail.AvailableQty, CultureInfo.InvariantCulture)
                }))
                {
                    inventoryResponseDetail.Availabilities[numOfAvailQty] = avaialblity;
                    numOfAvailQty++;
                }
                result.InventoryResponseItems[itemNum] = inventoryResponseDetail;
                itemNum++;

            }

            return result;
        }

        public static OrderWebServiceRequest ToWmOrderRequest(this StorefrontCreateOrderRequest clientRequest)
        {
            var result = new OrderWebServiceRequest();

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

            string sapOrderType = new SAPOrderType(clientRequest).GetOrderTypeCode();

            var orderRequestHeader = new OrderRequestHeader2()
            {
                //TODO: Need to get Sender attribute added by Derek / WM team
                //Sender = new Sender2 { Component = sapOrderType, Task = TASK_ORDER_REQUEST },
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


            var payload = new OrderRequest2() { OrderRequestHeader = orderRequestHeader, OrderRequestDetail = orderRequestDetail };

            result.OrderRequest = payload;
            return result;
        }

        public static CreateOrderResponse ToOrderResponse(this OrderWebServiceResponse1 response)
        {
            var result = new CreateOrderResponse();
            var orderLineItems = new List<OrderLineItem>();
            foreach (var item in response.OrderResponse.OrderResponseDetail)
            {
                var orderLineItem = new OrderLineItem()
                {

                    ShippingPoint = item.ShippingPoint,
                    OrderLineNumber = Convert.ToInt32((string)item.OrderLineNumber),
                    ProductID = item.ProductID,
                    Description = item.Description,
                    Availability = new Availability
                    {
                        AvailableQty = Convert.ToDecimal(item.ItemDetail[0].AvailableQty, CultureInfo.InvariantCulture),
                        AvailableDate = DateTime.ParseExact(item.ItemDetail[0].AvailableDate, "yyyyMMdd", CultureInfo.InvariantCulture)
                    },
                    AdjustedPrice = item.AdjustedPrice,
                    Discount = item.Discount,
                    TaxVAT = item.TaxVAT
                };
                orderLineItems.Add(orderLineItem);
            }

            result.SellerorderID = response.OrderResponse.OrderResponseHeader.SellerOrderID;
            result.OrderItems = orderLineItems;
            result.ShippingCost = Convert.ToDecimal(response.OrderResponse.OrderResponseHeader.ShippingCost, CultureInfo.InvariantCulture);
            return result;
        }

        public static SimulateOrderWebServiceRequest ToWmSimulateOrderRequest(this StorefrontSimulateOrderRequest clientRequest)
        {
            SimulateOrderWebServiceRequest result = new SimulateOrderWebServiceRequest();
            //string sapOrderType = new SAPOrderType(clientRequest).GetOrderTypeCode();
            string sapOrderType = "ZWEB";

            var header = new Header2()
            {
                Version = new Version2() { value = SAP_HEADER_VERSION },
                Sender = new Sender2 { Component = sapOrderType, Task = TASK_SIMULATE_REQUEST }
            };

            var requestDetails = new OrderRequestDetail[clientRequest.OrderItems.Count];
            for (var i = 0; i < clientRequest.OrderItems.Count; i++)
            {
                var lineNum = i + 1;
                var requestDetail = new OrderRequestDetail
                {
                    OrderLineNumber = lineNum.ToString(),
                    ProductID = clientRequest.OrderItems[i].ProductID,
                    Quantity = clientRequest.OrderItems[i].Quantity.ToString(),
                    RequestedDate = clientRequest.OrderItems[i].RequestedDate
                };

                requestDetails[i] = requestDetail;
            }

            var partners = new Partner3[clientRequest.Partners.Count];
            for (var i = 0; i < clientRequest.Partners.Count; i++)
            {
                var partner = new Partner3
                {
                    id = clientRequest.Partners[i].PartnerType.ToString(),
                    PartnerID = clientRequest.Partners[i].PartnerId,
                    PartnerType = clientRequest.Partners[i].PartnerType.ToString()
                };
                partners[i] = partner;
            }

            var orderRequestHeader = new OrderRequestHeader()
            {
                SalesOrgID = clientRequest.SalesAreaInfo.SalesOrgId,
                DistChannelID = clientRequest.SalesAreaInfo.DistChannelId,
                DivisionID = clientRequest.SalesAreaInfo.DivisionId,
                language = clientRequest.Language,
                NumberOfItems = clientRequest.OrderItems.Count.ToString(),
                PromoCode = clientRequest.PromoCode,
                Partner = partners
            };

            var bodies = new Body2[1];
            bodies[0] = new Body2() { OrderRequestHeader = orderRequestHeader, OrderRequestDetail = requestDetails }; ;
            var request = new OrderRequest() { Header = header, Body = bodies };
            var payload = new orderRequest() { OrderRequest = request };
            result.OrderRequest = payload;
            return result;
        }

        public static SimulateOrderResponse ToSimulateOrderResponse(this SimulateOrderWebServiceResponse1 response)
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
                    Availability = new Availability
                    {
                        AvailableQty = Convert.ToDecimal(item.ItemDetail[0].AvailableQty, CultureInfo.InvariantCulture),
                        AvailableDate = DateTime.ParseExact(item.ItemDetail[0].AvailableDate, "yyyyMMdd", CultureInfo.InvariantCulture)
                    }

                };
                orderLineItems.Add(orderLineItem);
            }

            SimulateOrderResponse result = new SimulateOrderResponse()
            {
                PaymentTerms = response.OrderResponse.OrderResponse.Body.OrderResponseHeader.PaymentTerms,
                INCOTerms = response.OrderResponse.OrderResponse.Body.OrderResponseHeader.INCOTerms,
                INCOCode = response.OrderResponse.OrderResponse.Body.OrderResponseHeader.INCOCode,
                Currency = response.OrderResponse.OrderResponse.Body.OrderResponseHeader.Currency,
                ShippingCost = Convert.ToDecimal(response.OrderResponse.OrderResponse.Body.OrderResponseHeader.ShippingCost, CultureInfo.InvariantCulture),
                TaxVAT = Convert.ToDecimal(response.OrderResponse.OrderResponse.Body.OrderResponseHeader.TaxVAT, CultureInfo.InvariantCulture),
                OrderTotal = Convert.ToDecimal(response.OrderResponse.OrderResponse.Body.OrderResponseHeader.OrderTotal, CultureInfo.InvariantCulture),
                OrderItems = orderLineItems

            };
            return result;
        }

    }
}
