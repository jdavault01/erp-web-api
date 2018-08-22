
//using PKI.eBusiness.WMService.Entities.StoreFront.DataObjects;

using Pki.eBusiness.WebApi.Entities.StoreFront.DataObjects;

namespace Pki.eBusiness.WebApi.Contracts.BL.StoreFront
{
    public interface IProductService
    {
        PriceResponse GetPrice(PriceRequest priceRequest);
    }
}
