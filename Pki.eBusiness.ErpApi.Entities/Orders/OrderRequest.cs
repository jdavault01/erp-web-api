namespace Pki.eBusiness.ErpApi.Entities.Orders
{    
    /// <summary>
    /// Order Request Class
    /// </summary>
    
    public class OrderRequest : EntityBase
    {
        #region Private variables

        
        public OrderRequestHeader OrderRequestHeader { get; set; }
        
        public OrderRequestDetail[] OrderRequestDetail { get; set; }

        #endregion // Private variables
    }
}
