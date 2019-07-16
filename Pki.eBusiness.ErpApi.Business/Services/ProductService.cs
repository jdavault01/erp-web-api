using Microsoft.Extensions.Logging;
using Pki.eBusiness.ErpApi.Contract.BL;
using Pki.eBusiness.ErpApi.Contract.DAL;
using Pki.eBusiness.ErpApi.Entities.DataObjects;

namespace Pki.eBusiness.ErpApi.Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IWebMethodClient _webMethodClient;
        private const string NO_PRICE_RESPONSE = "No Price Response";
        private ILogger _logger;

        public ProductService(IWebMethodClient webMethodsClient, ILogger<OrderService> logger)
        {
            _webMethodClient = webMethodsClient;
            _logger = logger;
        }

        public PriceResponse GetPrice(PriceRequest priceRequest)
        {
            return _webMethodClient.GetPrice(priceRequest);
        }

        private void Log(string message)
        {
            _logger.LogInformation(message);
        }

    }
}
