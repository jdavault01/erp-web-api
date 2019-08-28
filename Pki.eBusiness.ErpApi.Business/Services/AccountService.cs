using Microsoft.Extensions.Logging;
using Pki.eBusiness.ErpApi.Contract.BL;
using Pki.eBusiness.ErpApi.Contract.DAL;
using Pki.eBusiness.ErpApi.Entities.DataObjects;

namespace Pki.eBusiness.ErpApi.Business.Services
{
    public class AccountService : IAccountService
    {
        private readonly IWebMethodClient _webMethodClient;
        private readonly IERPRestGateway _erpGateway;
        private readonly ILogger _logger;

        private const string NO_PRICE_RESPONSE = "No Price Respnose";

        /// <summary>
        /// Class Constructor used for dependency injection
        /// </summary>
        /// <param name="webMethodsClient"></param>
        /// <param name="shopCommerceServiceAgent"></param>
        public AccountService(IWebMethodClient webMethodsClient, IERPRestGateway erpGateway, ILogger<AccountService> logger)
        {
            _webMethodClient = webMethodsClient;
            _erpGateway = erpGateway;
            _logger = logger;

        }

        /// <summary>
        /// THIS METHOD WILL BE DECOMMISIONED AFTER CART PROJECT -- confirm use in product .. can probably remove sooner
        /// </summary>
        /// <param name="partnerRequest"></param>
        /// <returns></returns>
        //public PartnerResponse GetPartnerInfo(PartnerRequest partnerRequest)
        //{
        //    return _webMethodClient.GetPartnerInfo(partnerRequest);

        //}

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
        /// New method that talke to Boomi
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public PartnerResponse PartnerLookup(SimplePartnerRequest request)
        {
            return _erpGateway.SimplePartnerLookup(request);

        }

        /// <summary>
        /// This method takes a client partner request model and converts, makes calls and converts response
        /// back to client side model
        /// </summary>
        /// <param name="partnerRequest"></param>
        /// <returns></returns>
        public ContactCreateClientResponse CreateContact(ContactCreateClientRequest contactCreateRequest)
        {
            return _webMethodClient.CreateContact(contactCreateRequest);

        }

        /// <summary>
        /// This method will log message to log file
        /// </summary>
        /// <param name="message">message</param>
        private void Log(string message)
        {
            _logger.LogInformation(message);
            //_publisher.PublishMessage(message, System.Diagnostics.TraceLevel.Info, Constants.LOG_AREA);
        }

    }
}
