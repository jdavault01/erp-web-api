

//using OrderInfoWebServiceRequest = PKI.eBusiness.WMService.Entities.Stubs.StoreFront.OrderInfoWebServiceRequest;
//using OrderInfoWebServiceResponse = PKI.eBusiness.WMService.Entities.Stubs.StoreFront.OrderInfoWebServiceResponse;

using System.Threading.Tasks;
using Pki.eBusiness.ErpApi.Entities.DataObjects;
using Pki.eBusiness.ErpApi.Entities.OrderLookUp.BasicRequest;

namespace Pki.eBusiness.ErpApi.Contract.DAL
{
    public interface IWebMethodClient
    {
        //OrderInfoResponse ProcessOrderLookUpRequest(OrderInfoRequest request);
        OrderDetailResponse GetOrderDetails(OrderSummaryLookUpRequest request);
        PriceResponse GetPrice(PriceRequest priceRequest);
        InventoryResponse GetInventory(InventoryRequest inventoryWmRequest);
        PartnerResponse GetPartnerDetails(SimplePartnerRequest partnerRequest);
        ContactCreateClientResponse CreateContact(ContactCreateClientRequest contactCreateRequest);
        SimulateOrderResponse SimulateOrder(SimulateOrderRequest request);
        CreateOrderResponse CreateOrder(CreateOrderRequest createOrderRequest);
    }
}
