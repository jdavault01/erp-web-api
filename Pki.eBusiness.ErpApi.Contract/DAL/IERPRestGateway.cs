using Pki.eBusiness.ErpApi.Entities.Account;
using Pki.eBusiness.ErpApi.Entities.DataObjects;
using Pki.eBusiness.ErpApi.Entities.Orders;

namespace Pki.eBusiness.ErpApi.Contract.DAL
{
    public interface IERPRestGateway
    {
        SimulateOrderErpResponse SimulateOrder(SimulateOrderErpRequest request);
        Partner GetShipToAddress(SimplePartnerRequest request);
        Partner GetBillToAddress(SimplePartnerRequest request);
        PartnerResponse SimplePartnerLookup(SimplePartnerRequest request);
        CompanyContactsResponse CompanyContacts(CompanyContactsRequest companyContactRequest);
        CompanyAddressesResponse CompanyAddresses(CompanyAddressesRequest companyAddressesRequest);
        CompanyInfoResponse CompanyInfo(CompanyInfoRequest companyInfoRequest);
        ContactCreateClientResponse CreateContact(ContactCreateClientRequest payLoad);
        ShippingNotificationResponse SendShippingNotifications(ShippingNotification shippingNotificationDto);
    }
}