//using System;
//using System.Net;
//using System.Net.Http;
//using System.Threading;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;

//namespace Pki.eBusiness.ErpApi.Web.Attributes
//{
//    public class GeneralExceptionHandler : ShopWebApiExceptionHandler
//{
//    public override void HandleCore(ExceptionHandlerContext context)
//    {
//        context.Result = new TextPlainErrorResult
//        {
//            ReasonPhrase = "Critical Unhandled Exception",
//            Request = context.ExceptionContext.Request,
//            Content = context.Exception.ToString()
//        };
//    }
//}


//public class TextPlainErrorResult : IActionResult
//{
//    public HttpRequestMessage Request { get; set; }

//    public String ReasonPhrase { get; set; }
//    public string Content { get; set; }

//    public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
//    {
//        var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
//        {
//            Content = new StringContent(Content),
//            RequestMessage = Request,
//            ReasonPhrase = ReasonPhrase
//        };
//        return Task.FromResult(response);
//    }

//    public Task ExecuteResultAsync(ActionContext context)
//    {
//        throw new NotImplementedException();
//    }
//}

//}