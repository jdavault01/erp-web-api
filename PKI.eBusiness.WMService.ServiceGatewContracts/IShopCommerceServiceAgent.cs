using PKI.eBusiness.WMService.Entities.StoreFront.Account;
using PKI.eBusiness.WMService.Entities.StoreFront.Orders;

namespace PKI.eBusiness.WMService.ServiceGatewaysContracts
{
    public interface IShopCommerceServiceAgent
    {
        LoginInfo GetLoginInfo(string companyCode);
        CartInfo GetClearanceCode(CartInfo cartInfo);
    }
}
