using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Pki.eBusiness.ErpApi.Logger;

namespace Pki.eBusiness.ErpApi.Web.Filters
{
    public class IPLoggingFilter : IActionFilter
    {
        readonly IPublisher _publisher = PublisherManager.Instance;

        string GetClientIp(HttpRequest request) =>
            request?.HttpContext?.Connection?.RemoteIpAddress?.ToString();


        public void OnActionExecuting(ActionExecutingContext context)
        {
            string addr = GetClientIp(context?.HttpContext.Request);
            if (!string.IsNullOrEmpty(addr))
                _publisher.PublishMessage($"Source IP address: {addr}", System.Diagnostics.TraceLevel.Info, "STOREFRONT");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }
    }
}