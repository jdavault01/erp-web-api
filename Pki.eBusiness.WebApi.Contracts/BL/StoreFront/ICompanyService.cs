using System;
using Pki.eBusiness.WebApi.Entities.StoreFront.DataObjects;


namespace Pki.eBusiness.WebApi.Contracts.BL.StoreFront
{
    public interface ICompanyService
    {
        CompanyContactsResponse GetCompanyContacts(CompanyContactsRequest companyContactRequest);
        CompanyAddressesResponse GetCompanyAddresses(CompanyAddressesRequest companyAddressesRequest);
        CompanyInfoResponse GetCompanyName(CompanyInfoRequest companyInfoRequest);


    }
}
