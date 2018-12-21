//using System;
//using System.Threading;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc.Filters;

//namespace Pki.eBusiness.ErpApi.Web.Attributes
//{
//    public abstract class ShopWebApiExceptionHandler : IExceptionHandler
//    {
//        public virtual Task HandleAsync(ExceptionHandlerContext context,
//            CancellationToken cancellationToken)
//        {
//            if (context == null)
//            {
//                throw new ArgumentNullException("context");
//            }

//            if (!ShouldHandle(context))
//            {
//                return Task.FromResult(0);
//            }

//            return HandleAsyncCore(context, cancellationToken);
//        }

//        public virtual Task HandleAsyncCore(ExceptionHandlerContext context,
//            CancellationToken cancellationToken)
//        {
//            HandleCore(context);
//            return Task.FromResult(0);
//        }

//        public virtual void HandleCore(ExceptionHandlerContext context)
//        {
//        }

//        public virtual bool ShouldHandle(ExceptionHandlerContext context)
//        {
//            if (context == null)
//            {
//                throw new ArgumentNullException("context");
//            }
//            ExceptionContext exceptionContext = context.ExceptionContext;
//            ExceptionContextCatchBlock catchBlock = exceptionContext.CatchBlock;
//            return catchBlock.IsTopLevel;
//        }
//    }
//}