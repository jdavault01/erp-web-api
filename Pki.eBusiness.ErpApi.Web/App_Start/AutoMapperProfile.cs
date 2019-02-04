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
                .ForMember(y => y.AdjustedPrice, z => z.MapFrom(src => src.Price))
                .ForMember(x => x.ProductId, y => y.MapFrom(src => src.PartNumber));
        }
    }
}