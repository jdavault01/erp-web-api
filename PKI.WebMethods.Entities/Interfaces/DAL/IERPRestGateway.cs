using PKI.eBusiness.WMService.Entities.Orders;

namespace PKI.eBusiness.WMService.Entities.Interfaces.DAL
{
    public interface IERPRestGateway
    {
        SimulateOrderErpResponse SimulateOrder(SimulateOrderErpRequest request);
    }
}
