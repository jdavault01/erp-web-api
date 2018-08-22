using System.Runtime.Serialization;
using PKI.eBusiness.WMService.ServiceGateways.StoreFrontWebServices;
using OrderRequest = PKI.eBusiness.WMService.Entities.Orders.OrderRequest;
using OrderRequestDetail = PKI.eBusiness.WMService.Entities.Orders.OrderRequestDetail;
using OrderRequestHeader = PKI.eBusiness.WMService.Entities.Orders.OrderRequestHeader;
using StorefrontSimulateOrderRequest = PKI.eBusiness.WMService.Entities.StoreFront.DataObjects.SimulateOrderRequest;

namespace PKI.eBusiness.WMService.ServiceGateways.Extensions
{

    public class SimulateOrderServiceRequest
    {
        [DataMember]
        public SimulateOrderWebServiceRequest SimulateOrderWebServiceRequest { get; set; }

        [DataMember]
        public orderRequest OrderRequestPayLoad { get; set; }

        [DataMember]
        public OrderRequest Request { get; set; }

        [DataMember]
        public OrderRequestHeader RequestHeader { get; set; }

        [DataMember]
        public OrderRequestDetail RequestDetail { get; set; }

        [DataMember]
        public OrderRequestDetail[] RequestDetails { get; set; }

        public SimulateOrderServiceRequest(StorefrontSimulateOrderRequest clientRequest)
        {

        }

    }
}
