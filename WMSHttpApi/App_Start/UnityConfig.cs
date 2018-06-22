﻿using Unity;
using Unity.RegistrationByConvention;
using System.Linq;

namespace PKI.eBusiness.WMSHttpApi
{
    public static class UnityConfig
    {
        public static UnityContainer Container()
        {
            var types = PKIAllClasses.FromAssembliesInBasePath().Where(c => c.FullName.StartsWith("PKI.eBusiness") && !c.Name.EndsWith("Controller")).OrderBy(i => i.Name);
            var container = new UnityContainer();
            container.RegisterTypes(
                types,
                WithMappings.FromMatchingInterface,
                WithName.Default,
                WithLifetime.Transient);


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