using PKI.eBusiness.WMService.Entities.StoreFront.DataObjects;

namespace PKI.eBusiness.WMService.Entities.Interfaces.BL.StoreFront
{
    public interface ICartService
    {
        CartInfo GetClearanceCode(CartInfo cartInfo);
    }
}
