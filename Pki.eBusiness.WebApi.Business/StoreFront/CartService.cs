using Pki.eBusiness.WebApi.Contracts.BL.StoreFront;
using Pki.eBusiness.WebApi.Contracts.DAL;
using Pki.eBusiness.WebApi.Entities.Constants;
using Pki.eBusiness.WebApi.Entities.StoreFront.DataObjects;
using PKI.eBusiness.WMService.Logger;


namespace PKI.eBusiness.WMService.BusinessServices.StoreFront
{

    public class CartService : ICartService
    {
        private readonly IPublisher _publisher = PublisherManager.Instance;
        private readonly IShopCommerceServiceGateway _shopCommerceServiceGateway;

                /// <summary>
        /// Class Constructor used for dependency injection
        /// </summary>
        /// <param name="webMethodsClient"></param>
        /// <param name="shopCommerceServiceAgent"></param>
        public CartService(IShopCommerceServiceGateway shopCommerceServiceAgent)
        {
            _shopCommerceServiceGateway = shopCommerceServiceAgent;

        }

        /// <summary>
        /// This method take the cartInfo from WM and returns a clearanceCode
        /// </summary>
        /// <param name="cartInfo"></param>
        /// <returns></returns>

        public CartInfo GetClearanceCode(CartInfo cartInfo)
        {
            return _shopCommerceServiceGateway.GetClearanceCode(cartInfo); 
        }

        /// <summary>
        /// This method will log message to log file
        /// </summary>
        /// <param name="message">message</param>
        private void Log(string message)
        {
            _publisher.PublishMessage(message, System.Diagnostics.TraceLevel.Info, Constants.LOG_AREA);
        }

    }
}
