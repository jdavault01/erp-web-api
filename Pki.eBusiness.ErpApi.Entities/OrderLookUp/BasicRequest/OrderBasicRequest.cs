using System.Collections.Generic;
using System.Xml.Serialization;
using Pki.eBusiness.ErpApi.Entities;

namespace Pki.eBusiness.ErpApi.Entities.OrderLookUp.BasicRequest
{
    //public class OrderLookUpBody
    //{
    //    [XmlElement(ElementName="OrderSummaryRequestHeader",Namespace = "")]
    //    public OrderSummaryRequestHeader RequestHeader { get; set; }
    //}
    //public class OrderLookUpHeader : EntityBase
    //{
    //    [XmlElement(ElementName ="Version")]
    //    public VersionNumber VersionNumber { get; set; }

    //    public OrderSender Sender { get; set; }

    //}

    //public class VersionNumber
    //{
    //    [XmlAttribute(AttributeName = "value")]
    //    public  string Value { get; set; }
    //    [XmlText]
    //    public  string Data { get; set; }

    //    public VersionNumber()
    //    {
            
    //    }
    //    public VersionNumber(string value, string data)
    //    {
    //        this.Value = value;
    //        this.Data = data;
    //    }

    //}
    
    public class OrderSummaryLookUpRequest
    {
        public ShipTo LookUpShipTo { get; set; }

        
        public string ShipToId { get; set; }

        
        public string SAPOrderNumber { get; set; }

        
        [XmlElement(ElementName = "language")]
        public  string Language { get; set; }

        public OrderSummaryLookUpRequest (string language, string sellerOrderId)
        {
            SAPOrderNumber = sellerOrderId;
            Language = language;
            LookUpShipTo = new ShipTo(sellerOrderId);
        }
    }
    //public class OrderSender : EntityBase
    //{
    //    public string LogicalID { get; set; }
    //    public string Task { get; set; }

    //    public OrderSender()
    //    {

    //    }
    //    public OrderSender(string logicalId, string task)
    //    {
    //        this.LogicalID = logicalId;
    //        this.Task = task;
    //    }
    //}

    //public class OrderSummaryRequest : EntityBase
    //{
    //    public OrderLookUpHeader Header { get; set; }
    //    public OrderLookUpBody Body { get; set; }
    //}

    //public class OrderSummaryRequestHeader : EntityBase
    //{
    //    public string ContactNameID { get; set; }
    //    public string SalesOrgID { get; set; }
    //    public string DivisionID { get; set; }
    //    public string DistChannelID { get; set; }
    //    public List<ShipTo> ShipToList { get; set; }
    //    [XmlElement(ElementName = "FromDate")]
    //    public string FromDateString { get; set; }
    //    [XmlElement(ElementName = "ToDate")]
    //    public string ToDateString { get; set; }
    //    [XmlElement(ElementName = "language")]
    //    public string Language { get; set; }


    //}
    public class PurchaseOrderID : EntityBase
    {
        [XmlText]
        public string Data { get; set; }
    }
    public class SellerOrderID : EntityBase
    {
        [XmlText]
        public string Data { get; set; }
    }


    public class ShipTo : EntityBase
    {

        public string ShipToID { get; set; }

        // [XmlElement(ElementName="SAPOrderList")]
        public List<SellerOrderID> SAPOrderList { get; set; }

        public List<PurchaseOrderID> PurchaseOrderList { get; set; }

        public ShipTo() { }

        public ShipTo(string sellerOrderNumber)
        {
            var sellerOrderID = new SellerOrderID { Data = sellerOrderNumber };
            SAPOrderList = new List<SellerOrderID> { sellerOrderID };
        }

    }
}
