using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;

namespace PKI.eBusiness.WMSHttpApi.Attributes
{
    public class ExceptionHandlingAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            //if (context.Exception is PKIWMException)
            //{
            //    throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError)
            //    {
            //        Content = new StringContent(context.Exception.Message),
            //        ReasonPhrase = "Exception"
            //    });

            //}

            if (context.Exception is NullReferenceException)
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.NotFound);
            }

            if (context.Exception is NotImplementedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotImplemented)
                {
                    Content = new StringContent(context.Exception.Message),
                    ReasonPhrase = "Exception"
                });

            }
            
            //Log Critical errors
            Debug.WriteLine(context.Exception);

            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent("An error occurred, please try again or contact the administrator."),
                ReasonPhrase = "Critical Exception"
            });
        }
    }
}