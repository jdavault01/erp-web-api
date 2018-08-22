

using Pki.eBusiness.WebApi.Entities.StoreFront.DataObjects;

namespace Pki.eBusiness.WebApi.Contracts.DAL
{
    public interface IShopCommerceServiceGateway
    {
        LoginInfo GetLoginInfo(string companyCode);
        CartInfo GetClearanceCode(CartInfo cartInfo);
    }
}
