using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using PKI.eBusiness.WMService.Entities.StoreFront.ProductCatalog;

namespace PKI.eBusiness.WMService.Entities.StoreFront.DataObjects
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
