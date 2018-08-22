using System;
using PKI.eBusiness.WMService.Entities.OrderLookUp.BasicRequest;
using PKI.eBusiness.WMService.Entities.Orders;
using PKI.eBusiness.WMService.Entities.StoreFront.DataObjects;

//using OrderInfoWebServiceRequest = PKI.eBusiness.WMService.Entities.Stubs.StoreFront.OrderInfoWebServiceRequest;
//using OrderInfoWebServiceResponse = PKI.eBusiness.WMService.Entities.Stubs.StoreFront.OrderInfoWebServiceResponse;

namespace PKI.eBusiness.WMService.Entities.Interfaces.DAL
{
    public interface IWebMethodClient
    {
        string ProcessOrderSubmission(Order order);
        OrderInfoResponse ProcessOrderLookUpRequest(OrderInfoRequest request);
        PriceResponse GetPrice(PriceRequest priceRequest);
        InventoryResponse GetInventory(InventoryRequest inventoryWmRequest);
        //Will be decommisioned after we go live with Cart
        PartnerResponse GetPartnerInfo(PartnerRequest partnerRequest);
        //New Partner request with simpler JSON
        PartnerResponse GetPartnerDetails(SimplePartnerRequest partnerRequest);
        ContactCreateResponse CreateContact(String accountNumber, ContactCreateRequest contactCreateRequest);
        SimulateOrderResponse SimulateOrder(SimulateOrderRequest request);
        CreateOrderResponse CreateOrder(CreateOrderRequest createOrderRequest);


    }
}
