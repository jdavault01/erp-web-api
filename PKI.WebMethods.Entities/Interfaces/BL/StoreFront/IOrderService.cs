using PKI.eBusiness.WMService.Entities.OrderLookUp.BasicRequest;
using PKI.eBusiness.WMService.Entities.Orders;
using PKI.eBusiness.WMService.Entities.StoreFront.DataObjects;

namespace PKI.eBusiness.WMService.Entities.Interfaces.BL.StoreFront
{
   public interface IOrderService
    {
        OrderLookUpResponse GetOrders(OrderLookUpRequest request);
        OrderDetailResponse GetOrderDetails(string orderId);
        SimulateOrderResponse SimulateOrder(SimulateOrderRequest request);
        InventoryResponse GetInventory(InventoryRequest priceRequest);
        CreateOrderResponse CreateOrder(CreateOrderRequest request);

        SimulateOrderErpResponse SimulateErpOrder(SimulateOrderErpRequest payload);
    }
}
