using PKI.eBusiness.WMService.Entities.StoreFront.DataObjects;

namespace PKI.eBusiness.WMService.ServiceGatewaysContracts
{
    public interface IShopCommerceServiceGateway
    {
        LoginInfo GetLoginInfo(string companyCode);
        CartInfo GetClearanceCode(CartInfo cartInfo);
    }
}
