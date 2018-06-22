using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityConfiguration;
using PKI.eBusiness.WMService.Entities.Orders;
using PKI.eBusiness.WMService.BusinessServices;
using PKI.eBusiness.WMService.BusinessServicesContracts;
using PKI.eBusiness.WMService.Entities.Stubs;
using Microsoft.Practices.Unity;
using Unity.Wcf;

namespace PKI.eBusiness.WMService.WMServiceLibrary
{
    public class WMRegistry : UnityRegistry
    {
        // Scan one or several assemblies and auto register types based on a 
        // convention. You can also include or exclude certain types and/or 
        // namespaces using a filter.

        public WMRegistry()
        {
            Scan(scan =>
                {
                    scan.AssembliesInBaseDirectory();
                    scan.ForRegistries();
                    scan.With<FirstInterfaceConvention>();

                    scan.With<AddAllConvention>().TypesImplementing(typeof (IServiceBase<>));


                });

            Register(typeof(IServiceBase<>), typeof(ServiceBase<>));
          
        }
    }
}
