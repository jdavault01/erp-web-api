using Pki.eBusiness.ErpApi.Entities.DataObjects;
using Pki.eBusiness.ErpApi.Entities.Orders;

namespace Pki.eBusiness.ErpApi.Contract.DAL
{
    public interface IERPRestGateway
    {
        SimulateOrderErpResponse SimulateOrder(SimulateOrderErpRequest request);
        PartnerResponse PartnerLookup(SimplePartnerRequest request);
        CompanyContactsResponse GetCompanyContacts(CompanyContactsRequest companyContactRequest);
        CompanyAddressesResponse GetCompanyAddresses(CompanyAddressesRequest companyAddressesRequest);
        CompanyInfoResponse GetCompanyInfo(CompanyInfoRequest companyInfoRequest);
        ContactCreateClientResponse CreateContact(ContactCreateClientRequest payLoad);
        ShippingNotificationResponse SendShippingNotifications(ShippingNotification shippingNotificationDto);
    }
}