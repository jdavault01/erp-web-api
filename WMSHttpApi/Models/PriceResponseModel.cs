using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using AutoMapper;
using Pki.eBusiness.WebApi.Entities.StoreFront.DataObjects;
using Pki.eBusiness.WebApi.Entities.StoreFront.ProductCatalog;

namespace PKI.eBusiness.WMSHttpApi.Models
{
    public class PriceResponseModel
    {

        public IEnumerable<PriceResponseDetail> Products { get; set; }
        public IEnumerable<FailedProduct> FailedProducts { get; set; }
        public String ErrorMessage { get; set; }

        public PriceResponseModel(PriceResponse priceResponseEntity)
        {
            Mapper.CreateMap<Product, PriceResponseDetail>()
                .ForMember(dest => dest.AdjustedPrice, opt => opt.MapFrom(src => src.Price.ToString("N")))
                    .ForMember(x => x.ProductId, y => y.MapFrom(src => src.PartNumber));

            Products = priceResponseEntity.Products.Select(Mapper.Map<PriceResponseDetail>);
            FailedProducts = priceResponseEntity.FailedProducts;
            ErrorMessage = priceResponseEntity.ErrorMessage;
        }

    }

    public class PriceResponseDetail
    {
        public String ProductId { get; set; }
        public String Currency { get; set; }
        public String AdjustedPrice { get; set; }

    }

}