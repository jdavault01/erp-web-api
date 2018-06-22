using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Net;
using System.Web;
using System.Net;
using System.IO;
using PKI.eBusiness.WMService.Entities.Stubs.StoreFront;

namespace PKI.eBusiness.WMService.ServiceGatewContracts.RestCalls
{
    public interface IWMRestServices
    {
        ContactCreateWebServiceResponse CreateContactRestService(string request);
    }
}
