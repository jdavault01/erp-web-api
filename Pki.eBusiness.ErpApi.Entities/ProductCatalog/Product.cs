using Newtonsoft.Json;

namespace Pki.eBusiness.ErpApi.Entities.ProductCatalog
{

    
    public class Product
    {
        [JsonProperty(PropertyName = "ProductId")]
        public string PartNumber { get; set; }

        
        public string Currency { get; set; }

        
        public decimal Price { get; set; }

        
        public string Name { get; set; }

        
        public string Category { get; set; }

    }

    
    public class FailedProduct : Product
    {
        
        public string ErrorMessage { get; set; }
    }
}
