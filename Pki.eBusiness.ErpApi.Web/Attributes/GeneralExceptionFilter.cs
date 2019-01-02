using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Pki.eBusiness.ErpApi.Web.Models;

namespace Pki.eBusiness.ErpApi.Web.Attributes
{
    public class ValidationExceptionFilterAttribute : ExceptionFilterAttribute
    {
        
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is ValidationException)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(context.Exception.Message),
                    ReasonPhrase = "ValidationException"
                };
                //throw new httpreqHttpResponseException(resp);
                context.ExceptionHandled = true;
                
            }
            else
            {
                context.Result = new JsonResult(new ExceptionResponse(context.Exception));
                context.HttpContext.Response.StatusCode = 500;
            }
        }
    }
}