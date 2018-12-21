using System.Collections.Generic;

namespace Pki.eBusiness.ErpApi.Entities.DataObjects
{
    
    public class CartInfo
    {
        
        public List<CartInfoItem> CartItems { get; set; }
    }

    
    public class CartInfoItem
    {
        
        public string CartId { get; set; }

        
        public string ItemId { get; set; }

        
        public string ClearanceCode { get; set; }
    }
}
