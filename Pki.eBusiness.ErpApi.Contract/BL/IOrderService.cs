using Pki.eBusiness.ErpApi.Entities.DataObjects;
using Pki.eBusiness.ErpApi.Entities.OrderLookUp.BasicRequest;
using Pki.eBusiness.ErpApi.Entities.Orders;

namespace Pki.eBusiness.ErpApi.Contract.BL
{
   public interface IOrderService
    {
        OrderDetailResponse GetOrderDetails(OrderSummaryLookUpRequest request);
        SimulateOrderResponse SimulateOrder(SimulateOrderRequest request);
        InventoryResponse GetInventory(InventoryRequest priceRequest);
        CreateOrderResponse CreateOrder(CreateOrderRequest request);
        SimulateOrderErpResponse SimulateErpOrder(SimulateOrderErpRequest payload);
        ShippingNotificationResponse SendShippingNotification(ShippingNotification payload);
    }
}
