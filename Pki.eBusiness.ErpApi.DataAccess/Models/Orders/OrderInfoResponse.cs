using System;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.XPath;
using Pki.eBusiness.ErpApi.DataAccess.Extensions;
using Pki.eBusiness.ErpApi.Entities.OrderLookUp.BasicRequest;

namespace Pki.eBusiness.ErpApi.DataAccess.Models.Orders
{
    public class OrderInfoResponse
    {
        public string xmlResponse { get; set; }

        public OrderDetailResponse ToOrderDetailResponse()
        {
            OrderDetailResponse detailResponse = new OrderDetailResponse();
            XDocument xDoc = new XDocument(new XDeclaration("1.0", "utf-16", "yes"), new XElement("Root", "Content"));
            xDoc = XDocument.Parse(xmlResponse);

            XElement detailResponseHeader = xDoc.XPathSelectElement("//OrderDetailResponseHeader");
            if (detailResponseHeader != null)
            {
                var serializer = new XmlSerializer(typeof(OrderDetailResponse), new XmlRootAttribute("OrderDetailResponseHeader"));
                var response = detailResponseHeader.ToString();
                var reader = new StringReader(response);
                detailResponse = (OrderDetailResponse)serializer.Deserialize(reader);

                detailResponse.Card = detailResponse.GetCreditCard();
                detailResponse.PartnerInfo = detailResponse.GetOrderAddresses();
                detailResponse.OrderItems = detailResponse.GetProducts();
            }

            return detailResponse;
        }


        public OrderSummaryResponse ToOrderLookUpResponse()
        {
            OrderSummaryResponse lookUpResponse = new OrderSummaryResponse();
            XDocument xDoc = XDocument.Parse(xmlResponse);

            XElement summaryResponseHeader = xDoc.XPathSelectElement("//OrderSummaryResponseHeader//Order");
            if (summaryResponseHeader != null)
            {

                var serializer = new XmlSerializer(typeof(OrderSummaryResponse),
                    new XmlRootAttribute("Order"));

                lookUpResponse =
                    (OrderSummaryResponse)serializer.Deserialize(new StringReader(summaryResponseHeader.ToString()));
            }
            return lookUpResponse;


        }
    }

    public class XmlObjectWrapperAttribute : Attribute
    {
        public string ElementName { get; set; }
    }
}
