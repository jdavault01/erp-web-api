using Pki.eBusiness.WebApi.Entities.Orders;
using Pki.eBusiness.WebApi.Entities.StoreFront.DataObjects;

namespace Pki.eBusiness.WebApi.Contracts.DAL
{
    public interface IERPRestGateway
    {
        SimulateOrderErpResponse SimulateOrder(SimulateOrderErpRequest request);
        PartnerResponse PartnerLookup(SimplePartnerRequest request);

    }
}
