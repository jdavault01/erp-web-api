using System.Linq;
using Pki.eBusiness.ErpApi.Contracts.DAL;
using Pki.eBusiness.ErpApi.Entities.DataObjects;

namespace Pki.eBusiness.ErpApi.DataAccess
{
    //private readonly ServiceObjects.I _client;
    public class ShopCommerceServiceGateway : IShopCommerceServiceGateway
    {
        //Interface of remote WCF ShopCommerce Service
        private readonly ShopCommerce.IShopCommerceService _shopCommerceClient ;
        
        //Proxying this client to the remote WCF client
        public ShopCommerceServiceGateway() : this(new ShopCommerce.ShopCommerceServiceClient()){ }
        ////Contructor Injection
        internal ShopCommerceServiceGateway(ShopCommerce.IShopCommerceService shopCommerceService)
        {
            _shopCommerceClient = shopCommerceService;
        }

        public LoginInfo GetLoginInfo(string companyCode)
        {
            var remoteLoginInfo = _shopCommerceClient.GetLoginInfo(companyCode);
            var loginInfo = new LoginInfo()
            {
                Password = remoteLoginInfo.Password,
                UserName = remoteLoginInfo.UserName
            };

            return loginInfo;
        }
        /// <summary>
        /// GetClearance code from ShopCommerceService WCF
        /// </summary>
        /// <param name="cartInfo"></param>
        /// <returns></returns>
        public CartInfo GetClearanceCode(CartInfo cartInfo)
        {
            //Convert local cartItem into ShopCommerce cartItems
            var shopCartInfo = new ShopCommerce.CartInfo()
            {
                CartItems = cartInfo.CartItems.Select(x => new ShopCommerce.CartInfoItem()
                {
                    CartId = x.CartId,
                    ItemId = x.ItemId
                }).ToList()
            };

            //Convert ShopCommerce cartItem into local cartItems
            shopCartInfo = _shopCommerceClient.GetClearanceCode(shopCartInfo);
            cartInfo.CartItems = shopCartInfo.CartItems.Select(x => new CartInfoItem()
            {
                CartId = x.CartId,
                ItemId = x.ItemId,
                ClearanceCode = x.ClearanceCode
            }).ToList();

            return cartInfo;
        }

    }
}
