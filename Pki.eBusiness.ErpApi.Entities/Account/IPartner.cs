namespace Pki.eBusiness.ErpApi.Entities.Account
{
    public interface IPartner
    {
        PartnerType PartnerType { get; set; }
        string PartnerId { get; set; }
    }

    public enum PartnerType
    {
        Hierarchy = 0,
        ShipTo = 1,
        BillTo = 2,
        SoldTo = 3,
        ContactID = 4
    }
}
