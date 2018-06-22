using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PKI.eBusiness.WMService.Entities.Orders;
using PKI.eBusiness.WMService.Entities.StoreFront.DataObjects;
using OrderInfoWebServiceRequest = PKI.eBusiness.WMService.Entities.Stubs.StoreFront.OrderInfoWebServiceRequest;
using OrderInfoWebServiceResponse = PKI.eBusiness.WMService.Entities.Stubs.StoreFront.OrderInfoWebServiceResponse;

namespace PKI.eBusiness.WMService.ServiceGatewaysContracts
{
    public interface IWebMethodClient
    {
        string ProcessOrderSubmission(Order order);
        OrderInfoWebServiceResponse ProcessOrderLookUpRequest(OrderInfoWebServiceRequest request);
        PriceResponse GetPrice(PriceRequest priceRequest);
        InventoryResponse GetInventory(InventoryRequest inventoryWmRequest);
        //Will be decommisioned after we go live with Cart
        PartnerResponse GetPartnerInfo(PartnerRequest partnerRequest);
        //New Partner request with simpler JSON
        PartnerResponse GetPartnerDetails(SimplePartnerRequest partnerRequest);
        ContactCreateResponse CreateContact(String accountNumber, ContactCreateRequest contactCreateRequest);
        SimulateOrderResponse SimulateOrder(SimulateOrderRequest request);
 
    }
}
