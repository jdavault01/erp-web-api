//using System.Net.Http.Formatting;
//using Newtonsoft.Json.Serialization;
//using Pki.eBusiness.ErpApi.Web.Attributes;
//using Pki.eBusiness.ErpApi.Web.Filters;

//namespace Pki.eBusiness.ErpApi.Web
//{
//    public static class WebApiConfig
//    {
//        public static void Register(HttpConfiguration config)
//        {
//            Web API configuration and services

//            Web API routes
//            config.MapHttpAttributeRoutes();

//            config.Routes.MapHttpRoute(
//                name: "DefaultApi",
//                routeTemplate: "wms/{controller}/{id}",
//                defaults: new { id = RouteParameter.Optional }
//            );

//            config.Filters.Add(new ValidationExceptionFilterAttribute());
//            config.Filters.Add(new IPLoggingFilter());
//            config.Services.Replace(typeof(IExceptionHandler), new GeneralExceptionHandler());
//            config.Services.Replace(typeof(IExceptionLogger), new GeneralExceptionLogger());

//            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().FirstOrDefault();
//            if (jsonFormatter != null)
//            {
//                jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
//            }
//        }
//    }
//}
