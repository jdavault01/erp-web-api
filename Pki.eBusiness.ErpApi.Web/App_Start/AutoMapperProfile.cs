using AutoMapper;
using Pki.eBusiness.ErpApi.Entities.ProductCatalog;
using Pki.eBusiness.ErpApi.Web.Models;

namespace Pki.eBusiness.ErpApi.Web
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