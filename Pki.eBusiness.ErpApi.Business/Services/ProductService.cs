using Pki.eBusiness.ErpApi.Contract.BL;
using Pki.eBusiness.ErpApi.Contract.DAL;
using Pki.eBusiness.ErpApi.Entities.Constants;
using Pki.eBusiness.ErpApi.Entities.DataObjects;
using Pki.eBusiness.ErpApi.Logger;

namespace Pki.eBusiness.ErpApi.Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IPublisher _publisher = PublisherManager.Instance;
        private readonly IWebMethodClient _webMethodClient;
        private const string NO_PRICE_RESPONSE = "No Price Response";

        /// <summary>
        /// Class Constructor used for dependency injection
        /// </summary>
        /// <param name="webMethodsClient"></param>
        public ProductService(IWebMethodClient webMethodsClient)
        {
            _webMethodClient = webMethodsClient;

        }

        /// <summary>
        /// This method takes a client price request model and converts, makes calls and converts response
        /// back to client side model
        /// </summary>
        /// <param name="priceRequest">request</param>
        /// <returns>OrderSummaryResponse</returns>
        public PriceResponse GetPrice(PriceRequest priceRequest)
        {
            return _webMethodClient.GetPrice(priceRequest);
        }

        /// <summary>
        /// This method will log message to log file
        /// </summary>
        /// <param name="message">message</param>
        private void Log(string message)
        {
            _publisher.PublishMessage(message, System.Diagnostics.TraceLevel.Info, Constants.LOG_AREA_STOREFRONT);
        }

    }
}
