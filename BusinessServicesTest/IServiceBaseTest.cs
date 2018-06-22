using PKI.eBusiness.WMService.BusinessServicesContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PKI.eBusiness.WMService.BusinessServicesTest
{
    
    
    /// <summary>
    ///This is a test class for IServiceBaseTest and is intended
    ///to contain all IServiceBaseTest Unit Tests
    ///</summary>
    public class IServiceBaseTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

    }
}
