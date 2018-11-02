using System;
using Pki.eBusiness.WebApi.Entities.StoreFront.DataObjects;

namespace Pki.eBusiness.WebApi.Contracts.BL.StoreFront
{
    public interface IAccountService
    {
        //Will decommision this call once Cartproject is live
        //PartnerResponse GetPartnerInfo(PartnerRequest partnerRequest);
        //New simpler request
        PartnerResponse GetPartnerDetails(SimplePartnerRequest request);
        ContactCreateResponse CreateContact(String accountNumber, ContactCreateRequest request);
        LoginInfo GetLoginInfo(String companyCode);
        PartnerResponse PartnerLookup(SimplePartnerRequest request);
    }
}
