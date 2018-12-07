using AutoMapper;
using Pki.eBusiness.WebApi.Entities.StoreFront.ProductCatalog;
using PKI.eBusiness.WMSHttpApi.Models;

namespace PKI.eBusiness.WMSHttpApi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, PriceResponseDetail>()
                .ForMember(y => y.AdjustedPrice, z => z.MapFrom(src => src.Price))
                .ForMember(x => x.ProductId, y => y.MapFrom(src => src.PartNumber));
        }
    }
}