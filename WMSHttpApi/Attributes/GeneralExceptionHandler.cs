using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace PKI.eBusiness.WMSHttpApi.Attributes
{
    public class GeneralExceptionHandler : ShopWebApiExceptionHandler
{
    public override void HandleCore(ExceptionHandlerContext context)
    {
        context.Result = new TextPlainErrorResult
        {
            ReasonPhrase = "Critical Unhandled Exception",
            Request = context.ExceptionContext.Request,
            Content = context.Exception.ToString()
        };
    }
}


public class TextPlainErrorResult : IHttpActionResult
{
    public HttpRequestMessage Request { get; set; }

    public String ReasonPhrase { get; set; }
    public string Content { get; set; }

    public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
    {
        var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
        {
            Content = new StringContent(Content),
            RequestMessage = Request,
            ReasonPhrase = ReasonPhrase
        };
        return Task.FromResult(response);
    }
}

}