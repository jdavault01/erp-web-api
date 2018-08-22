using System;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.XPath;
using Pki.eBusiness.WebApi.Entities.Extensions;

namespace Pki.eBusiness.WebApi.Entities.OrderLookUp.BasicRequest
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
                try
                {
                    detailResponse =
                        (OrderDetailResponse)serializer.Deserialize(new StringReader(detailResponseHeader.ToString()));

                }
                catch (Exception)
                {
                    throw;
                }

                detailResponse.OrderAddrList = detailResponseHeader.GetOrderAddresses();
                detailResponse.ProductList = detailResponseHeader.GetProducts();
                detailResponse.Card = detailResponseHeader.GetCreditCard();


            }


            return detailResponse;
        }


        public OrderLookUpResponse ToOrderLookUpResponse()
        {
            OrderLookUpResponse lookUpResponse = new OrderLookUpResponse();
            XDocument xDoc = XDocument.Parse(xmlResponse);

            XElement summaryResponseHeader = xDoc.XPathSelectElement("//OrderSummaryResponseHeader");
            if (summaryResponseHeader != null)
            {

                var serializer = new XmlSerializer(typeof(OrderLookUpResponse),
                    new XmlRootAttribute("OrderSummaryResponseHeader"));

                lookUpResponse =
                    (OrderLookUpResponse)serializer.Deserialize(new StringReader(summaryResponseHeader.ToString()));
            }
            return lookUpResponse;


        }
    }

}