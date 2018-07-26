using PKI.eBusiness.WMService.Entities.StoreFront.DataObjects;

namespace PKI.eBusiness.WMService.BusinessServicesContracts.StoreFront
{
    public interface ICartService
    {
        CartInfo GetClearanceCode(CartInfo cartInfo);
    }
}
