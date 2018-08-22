using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using PKI.eBusiness.WMService.Entities.OrderLookUp.BasicRequest;

namespace PKI.eBusiness.WMService.Entities.Extensions
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
        public static List<Product> GetProducts(this XElement element)
        {
            List<Product> productList = (from product in element.Element("ItemList").Elements("Product")
                                         select new Product
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