
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pki.eBusiness.ErpApi.Contract.BL;

namespace Pki.eBusiness.ErpApi.Web.Controllers
{
    [Route("shop/cart/[action]")]
    public class CartController : ControllerBase
    {
        readonly ICartService _cartservice;
        private ILogger _logger;

        public CartController(ICartService cartService, ILogger<CartController> logger)
        {
            _cartservice = cartService;
            _logger = logger;
        }

        private void Log(string message)
        {
            _logger.LogInformation(message);
        }

    }
}