

using Pki.eBusiness.ErpApi.Entities.DataObjects;

namespace Pki.eBusiness.ErpApi.Contract.DAL
{
    public interface IShopCommerceServiceGateway
    {
        LoginInfo GetLoginInfo(string companyCode);
        CartInfo GetClearanceCode(CartInfo cartInfo);
    }
}
