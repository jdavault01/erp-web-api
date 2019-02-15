using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Pki.eBusiness.ErpApi.DataAccess.Extensions;

namespace Pki.eBusiness.ErpApi.DataAccess.Models.Orders
{
    public class OrderDetailRequest
    {
        private const string LOGIICAL_ID_SF = "SF";
        private const string VERSION = "001";
        public const string ORDER_DETAIL_REQUEST_ELEMENT = "OrderDetailRequest";
        public const string DTD_DETAIL_REQUEST_SYSID = "OrderDetailRequestInput.dtd";

        public OrderLookUpHeader Header { get; set; }

        [XmlElement(ElementName = "Body")]
        public OrderDetailBody DetailBody { get; set; }

        public OrderDetailRequest()
        {

        }

        public OrderDetailRequest(string orderId)
        {
            this.Header = new OrderLookUpHeader() { VersionNumber = new VersionNumber(VERSION, VERSION), Sender = new OrderSender(LOGIICAL_ID_SF, "DisplayOrderDetail") };
            this.DetailBody = new OrderDetailBody() { RequestHeader = new OrderDetailRequestHeader(orderId) };


        }

        public OrderInfoRequest ToRequest()
        {
            return new OrderInfoRequest
            {
                xmlRequest = this.SerializeToXml(ORDER_DETAIL_REQUEST_ELEMENT,DTD_DETAIL_REQUEST_SYSID, false)
            };
        }

    }

    public class OrderInfoRequest
    {
        public string xmlRequest { get; set; }
        public object node { get; set; }
    }

    public class OrderDetailBody
    {
        [XmlElement(ElementName = "OrderDetailRequestHeader")]

        public OrderDetailRequestHeader RequestHeader { get; set; }
    }

    public class OrderDetailRequestHeader 
    {

        public string SellerOrderID { get; set; }

        public OrderDetailRequestHeader()
        {

        }
        public OrderDetailRequestHeader(string sellerOrderId)
        {
            this.SellerOrderID = sellerOrderId;
        }
    }
}
