using System;
using Pki.eBusiness.ErpApi.Entities.DataObjects;

namespace Pki.eBusiness.ErpApi.Contract.BL
{
    public interface IAccountService
    {
        //Will decommision this call once Cartproject is live
        //PartnerResponse GetPartnerInfo(PartnerRequest partnerRequest);
        //New simpler request
        PartnerResponse GetPartnerDetails(SimplePartnerRequest request);
        ContactCreateResponse CreateContact(ContactCreateRequest request);
        LoginInfo GetLoginInfo(String companyCode);
        PartnerResponse PartnerLookup(SimplePartnerRequest request);
    }
}
