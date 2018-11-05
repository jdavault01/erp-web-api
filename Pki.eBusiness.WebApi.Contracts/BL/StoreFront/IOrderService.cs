using Pki.eBusiness.WebApi.Entities.OrderLookUp.BasicRequest;
using Pki.eBusiness.WebApi.Entities.Orders;
using Pki.eBusiness.WebApi.Entities.StoreFront.DataObjects;

namespace Pki.eBusiness.WebApi.Contracts.BL.StoreFront
{
   public interface IOrderService
    {
        OrderDetailResponse GetOrderDetails(OrderSummaryLookUpRequest request);
        SimulateOrderResponse SimulateOrder(SimulateOrderRequest request);
        InventoryResponse GetInventory(InventoryRequest priceRequest);
        CreateOrderResponse CreateOrder(CreateOrderRequest request);
        SimulateOrderErpResponse SimulateErpOrder(SimulateOrderErpRequest payload);
    }
}
