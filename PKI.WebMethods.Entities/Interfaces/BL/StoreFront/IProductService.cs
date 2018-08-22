using PKI.eBusiness.WMService.Entities.StoreFront.DataObjects;
//using PKI.eBusiness.WMService.Entities.StoreFront.DataObjects;

namespace PKI.eBusiness.WMService.Entities.Interfaces.BL.StoreFront
{
    public interface IProductService
    {
        PriceResponse GetPrice(PriceRequest priceRequest);
    }
}
