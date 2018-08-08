using PKI.eBusiness.WMService.Entities.Stubs.StoreFront;

namespace PKI.eBusiness.WMService.ServiceGatewContracts
{
    public interface IERPRestGateway
    {
        ContactCreateWebServiceResponse CreateContact(string payLoad, string resourceName);
    }
}
