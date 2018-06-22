using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PKI.eBusiness.WMService.DAL
{
   public interface IOrderDAL
    {
       void UpdateOrderStatus(string orderNumber, int statusCode);
    }
}
