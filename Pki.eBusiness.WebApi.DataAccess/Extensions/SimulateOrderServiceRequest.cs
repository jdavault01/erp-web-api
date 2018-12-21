using System.Runtime.Serialization;
using Pki.eBusiness.ErpApi.DataAccess.StoreFrontWebServices;
using OrderRequest = Pki.eBusiness.ErpApi.Entities.Orders.OrderRequest;
using OrderRequestDetail = Pki.eBusiness.ErpApi.Entities.Orders.OrderRequestDetail;
using OrderRequestHeader = Pki.eBusiness.ErpApi.Entities.Orders.OrderRequestHeader;
using StorefrontSimulateOrderRequest = Pki.eBusiness.ErpApi.Entities.DataObjects.SimulateOrderRequest;

namespace Pki.eBusiness.ErpApi.DataAccess.Extensions
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
