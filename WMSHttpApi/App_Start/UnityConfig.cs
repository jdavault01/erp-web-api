using Unity;
using Unity.RegistrationByConvention;
using System.Linq;
using Pki.eBusiness.WebApi.DataAccess.ErpApi.Api;
using Unity.Registration;
using Unity.Injection;
using Pki.eBusiness.WebApi.DataAccess.ErpApi.Client;

namespace PKI.eBusiness.WMSHttpApi
{
    public static class UnityConfig
    {
        public static UnityContainer Container()
        {
            var types = PKIAllClasses.FromAssembliesInBasePath().Where(c => c.FullName.StartsWith("Pki.eBusiness") && !c.Name.EndsWith("Controller")).OrderBy(i => i.Name);
            var container = new UnityContainer();
            container.RegisterTypes(
                types,
                WithMappings.FromMatchingInterface,
                WithName.Default,
                WithLifetime.Transient);
            container.RegisterType<IErpApi, ErpApi>(new InjectionConstructor(new Configuration
            {
                Username = "eCommerce@perkinelmer-S1LB6Y",
                Password = "129ccfec-af1e-4ea0-bee7-3021367a9e23"
            }));

            //var address = ConfigurationManager.AppSettings[Constants.STOREFRONT_STUB_ADDRESS];
            //var addressName = ConfigurationManager.AppSettings[Constants.STOREFRONT_STUB_NAME];
            //container.RegisterType<StorefrontWebServices_PortType, StorefrontWebServices_PortTypeClient>
            //        (new InjectionConstructor(addressName, address));

            //address = ConfigurationManager.AppSettings[Constants.GENETICS_STUB_ENDPOINT];
            //addressName = ConfigurationManager.AppSettings[Constants.GENETICS_STUB_NAME];
            //container.RegisterType<ProcessPediatrixOrder_WSD_PortType, ProcessPediatrixOrder_WSD_PortTypeClient>
            //        (new InjectionConstructor(addressName, address));

            //address = ConfigurationManager.AppSettings[Constants.SHOP_SVC_ENDPOINT];
            //addressName = ConfigurationManager.AppSettings[Constants.SHOP_SVC_NAME];
            //container.RegisterType<IShopCommerceService, ShopCommerceServiceClient>
            //        (new InjectionConstructor(addressName, address));

            return container;
        }
    }
}