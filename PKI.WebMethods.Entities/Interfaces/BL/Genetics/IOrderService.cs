using PKI.eBusiness.WMService.Entities.Orders;

namespace PKI.eBusiness.WMService.Entities.Interfaces.BL.Genetics
{
    /// <summary>
    /// Order Service Interface
    /// </summary>
    public interface IOrderService
    {
        OrderSubmissionResponse ProcessSubmision(Order order);
        void Log(string message);
        void UpdateOrderStatus(string orderNumber);
        

    }
}
