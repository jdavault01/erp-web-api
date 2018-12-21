using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Pki.eBusiness.ErpApi.Entities.OrderLookUp.BasicRequest;

namespace Pki.eBusiness.ErpApi.Entities.Extensions
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// This method converts order lookup request to WMLookUpRequest
        /// </summary>
        /// <param name="request">orderlookuprequest</param>
        /// <returns>ordersummaryrequest</returns>

        public static OrderSummaryRequest ToWmLookUpRequest(this OrderSummaryLookUpRequest request)
        {
            var shipToList = new List<ShipTo>();
            shipToList.Add(GetDefaultShipTo(request.SAPOrderNumber));
            var result = new OrderSummaryRequest()
            {
                Header = new OrderLookUpHeader
                {
                    VersionNumber = new VersionNumber()
                    {
                        Value = "001",
                        Data = "001"
                    },

                    Sender = new OrderSender()
                    {
                        LogicalID = "SF",
                        Task = "DisplayOrderSummary"
                    }

                },
                Body = new OrderLookUpBody()
                {
                    RequestHeader = new OrderSummaryRequestHeader()
                    {
                        ContactNameID = string.Empty,
                        // SalesOrgID =string.Empty,
                        DivisionID = "02",
                        DistChannelID = "01",
                        ToDateString = string.Empty,
                        FromDateString = string.Empty,
                        Language = request.Language,
                        ShipToList = shipToList
                    }

                },


            };

            return result;

        }

        public static ShipTo GetDefaultShipTo(string sapOrderNumber)
        {
            ShipTo shipTo = new ShipTo { ShipToID = "" };
            PurchaseOrderID order = new PurchaseOrderID { Data = "" };
            List<PurchaseOrderID> poList = new List<PurchaseOrderID> { order };
            SellerOrderID sellerOrderId = new SellerOrderID { Data = sapOrderNumber };
            List<SellerOrderID> orderList = new List<SellerOrderID> { sellerOrderId };
            shipTo.SAPOrderList = orderList;
            shipTo.PurchaseOrderList = poList;
            return shipTo;
        }


        //public static OrderDetailResponse ToOrderDetailResponse(this StoreFrontStubs.OrderInfoWebServiceResponse response)
        //{
        //    OrderDetailResponse detailResponse = new OrderDetailResponse();
        //    XDocument xDoc = new XDocument(new XDeclaration("1.0", "utf-16", "yes"),new XElement("Root", "Content"));
        //    xDoc = XDocument.Parse(response.xmlResponse);

        //       XElement detailResponseHeader = xDoc.XPathSelectElement("//OrderDetailResponseHeader");
        //        if (detailResponseHeader != null)
        //        {

        //            var serializer = new XmlSerializer(typeof(OrderDetailResponse), new XmlRootAttribute("OrderDetailResponseHeader"));
        //            try
        //            {
        //                detailResponse =
        //            (OrderDetailResponse)serializer.Deserialize(new StringReader(detailResponseHeader.ToString()));

        //            }
        //            catch (Exception)
        //            {
        //                throw;
        //            }

        //            detailResponse.PartnerInfo = detailResponseHeader.GetOrderAddresses();
        //            detailResponse.ProductList = detailResponseHeader.GetProducts();
        //            detailResponse.Card = detailResponseHeader.GetCreditCard();


        //        }


        //    return detailResponse;
        //}

        //public static List<OrderAddress> GetOrderAddresses(this XElement addrElement)
        //{
        //    var addrList = new List<OrderAddress>();
        //    addrList.Add(addrElement.GetOrderAddress(Enumerations.AddressType.BillTo));
        //  //  addrList.Add(addrElement.GetOrderAddress(Enumerations.AddressType.BillEng));
        //    //addrList.Add(addrElement.GetOrderAddress(Enumerations.AddressType.ShipEng));
        //    addrList.Add(addrElement.GetOrderAddress(Enumerations.AddressType.ShipTo));
        //    //addrList.Add(addrElement.GetOrderAddress(Enumerations.AddressType.SoldTo));

        //    return addrList;
        //}

        //private static CreditCard GetCreditCard(this XElement element)
        //{
        //    var card = new CreditCard
        //    {
        //        Number = element.GetElementValue("CreditCardNumber"),
        //        CardType = element.GetElementValue("CreditCardType")

        //    };
        //    return card;
        //}

        //private static OrderAddress GetOrderAddress(this XElement addrElement,Enumerations.AddressType addressType)
        //{
        //    string elementName=Enum.GetName(typeof(Enumerations.AddressType), addressType);

        //    OrderAddress address = (from addr in addrElement.Elements(elementName)
        //                              let childAddrElements =addr.Element("Address")
        //        select new OrderAddress
        //        {
        //            Id = addr.AttributeNullValue<string>("id"),
        //            Type = addressType,
        //            Attention = elementName.Contains("Bill")? addr.GetElementValue("BillToAttention"): addr.GetElementValue("ShipToAttention"),
        //            Name1 = addr.GetElementValue("Name1"),
        //            Name2 = addr.GetElementValue("Name2"),
        //            Name3 = addr.GetElementValue("Name3"),
        //            Name4 = addr.GetElementValue("Name4"),
        //            RADIndicator = addr.ElementNullValue<bool>("RADIndicator"),
        //            MarkedForDeletion = addr.ElementNullValue<bool>("MarkedForDeletion"),
        //            Street =childAddrElements.ElementNullValue<string>("Street"),
        //            PoBox = childAddrElements.GetElementValue("POBox"),
        //            PoBoxCity = childAddrElements.GetElementValue("POBoxCity"),
        //            City = childAddrElements.GetElementValue("City"),
        //            District = childAddrElements.GetElementValue("District"),
        //            Country = childAddrElements.GetElementValue("Country"),
        //            Fax = childAddrElements.GetElementValue("Fax"),
        //            PostalCode = childAddrElements.GetElementValue("PostalCode"),
        //            Region = childAddrElements.GetElementValue("Region"),
        //            CityCode = childAddrElements.GetElementValue("CityCode"),
        //            Telephone = childAddrElements.GetElementValue("Telephone")

        //        }).Single();
        //    return address;
        //}
        public static List<OrderItem> GeProducts(this XElement element)
        {
            List<OrderItem> productList = (from product in element.Element("ItemList").Elements("OrderItem")
                                         select new OrderItem
                                         {
                                             Id = product.GetAttributeValue("id"),
                                             WebLineItemNO = product.GetElementValue("WebLineItemNO"),
                                             SAPLineItemNO = product.GetElementValue("SAPLineItemNO"),
                                             Description = product.GetElementValue("Description"),
                                             Quantity = product.ElementNullValue<decimal>("Quantity"),
                                             AdjustedUnitPrice = product.ElementNullValue<decimal>("AdjustedUnitPrice"),
                                             VAT = product.ElementNullValue<decimal>("VAT"),
                                             ShippingPoint = product.GetElementValue("ShippingPoint"),
                                             ExpectedShipDate = product.GetElementValue("ExpectedShipDate"),
                                             Status = product.GetElementValue("Status"),
                                             Carrier = product.GetElementValue("Carrier"),
                                             TrackingNO = product.GetElementValue("TrackingNO"),
                                             PromotionalDiscount = product.ElementNullValue<decimal>("PromotionalDiscount"),
                                             IsCourse = product.GetElementValue("IsCourse"),
                                             //Mocked fields until actual data comes from web methods
                                             IssuedDate = product.GetElementValue("IssuedDate").GetDateTime(),
                                             ExtendedPrice = product.ElementNullValue<decimal>("ExtendedPrice"),
                                             PickedUpFromMIT = product.GetElementValue("PickedUpFromMIT").GetDateTime(),
                                             ReceivedAtMIT = product.GetElementValue("ReceivedAtMIT").GetDateTime(),
                                             ReleasedFromMIT = product.GetElementValue("ReleasedFromMIT").GetDateTime(),
                                             ShipmentCreatedOn = product.GetElementValue("ShipmentCreatedOn").GetDateTime(),
                                             ShipmentRoute = product.GetElementValue("ShipmentRoute")

                                         }).ToList();

            return productList;
        }




    }
}
