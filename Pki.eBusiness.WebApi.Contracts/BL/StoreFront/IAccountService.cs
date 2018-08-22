using System;
using Pki.eBusiness.WebApi.Entities.StoreFront.DataObjects;

namespace Pki.eBusiness.WebApi.Contracts.BL.StoreFront
{
    public interface IAccountService
    {
        //Will decommision this call once Cartproject is live
        PartnerResponse GetPartnerInfo(PartnerRequest partnerRequest);
        //New simpler request
        PartnerResponse GetPartnerDetails(SimplePartnerRequest partnerRequest);
        ContactCreateResponse CreateContact(String accountNumber, ContactCreateRequest partnerRequest);
        LoginInfo GetLoginInfo(String companyCode);
    }
}
