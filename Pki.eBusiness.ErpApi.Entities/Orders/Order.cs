namespace Pki.eBusiness.ErpApi.Entities.Orders
{    
    /// <summary>
    /// Order Entity Class
    /// </summary>
    
    public class Order : EntityBase
    {
        #region Properties

        
        public OrderRequest OrderRequest { get; set; }
        
        public string CustomerID { get; set; }
        
        public string Version { get; set; }
        
        public string Encoding { get; set; }

        #endregion // Properties
    }
}
