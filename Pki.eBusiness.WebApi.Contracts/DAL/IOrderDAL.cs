namespace Pki.eBusiness.WebApi.Contracts.DAL
{
   public interface IOrderDAL
    {
       void UpdateOrderStatus(string orderNumber, int statusCode);
    }
}
