
//using PKI.eBusiness.WMService.Entities.StoreFront.DataObjects;

using Pki.eBusiness.ErpApi.Entities.DataObjects;

namespace Pki.eBusiness.ErpApi.Contract.BL
{
    public interface IProductService
    {
        PriceResponse GetPrice(PriceRequest priceRequest);
    }
}
