using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Data.SqlClient;
using PKI.eBusiness.WMService.Utility;


namespace PKI.eBusiness.WMService.DAL
{
    public class OrderDAL: IOrderDAL
    {
        DatabaseManager _manager;

        public OrderDAL()
        {
            _manager = new DatabaseManager();
        }
        public void UpdateOrderStatus(string orderNumber, int statusCode)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@order_number",orderNumber));
            parameters.Add(new SqlParameter("@intStatus",statusCode));
            _manager.ExecuteNonQuery(Constants.SP_UPDATE_ORDER_STATUS, parameters);
        }
    }
}
