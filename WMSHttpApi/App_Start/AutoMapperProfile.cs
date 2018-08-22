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
                .ForMember(dest => dest.AdjustedPrice, opt => opt.MapFrom(src => src.Price.ToString("N")))
                .ForMember(x => x.ProductId, y => y.MapFrom(src => src.PartNumber));
        }
    }
}