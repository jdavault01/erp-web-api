using PKI.eBusiness.WMService.WMServiceLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.Practices.Unity;
using PKI.eBusiness.WMService.BusinessServices;
using PKI.eBusiness.WMService.BusinessServicesContracts;
using PKI.eBusiness.WMService.ServiceGatewaysContracts;
using PKI.eBusiness.WMService.Entities.Stubs;
using PKI.eBusiness.WMService.WMServiceLibraryContracts;
using Moq;

namespace PKI.eBusiness.WMService.WMServiceLibraryTest
{
    
    
    /// <summary>
    ///This is a test class for WMServiceFactoryTest and is intended
    ///to contain all WMServiceFactoryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class WMServiceFactoryTest
    {       
        
        /// <summary>
        ///A test for ConfigureContainer
        ///</summary>
        //[TestMethod()]
        //[DeploymentItem("PKI.eBusiness.WMService.WMServiceLibrary.dll")]
        //public void ConfigureContainerTest()
        //{
        //    WMServiceFactory_Accessor target = new WMServiceFactory_Accessor();

        //    IUnityContainer container = new UnityContainer();
        //    target.ConfigureContainer(container);

        //    bool areRegistered = container.IsRegistered<IWMService>() &&
        //                         container.IsRegistered<IOrderService>() &&
        //                         container.IsRegistered<IWebMethodClient>() &&
        //                         container.IsRegistered<IProcessPiedatirxOrder_PortTypeClient>();

        //    bool expected = true;
        //    bool actual = areRegistered;

        //    Assert.AreEqual<bool>(expected, actual);
        //}        
    }
}
