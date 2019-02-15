namespace Pki.eBusiness.ErpApi.Entities.Orders
{    
    /// <summary>
    /// Order Request Detail
    /// </summary>
    
    public class OrderRequestDetail : EntityBase
    {
        
        public string OrderItemID { get; set; }
        
        public string OrderItemSequence { get; set; }
        
        public string ItemID { get; set; }
        
        public string ItemPrice { get; set; }
        
        public string FilterPaperNumber { get; set; }
        
        public string OrigFilterPaperNumber { get; set; }
        
        public string GiftWrapMessage { get; set; }
        
        public string Qty { get; set; }


    }
}
