﻿using PKI.eBusiness.WMService.BusinessServicesContracts.StoreFront;
using PKI.eBusiness.WMService.Entities.StoreFront.DataObjects;
using PKI.eBusiness.WMService.Logger;
using PKI.eBusiness.WMService.ServiceGatewaysContracts;
using PKI.eBusiness.WMService.Utility;


namespace PKI.eBusiness.WMService.BusinessServices.StoreFront
{

    public class CartService : ICartService
    {
        private readonly IPublisher _publisher = PublisherManager.Instance;
        private readonly IShopCommerceServiceAgent _shopCommerceServiceAgent;

                /// <summary>
        /// Class Constructor used for dependency injection
        /// </summary>
        /// <param name="webMethodsClient"></param>
        /// <param name="shopCommerceServiceAgent"></param>
        public CartService(IShopCommerceServiceAgent shopCommerceServiceAgent)
        {
            _shopCommerceServiceAgent = shopCommerceServiceAgent;

        }

        /// <summary>
        /// This method take the cartInfo from WM and returns a clearanceCode
        /// </summary>
        /// <param name="cartInfo"></param>
        /// <returns></returns>

        public CartInfo GetClearanceCode(CartInfo cartInfo)
        {
            return _shopCommerceServiceAgent.GetClearanceCode(cartInfo); 
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
