using Pki.eBusiness.ErpApi.Entities.DataObjects;

namespace Pki.eBusiness.ErpApi.Contract.BL
{
    public interface ICompanyService
    {
        CompanyContactsResponse GetCompanyContacts(CompanyContactsRequest companyContactRequest);
        CompanyAddressesResponse GetCompanyAddresses(CompanyAddressesRequest companyAddressesRequest);
        CompanyInfoResponse GetCompanyName(CompanyInfoRequest companyInfoRequest);


    }
}
