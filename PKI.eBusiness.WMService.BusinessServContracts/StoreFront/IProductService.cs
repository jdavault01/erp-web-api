using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using PKI.eBusiness.WMService.Entities.StoreFront.DataObjects;
using PKI.eBusiness.WMService.Entities.StoreFront.DataObjects;

namespace PKI.eBusiness.WMService.BusinessServicesContracts.StoreFront
{
    public interface IProductService
    {
        PriceResponse GetPrice(PriceRequest priceRequest);
        InventoryResponse GetInventory(InventoryRequest priceRequest);

    }
}
