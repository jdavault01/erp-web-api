using Microsoft.Practices.Unity;
using PKI.eBusiness.WMService.Entities.Stubs.StoreFront;
using Unity.Wcf;
using UnityConfiguration;
using PKI.eBusiness.WMService.Entities.Orders;
using PKI.eBusiness.WMService.BusinessServices;
using PKI.eBusiness.WMService.BusinessServicesContracts;
using PKI.eBusiness.WMService.Entities.Stubs;
using PKI.eBusiness.WMService.ServiceGatewContracts.WMService;
using System.ServiceModel.Configuration;
using System.Configuration;
using PKI.eBusiness.WMService.Utility;

namespace PKI.eBusiness.WMService.WMServiceLibrary
{
    /// <summary>
    /// Puts all registration of types into the Unity container
    /// </summary>
	public class WMServiceFactory : UnityServiceHostFactory
    {
        private const string SERVICEMODEL_CLIENT_SECTION_PATH = "system.serviceModel/client";

        protected override void ConfigureContainer(IUnityContainer container)
        {
            container.Configure(x =>
            {
                x.AddRegistry<WMRegistry>();

            });

            // Automagically find all client endpoints defined in config file
            ClientSection clientSection = ConfigurationManager.GetSection(SERVICEMODEL_CLIENT_SECTION_PATH) as ClientSection;
            ChannelEndpointElementCollection endpointCollection = clientSection.Endpoints;

            //string address;
            //for (int i = 0; i < clientSection.Endpoints.Count; i++)
            foreach(ChannelEndpointElement element in clientSection.Endpoints)
            {
                if (element.Name.Equals(Constants.PEDIATRIX_ENDPOINT_NAME))
                    container.RegisterType<ProcessPediatrixOrder_WSD_PortType, ProcessPediatrixOrder_WSD_PortTypeClient>
                        (new InjectionConstructor(element.Name.ToString(), element.Address.ToString()));

                if (element.Name.Equals(Constants.STORE_FRONT_ENDPOINT_NAME))
                    container.RegisterType<StorefrontWebServices_PortType, StorefrontWebServices_PortTypeClient>
                        (new InjectionConstructor(element.Name.ToString(), element.Address.ToString()));
              
            }
        }
    }    
}