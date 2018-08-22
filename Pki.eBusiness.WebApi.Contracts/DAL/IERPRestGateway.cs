using Pki.eBusiness.WebApi.Entities.Orders;

namespace Pki.eBusiness.WebApi.Contracts.DAL
{
    public interface IERPRestGateway
    {
        SimulateOrderErpResponse SimulateOrder(SimulateOrderErpRequest request);
    }
}
