using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.ServiceModel.Channels;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Mvc;
using PKI.eBusiness.WMService.Logger;
using ActionFilterAttribute = System.Web.Http.Filters.ActionFilterAttribute;

namespace PKI.eBusiness.WMSHttpApi.Filters
{
    public class IPLoggingFilter : ActionFilterAttribute
    {
        readonly IPublisher _publisher = PublisherManager.Instance;
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            string addr = GetClientIp(actionContext?.Request);
            if (!string.IsNullOrEmpty(addr))
                _publisher.PublishMessage($"Source IP address: {addr}", System.Diagnostics.TraceLevel.Info, "STOREFRONT");
            base.OnActionExecuting(actionContext);
        }

        private string GetClientIp(HttpRequestMessage request)
        {
            if (request == null)
                return null;

            if (request.Properties.ContainsKey("MS_HttpContext"))
            {
                return ((HttpContextWrapper)request.Properties["MS_HttpContext"]).Request.UserHostAddress;
            }
            else if (request.Properties.ContainsKey(RemoteEndpointMessageProperty.Name))
            {
                RemoteEndpointMessageProperty prop = (RemoteEndpointMessageProperty)request.Properties[RemoteEndpointMessageProperty.Name];
                return prop.Address;
            }
            else if (HttpContext.Current != null)
            {
                return HttpContext.Current.Request.UserHostAddress;
            }
            else
            {
                return null;
            }
        }
    }
}