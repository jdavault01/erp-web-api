using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Pki.eBusiness.ErpApi.Web.Attributes
{
    public class ExceptionHandlingAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is NullReferenceException)
            {
                context.Result = new NotFoundResult();
            }

            if (context.Exception is NotImplementedException)
            {
                context.Result = new StatusCodeResult(501);
            }

            //Log Critical errors
            Debug.WriteLine(context.Exception);
            context.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "Critical Exception";
            context.Result = new ContentResult
            {
                Content = "An error occurred, please try again or contact the administrator."
            };
            base.OnException(context);
        }
    }
}