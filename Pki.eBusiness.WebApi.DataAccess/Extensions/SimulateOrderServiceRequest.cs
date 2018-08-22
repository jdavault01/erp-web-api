using System.Runtime.Serialization;
using Pki.eBusiness.WebApi.DataAccess.StoreFrontWebServices;
using OrderRequest = Pki.eBusiness.WebApi.Entities.Orders.OrderRequest;
using OrderRequestDetail = Pki.eBusiness.WebApi.Entities.Orders.OrderRequestDetail;
using OrderRequestHeader = Pki.eBusiness.WebApi.Entities.Orders.OrderRequestHeader;
using StorefrontSimulateOrderRequest = Pki.eBusiness.WebApi.Entities.StoreFront.DataObjects.SimulateOrderRequest;

namespace Pki.eBusiness.WebApi.DataAccess.Extensions
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
