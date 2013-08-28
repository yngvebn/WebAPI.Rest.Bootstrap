using RestAPI.Contracts;
using RestAPI.Core.Mapping;
using RestAPI.Web.Controllers;
using RestAPI.Web.Models;

namespace RestAPI.Web.Mappings
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