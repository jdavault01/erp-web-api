using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PKI.eBusiness.WMService.Entities.StoreFront.Account;
using PKI.eBusiness.WMService.Entities.StoreFront.DataObjects;
using PKI.eBusiness.WMService.Entities.StoreFront.Orders;

namespace PKI.eBusiness.WMService.BusinessServicesContracts.StoreFront
{
    public interface ICartService
    {
        CartInfo GetClearanceCode(CartInfo cartInfo);
    }
}
