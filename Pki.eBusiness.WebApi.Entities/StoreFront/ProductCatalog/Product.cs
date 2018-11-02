using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Pki.eBusiness.WebApi.Entities.StoreFront.ProductCatalog
{

    [DataContract]
    public class Product
    {
        [JsonProperty(PropertyName = "ProductId")]
        [DataMember]
        public string PartNumber { get; set; }

        [DataMember]
        public string Currency { get; set; }

        [DataMember]
        public decimal Price { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Category { get; set; }

    }

    [DataContract]
    public class FailedProduct : Product
    {
        [DataMember]
        public string ErrorMessage { get; set; }
    }
}
