using Pki.eBusiness.ErpApi.DataAccess.StoreFrontWebServices;
using OrderRequest = Pki.eBusiness.ErpApi.Entities.Orders.OrderRequest;
using OrderRequestDetail = Pki.eBusiness.ErpApi.Entities.Orders.OrderRequestDetail;
using OrderRequestHeader = Pki.eBusiness.ErpApi.Entities.Orders.OrderRequestHeader;
using StorefrontSimulateOrderRequest = Pki.eBusiness.ErpApi.Entities.DataObjects.SimulateOrderRequest;

namespace Pki.eBusiness.ErpApi.DataAccess.Extensions
{

    public class SimulateOrderServiceRequest
    {
        
        public SimulateOrderWebServiceRequest SimulateOrderWebServiceRequest { get; set; }

        
        public orderRequest OrderRequestPayLoad { get; set; }

        
        public OrderRequest Request { get; set; }

        
        public OrderRequestHeader RequestHeader { get; set; }

        
        public OrderRequestDetail RequestDetail { get; set; }

        
        public OrderRequestDetail[] RequestDetails { get; set; }

        public SimulateOrderServiceRequest(StorefrontSimulateOrderRequest clientRequest)
        {

        }

    }
}
