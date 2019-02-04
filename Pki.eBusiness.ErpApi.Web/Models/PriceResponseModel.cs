using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Pki.eBusiness.ErpApi.Entities.DataObjects;
using Pki.eBusiness.ErpApi.Entities.ProductCatalog;

namespace Pki.eBusiness.ErpApi.Web.Models
{
    public class PriceResponseModel
    {

        public IEnumerable<PriceResponseDetail> Products { get; set; }
        public IEnumerable<FailedProduct> FailedProducts { get; set; }
        public String ErrorMessage { get; set; }

        public PriceResponseModel(PriceResponse priceResponseEntity)
        {
            Products = priceResponseEntity.Products.Select(Mapper.Map<PriceResponseDetail>);
            FailedProducts = priceResponseEntity.FailedProducts;
            ErrorMessage = priceResponseEntity.ErrorMessage;
        }

    }

    public class PriceResponseDetail
    {
        public String ProductId { get; set; }
        public String Currency { get; set; }
        public Decimal AdjustedPrice { get; set; }

    }

}