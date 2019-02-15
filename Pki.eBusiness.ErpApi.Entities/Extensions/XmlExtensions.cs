using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using Pki.eBusiness.ErpApi.Entities.OrderLookUp;
using Pki.eBusiness.ErpApi.Entities.OrderLookUp.BasicRequest;

namespace Pki.eBusiness.ErpApi.Entities.Extensions
{
    public static class XmlExtensions
    {
        public static T ConvertToObject<T>(this string input)
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));

            using (StringReader sr = new StringReader(input))
                return (T)ser.Deserialize(sr);
        }

        public static List<OrderAddress> GetOrderAddresses(this XElement addrElement)
        {
            var addrList = new List<OrderAddress>();
            addrList.Add(addrElement.GetOrderAddress(Enumerations.AddressType.BillTo));
            //  addrList.Add(addrElement.GetOrderAddress(Enumerations.AddressType.BillEng));
            //addrList.Add(addrElement.GetOrderAddress(Enumerations.AddressType.ShipEng));
            addrList.Add(addrElement.GetOrderAddress(Enumerations.AddressType.ShipTo));
            //addrList.Add(addrElement.GetOrderAddress(Enumerations.AddressType.SoldTo));

            return addrList;
        }

        public static CreditCard GetCreditCard(this XElement element)
        {
            var card = new CreditCard
            {
                Number = element.GetElementValue("CreditCardNumber"),
                CardType = element.GetElementValue("CreditCardType")

            };
            return card;
        }
        public class Enumerations
        {
            public enum AddressType
            {
                BillEng = 1,
                BillTo = 2,
                ShipTo = 3,
                ShipEng = 4,
                SoldTo = 5

            }


        }

        public static OrderAddress GetOrderAddress(this XElement addrElement, Enumerations.AddressType addressType)
        {
            string elementName = Enum.GetName(typeof(Enumerations.AddressType), addressType);

            OrderAddress address = (from addr in addrElement.Elements(elementName)
                                    let childAddrElements = addr.Element("Address")
                                    select new OrderAddress
                                    {
                                        Id = addr.AttributeNullValue<string>("id"),
                                        Type = addressType,
                                        Attention = elementName.Contains("Bill") ? addr.GetElementValue("BillToAttention") : addr.GetElementValue("ShipToAttention"),
                                        Name1 = addr.GetElementValue("Name1"),
                                        Name2 = addr.GetElementValue("Name2"),
                                        Name3 = addr.GetElementValue("Name3"),
                                        Name4 = addr.GetElementValue("Name4"),
                                        RADIndicator = addr.ElementNullValue<bool>("RADIndicator"),
                                        MarkedForDeletion = addr.ElementNullValue<bool>("MarkedForDeletion"),
                                        Street = childAddrElements.ElementNullValue<string>("Street"),
                                        PoBox = childAddrElements.GetElementValue("POBox"),
                                        PoBoxCity = childAddrElements.GetElementValue("POBoxCity"),
                                        City = childAddrElements.GetElementValue("City"),
                                        District = childAddrElements.GetElementValue("District"),
                                        Country = childAddrElements.GetElementValue("Country"),
                                        Fax = childAddrElements.GetElementValue("Fax"),
                                        PostalCode = childAddrElements.GetElementValue("PostalCode"),
                                        Region = childAddrElements.GetElementValue("Region"),
                                        CityCode = childAddrElements.GetElementValue("CityCode"),
                                        Telephone = childAddrElements.GetElementValue("Telephone")

                                    }).Single();
            return address;
        }
        public static List<OrderItem> GetProducts(this XElement element)
        {
            List<OrderItem> productList = (from orderItem in element.Element("ItemList").Elements("Product")
                                         select new OrderItem
                                         {
                                             Id = orderItem.GetAttributeValue("id"),
                                             WebLineItemNO = orderItem.GetElementValue("WebLineItemNO"),
                                             SAPLineItemNO = orderItem.GetElementValue("SAPLineItemNO"),
                                             Description = orderItem.GetElementValue("Description"),
                                             Quantity = orderItem.ElementNullValue<decimal>("Quantity"),
                                             AdjustedUnitPrice = orderItem.ElementNullValue<decimal>("AdjustedUnitPrice"),
                                             VAT = orderItem.ElementNullValue<decimal>("VAT"),
                                             ShippingPoint = orderItem.GetElementValue("ShippingPoint"),
                                             ExpectedShipDate = orderItem.GetElementValue("ExpectedShipDate"),
                                             Status = orderItem.GetElementValue("Status"),
                                             Carrier = orderItem.GetElementValue("Carrier"),
                                             TrackingNO = orderItem.GetElementValue("TrackingNO"),
                                             PromotionalDiscount = orderItem.ElementNullValue<decimal>("PromotionalDiscount"),
                                             IsCourse = orderItem.GetElementValue("IsCourse"),
                                             //Mocked fields until actual data comes from web methods
                                             IssuedDate = orderItem.GetElementValue("IssuedDate").GetDateTime(),
                                             ExtendedPrice = orderItem.ElementNullValue<decimal>("ExtendedPrice"),
                                             PickedUpFromMIT = orderItem.GetElementValue("PickedUpFromMIT").GetDateTime(),
                                             ReceivedAtMIT = orderItem.GetElementValue("ReceivedAtMIT").GetDateTime(),
                                             ReleasedFromMIT = orderItem.GetElementValue("ReleasedFromMIT").GetDateTime(),
                                             ShipmentCreatedOn = orderItem.GetElementValue("ShipmentCreatedOn").GetDateTime(),
                                             ShipmentRoute = orderItem.GetElementValue("ShipmentRoute")

                                         }).ToList();

            return productList;
        }
    }
}