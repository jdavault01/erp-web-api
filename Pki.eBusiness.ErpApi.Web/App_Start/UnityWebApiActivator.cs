//using Pki.eBusiness.ErpApi.DataAccess.ErpApi;
//using Pki.eBusiness.ErpApi.Web;

//[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(UnityWebApiActivator), nameof(UnityWebApiActivator.Start))]
//[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(UnityWebApiActivator), nameof(UnityWebApiActivator.Shutdown))]

//namespace Pki.eBusiness.ErpApi.Web
//{
//    /// <summary>
//    /// Provides the bootstrapping for integrating Unity with WebApi when it is hosted in ASP.NET.
//    /// </summary>
//    public static class UnityWebApiActivator
//    {
//        /// <summary>
//        /// Integrates Unity when the application starts.
//        /// </summary>
//        public static void Start() 
//        {
//            // Use UnityHierarchicalDependencyResolver if you want to use
//            // a new child container for each IHttpController resolution.
//            // var resolver = new UnityHierarchicalDependencyResolver(UnityConfig.Container);
//            var resolver = new UnityDependencyResolver(UnityConfig.Container());

//            GlobalConfiguration.Configuration.DependencyResolver = resolver;
//        }

//        /// <summary>
//        /// Disposes the Unity container when the application is shut down.
//        /// </summary>
//        public static void Shutdown()
//        {
//            UnityConfig.Container().Dispose();
//        }
//    }
//}