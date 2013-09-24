using WebAPI.Rest.Bootstrap.Interfaces.Mapping;
using WebAPI.Rest.Bootstrap.Web.Commands;
using WebAPI.Rest.Bootstrap.Web.Controllers;

namespace WebAPI.Rest.Bootstrap.Web.Mappings.Commands
{
    public class MapToUpdateProductCommand: IMappingConfiguration
    {
        public void Configure()
        {
            AutoMapper.Mapper.CreateMap<UpdateProductRequest, UpdateProductCommand>();
        }
    }
}