using System;
using Pki.eBusiness.WebApi.Entities.OrderLookUp.BasicRequest;
using Pki.eBusiness.WebApi.Entities.Orders;
using Pki.eBusiness.WebApi.Entities.StoreFront.DataObjects;

//using OrderInfoWebServiceRequest = PKI.eBusiness.WMService.Entities.Stubs.StoreFront.OrderInfoWebServiceRequest;
//using OrderInfoWebServiceResponse = PKI.eBusiness.WMService.Entities.Stubs.StoreFront.OrderInfoWebServiceResponse;

namespace Pki.eBusiness.WebApi.Contracts.DAL
{
    public interface IWebMethodClient
    {
        OrderInfoResponse ProcessOrderLookUpRequest(OrderInfoRequest request);
        PriceResponse GetPrice(PriceRequest priceRequest);
        InventoryResponse GetInventory(InventoryRequest inventoryWmRequest);
        //Will be decommisioned after we go live with Cart
        //PartnerResponse GetPartnerInfo(PartnerRequest partnerRequest);
        //New Partner request with simpler JSON
        //PartnerResponse GetPartnerDetails(SimplePartnerRequest partnerRequest);
        ContactCreateResponse CreateContact(ContactCreateRequest contactCreateRequest);
        SimulateOrderResponse SimulateOrder(SimulateOrderRequest request);
        CreateOrderResponse CreateOrder(CreateOrderRequest createOrderRequest);
    }
}
