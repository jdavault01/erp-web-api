using System.Xml.Serialization;
using Pki.eBusiness.WebApi.Entities.OrderLookUp.BasicRequest;

namespace Pki.eBusiness.WebApi.Entities.OrderLookUp.OrderDetails
{
    public class OrderDetailRequest : EntityBase
    {
        public OrderLookUpHeader Header { get; set; }

        [XmlElement(ElementName="Body")]
        public OrderDetailBody DetailBody { get; set; }

        public OrderDetailRequest()
        {
            
        }
        public OrderDetailRequest(string logicalId, string orderId)
        {
            this.Header = new OrderLookUpHeader() { VersionNumber = new VersionNumber("001", "001"), Sender = new OrderSender(logicalId, "DisplayOrderDetail") };
            this.DetailBody=new OrderDetailBody(){RequestHeader = new OrderDetailRequestHeader(orderId)};
         

        }
        
    }
    
    public class OrderDetailBody : EntityBase
    {
         [XmlElement(ElementName = "OrderDetailRequestHeader")]
       
        public OrderDetailRequestHeader RequestHeader { get; set; }
    }
    
    public class OrderDetailRequestHeader : EntityBase
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
