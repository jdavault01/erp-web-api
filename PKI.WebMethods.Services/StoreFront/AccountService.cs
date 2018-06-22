using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PKI.eBusiness.WMService.BusinessServicesContracts.StoreFront;
using PKI.eBusiness.WMService.Entities.StoreFront.Account;
using PKI.eBusiness.WMService.Entities.StoreFront.DataObjects;
using PKI.eBusiness.WMService.Logger;
using PKI.eBusiness.WMService.ServiceGatewaysContracts;
using PKI.eBusiness.WMService.Utility;

namespace PKI.eBusiness.WMService.BusinessServices.StoreFront
{
    public class AccountService : IAccountService
    {
        private readonly IPublisher _publisher = PublisherManager.Instance;
        private readonly IWebMethodClient _webMethodClient;
        private readonly IShopCommerceServiceAgent _shopCommerceServiceAgent;

        private const string NO_PRICE_RESPONSE = "No Price Respnose";

        /// <summary>
        /// Class Constructor used for dependency injection
        /// </summary>
        /// <param name="webMethodsClient"></param>
        /// <param name="shopCommerceServiceAgent"></param>
        public AccountService(IWebMethodClient webMethodsClient, IShopCommerceServiceAgent shopCommerceServiceAgent)
        {
            _webMethodClient = webMethodsClient;
            _shopCommerceServiceAgent = shopCommerceServiceAgent;

        }

        /// <summary>
        /// THIS METHOD WILL BE DECOMMISIONED AFTER CART PROJECT
        /// </summary>
        /// <param name="partnerRequest"></param>
        /// <returns></returns>
        public PartnerResponse GetPartnerInfo(PartnerRequest partnerRequest)
        {
            return _webMethodClient.GetPartnerInfo(partnerRequest);

        }

        /// <summary>
        /// This method takes a client partner request model and converts, makes calls and converts response
        /// back to client side model
        /// </summary>
        /// <param name="partnerRequest"></param>
        /// <returns></returns>
        public PartnerResponse GetPartnerDetails(SimplePartnerRequest partnerRequest)
        {
            return _webMethodClient.GetPartnerDetails(partnerRequest);
        }
        /// <summary>
        /// This method takes a companycode and get the available username and password
        /// </summary>
        /// <param name="companyCode"></param>
        /// <returns></returns>
        public LoginInfo GetLoginInfo(String companyCode)
        {
            return _shopCommerceServiceAgent.GetLoginInfo(companyCode);

        }

        /// <summary>
        /// This method takes a client partner request model and converts, makes calls and converts response
        /// back to client side model
        /// </summary>
        /// <param name="partnerRequest"></param>
        /// <returns></returns>
        public ContactCreateResponse CreateContact(String accountNumber, ContactCreateRequest contactCreateRequest)
        {
            return _webMethodClient.CreateContact(accountNumber, contactCreateRequest);

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
