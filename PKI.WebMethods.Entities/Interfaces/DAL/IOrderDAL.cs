namespace PKI.eBusiness.WMService.Entities.Interfaces.DAL
{
   public interface IOrderDAL
    {
       void UpdateOrderStatus(string orderNumber, int statusCode);
    }
}
