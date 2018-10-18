using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pki.eBusiness.WebApi.Entities.StoreFront.Account
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
