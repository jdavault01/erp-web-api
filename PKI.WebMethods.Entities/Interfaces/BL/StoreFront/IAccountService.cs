using System;
using PKI.eBusiness.WMService.Entities.StoreFront.DataObjects;

namespace PKI.eBusiness.WMService.Entities.Interfaces.BL.StoreFront
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
