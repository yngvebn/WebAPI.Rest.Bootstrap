using WebAPI.Rest.Bootstrap.Contracts;
using WebAPI.Rest.Bootstrap.Interfaces.Mapping;
using WebAPI.Rest.Bootstrap.Web.Models;

namespace WebAPI.Rest.Bootstrap.Web.Mappings
{
    public class ProductMapping: IMappingConfiguration
    {
        public void Configure()
        {
            AutoMapper.Mapper.CreateMap<Products, ProductsResponse>()
                .ForMember(p => p.Products, opt => opt.MapFrom(s => s.AllProducts));
            AutoMapper.Mapper.CreateMap<Product, ProductResponse>();
        }
    }
}