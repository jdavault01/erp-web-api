using System;
using System.Collections.Generic;
using Pki.eBusiness.ErpApi.Entities.ProductCatalog;

namespace Pki.eBusiness.ErpApi.Entities.DataObjects
{
    
    public class PriceClientResponse
    {
        
        public PriceResponse PriceResponse { get; set; }

        public PriceClientResponse()
        {


        }
    }


    
    public class PriceResponse
    {

        
        public String ErrorMessage { get; set; }

        
        public List<Product> Products { get; set; }

        
        public List<FailedProduct> FailedProducts { get; set; }

    }
}
