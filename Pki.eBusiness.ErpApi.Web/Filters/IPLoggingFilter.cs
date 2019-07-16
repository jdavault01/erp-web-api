using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;

namespace Pki.eBusiness.ErpApi.Web.Filters
{
    public class IPLoggingFilter : IActionFilter
    {
        private ILogger _logger;

        public IPLoggingFilter(ILogger logger)
        {
            _logger = logger;
        }

        string GetClientIp(HttpRequest request)
        {
            var remoteAddr = request?.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            if (remoteAddr == "::1") 
            {
                return request?.HttpContext?.Connection?.LocalIpAddress?.ToString();
            }
            return remoteAddr;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string addr = GetClientIp(context?.HttpContext.Request);
            if (!string.IsNullOrEmpty(addr))
                _logger.Information($"Source IP address: {addr}");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }
    }
}