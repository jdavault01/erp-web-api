using Pki.eBusiness.WebApi.Entities.StoreFront.DataObjects;

namespace Pki.eBusiness.WebApi.Contracts.BL.StoreFront
{
    public interface ICartService
    {
        CartInfo GetClearanceCode(CartInfo cartInfo);
    }
}
