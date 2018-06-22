using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PKI.eBusiness.WMService.Entities.Orders;

namespace PKI.eBusiness.WMService.BusinessServicesContracts
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
