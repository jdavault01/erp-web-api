using Pki.eBusiness.WebApi.Entities.Orders;

namespace Pki.eBusiness.WebApi.Contracts.BL.Genetics
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
