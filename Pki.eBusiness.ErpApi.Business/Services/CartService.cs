using Microsoft.Extensions.Logging;
using Pki.eBusiness.ErpApi.Contract.BL;

namespace Pki.eBusiness.ErpApi.Business.Services
{

    public class CartService : ICartService
    {
        private ILogger _logger;

        public CartService(ILogger<OrderService> logger)
        {
            _logger = logger;
        }

        private void Log(string message)
        {
            _logger.LogInformation(message);
        }
    }
}
