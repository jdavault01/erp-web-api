using System;
using Pki.eBusiness.WebApi.Contracts.BL.StoreFront;
using Pki.eBusiness.WebApi.Contracts.DAL;
using Pki.eBusiness.WebApi.Entities.Constants;
using Pki.eBusiness.WebApi.Entities.StoreFront.DataObjects;
using PKI.eBusiness.WMService.Logger;

namespace Pki.eBusiness.WebApi.Business.StoreFront
{
    public class AccountService : IAccountService
    {
        private readonly IPublisher _publisher = PublisherManager.Instance;
        private readonly IWebMethodClient _webMethodClient;
        private readonly IShopCommerceServiceGateway _shopCommerceServiceGateway;

        private const string NO_PRICE_RESPONSE = "No Price Respnose";

        /// <summary>
        /// Class Constructor used for dependency injection
        /// </summary>
        /// <param name="webMethodsClient"></param>
        /// <param name="shopCommerceServiceAgent"></param>
        public AccountService(IWebMethodClient webMethodsClient, IShopCommerceServiceGateway shopCommerceServiceAgent)
        {
            _webMethodClient = webMethodsClient;
            _shopCommerceServiceGateway = shopCommerceServiceAgent;

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
            return _shopCommerceServiceGateway.GetLoginInfo(companyCode);

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
