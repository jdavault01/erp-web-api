using System.Collections.Generic;
using System.Data.SqlClient;
using DataAccessLayer;
using Pki.eBusiness.WebApi.Contracts.DAL;
using Pki.eBusiness.WebApi.Entities.Constants;

namespace Pki.eBusiness.WebApi.DataAccess.Database
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
