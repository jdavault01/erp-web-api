using Pki.eBusiness.ErpApi.Entities.OrderLookUp.BasicRequest;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using Pki.eBusiness.ErpApi.DataAccess.Extensions;

namespace Pki.eBusiness.ErpApi.DataAccess.Models.Orders
{
    public class OrderLookUpBody
    {
        [XmlElement(ElementName = "OrderSummaryRequestHeader", Namespace = "")]
        public OrderSummaryRequestHeader RequestHeader { get; set; }
    }
    public class OrderLookUpHeader
    {
        [XmlElement(ElementName = "Version")]
        public VersionNumber VersionNumber { get; set; }

        public OrderSender Sender { get; set; }

    }

    public class VersionNumber
    {
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
        [XmlText]
        public string Data { get; set; }

        public VersionNumber()
        {

        }
        public VersionNumber(string value, string data)
        {
            this.Value = value;
            this.Data = data;
        }

    }
    //[DataContract]
    //public class OrderSummaryLookUpRequest
    //{
    //    public ShipTo LookUpShipTo { get; set; }

    //    [DataMember]
    //    public string ShipToId { get; set; }

    //    [DataMember]
    //    public string SAPOrderNumber { get; set; }

    //    [DataMember]
    //    [XmlElement(ElementName = "language")]
    //    public string Language { get; set; }

    //    public OrderSummaryLookUpRequest(string language, string sellerOrderId)
    //    {
    //        SAPOrderNumber = sellerOrderId;
    //        Language = language;
    //        LookUpShipTo = new ShipTo(sellerOrderId);
    //    }
    //}
    public class OrderSender 
    {
        public string LogicalID { get; set; }
        public string Task { get; set; }

        public OrderSender()
        {

        }
        public OrderSender(string logicalId, string task)
        {
            this.LogicalID = logicalId;
            this.Task = task;
        }
    }

    public class OrderSummaryRequest
    {
        public const string ORDER_SUMMARY_REQUEST_ELEMENT = "OrderSummaryRequest";
        public const string DTD_SUMMARY_REQUEST_SYSID = "OrderSummaryInput.dtd";

        public OrderLookUpHeader Header { get; set; }
        public OrderLookUpBody Body { get; set; }

        public OrderSummaryRequest(OrderSummaryLookUpRequest request)
        {
            var shipToList = new List<ShipTo>
            {
                GetDefaultShipTo(request.SAPOrderNumber)
            };
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

            };
            Body = new OrderLookUpBody()
            {
                RequestHeader = new OrderSummaryRequestHeader()
                {
                    ContactNameID = string.Empty,
                    DivisionID = "02",
                    DistChannelID = "01",
                    ToDateString = string.Empty,
                    FromDateString = string.Empty,
                    Language = request.Language,
                    ShipToList = shipToList
                }

            };

        }
        public OrderSummaryRequest()
        {

        }

        public OrderInfoRequest ToRequest()
        {
            return new OrderInfoRequest
            {
                xmlRequest = this.SerializeToXml(ORDER_SUMMARY_REQUEST_ELEMENT, DTD_SUMMARY_REQUEST_SYSID, false)
            };
        }


        private ShipTo GetDefaultShipTo(string sapOrderNumber)
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
    }


    public class OrderSummaryRequestHeader
    {
        public string ContactNameID { get; set; }
        public string SalesOrgID { get; set; }
        public string DivisionID { get; set; }
        public string DistChannelID { get; set; }
        public List<ShipTo> ShipToList { get; set; }
        [XmlElement(ElementName = "FromDate")]
        public string FromDateString { get; set; }
        [XmlElement(ElementName = "ToDate")]
        public string ToDateString { get; set; }
        [XmlElement(ElementName = "language")]
        public string Language { get; set; }


    }
    public class PurchaseOrderID
    {
        [XmlText]
        public string Data { get; set; }
    }
    public class SellerOrderID 
    {
        [XmlText]
        public string Data { get; set; }
    }

    [DataContract]
    public class ShipTo 
    {
        [DataMember]
        public string ShipToID { get; set; }
        [DataMember]
        // [XmlElement(ElementName="SAPOrderList")]
        public List<SellerOrderID> SAPOrderList { get; set; }
        [DataMember]
        public List<PurchaseOrderID> PurchaseOrderList { get; set; }

        public ShipTo() { }

        public ShipTo(string sellerOrderNumber)
        {
            var sellerOrderID = new SellerOrderID { Data = sellerOrderNumber };
            SAPOrderList = new List<SellerOrderID> { sellerOrderID };
        }

    }
}