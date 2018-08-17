using PKI.eBusiness.WMService.Entities.OrderLookUp.BasicRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PKI.eBusiness.WMService.Entities.StoreFront.DataObjects;

namespace PKI.eBusiness.WMService.BusinessServicesContracts.StoreFront
{
   public interface IOrderService
    {
        OrderLookUpResponse GetOrders(OrderLookUpRequest request);
        OrderDetailResponse GetOrderDetails(string orderId);
        SimulateOrderResponse SimulateOrder(SimulateOrderRequest request);
        InventoryResponse GetInventory(InventoryRequest priceRequest);
        CreateOrderResponse CreateOrder(CreateOrderRequest request);

    }
}
