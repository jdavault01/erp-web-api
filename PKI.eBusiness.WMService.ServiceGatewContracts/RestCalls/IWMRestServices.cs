using PKI.eBusiness.WMService.Entities.Stubs.StoreFront;

namespace PKI.eBusiness.WMService.ServiceGatewContracts.RestCalls
{
    public interface IWMRestServices
    {
        ContactCreateWebServiceResponse CreateContact(string request);
    }
}
