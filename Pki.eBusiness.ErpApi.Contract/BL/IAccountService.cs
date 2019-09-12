using System;
using Pki.eBusiness.ErpApi.Entities.Account;
using Pki.eBusiness.ErpApi.Entities.DataObjects;

namespace Pki.eBusiness.ErpApi.Contract.BL
{
    public interface IAccountService
    {
        PartnerResponse GetPartnerDetails(SimplePartnerRequest request);
        ContactCreateClientResponse CreateContact(ContactCreateClientRequest request);
        PartnerResponse PartnerLookup(SimplePartnerRequest request);
        Partner GetShipToAddress(SimplePartnerRequest request);
        Partner GetBillToAddress(SimplePartnerRequest request);
    }
}
