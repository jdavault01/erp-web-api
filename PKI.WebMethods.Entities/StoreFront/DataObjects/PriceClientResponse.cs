using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using PKI.eBusiness.WMService.Entities.StoreFront.ProductCatalog;
using WebMethodsPriceResponse = PKI.eBusiness.WMService.Entities.Stubs.StoreFront.PriceWebServiceResponse1;

namespace PKI.eBusiness.WMService.Entities.StoreFront.DataObjects
{
    [DataContract]
    public class PriceClientResponse
    {
        [DataMember]
        public PriceResponse PriceResponse { get; set; }

        public PriceClientResponse(WebMethodsPriceResponse response)
        {
            this.PriceResponse = new PriceResponse { Products = new List<Product>() };
            foreach (var product in response.ProductList)
            {
                var p = new Product
                {
                    PartNumber = product.ProductID,
                    Price = Convert.ToDecimal(product.Price, CultureInfo.InvariantCulture),
                    Currency = product.Currency
                };
                PriceResponse.Products.Add(p);
            }

        }
    }


    [DataContract]
    public class PriceResponse
    {

        [DataMember]
        public String ErrorMessage { get; set; }

        [DataMember]
        public List<Product> Products { get; set; }

        [DataMember]
        public List<FailedProduct> FailedProducts { get; set; }

    }
}
