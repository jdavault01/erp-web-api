using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Pki.eBusiness.WebApi.Entities.StoreFront.ProductCatalog;

namespace Pki.eBusiness.WebApi.Entities.StoreFront.DataObjects
{
    [DataContract]
    public class PriceClientResponse
    {
        [DataMember]
        public PriceResponse PriceResponse { get; set; }

        public PriceClientResponse()
        {


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
