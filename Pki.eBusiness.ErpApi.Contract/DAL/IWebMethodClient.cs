

//using OrderInfoWebServiceRequest = PKI.eBusiness.WMService.Entities.Stubs.StoreFront.OrderInfoWebServiceRequest;
//using OrderInfoWebServiceResponse = PKI.eBusiness.WMService.Entities.Stubs.StoreFront.OrderInfoWebServiceResponse;

using System.Threading.Tasks;
using Pki.eBusiness.ErpApi.Entities.DataObjects;
using Pki.eBusiness.ErpApi.Entities.OrderLookUp.BasicRequest;

namespace Pki.eBusiness.ErpApi.Contract.DAL
{
    public interface IWebMethodClient
    {
        OrderInfoResponse ProcessOrderLookUpRequest(OrderInfoRequest request);
        PriceResponse GetPrice(PriceRequest priceRequest);
        InventoryResponse GetInventory(InventoryRequest inventoryWmRequest);
        //Will be decommisioned after we go live with Cart
        //PartnerResponse GetPartnerInfo(PartnerRequest partnerRequest);
        //New Partner request with simpler JSON
        PartnerResponse GetPartnerDetails(SimplePartnerRequest partnerRequest);
        ContactCreateResponse CreateContact(ContactCreateRequest contactCreateRequest);
        SimulateOrderResponse SimulateOrder(SimulateOrderRequest request);
        CreateOrderResponse CreateOrder(CreateOrderRequest createOrderRequest);
    }
}
