using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;
using WebAPI.Rest.Bootstrap.Core.Attributes;
using WebAPI.Rest.Bootstrap.Core.Exceptions;
using WebAPI.Rest.Bootstrap.Interfaces.ContractConstructor;
using WebAPI.Rest.Bootstrap.Interfaces.DataProvider;
using WebAPI.Rest.Bootstrap.Interfaces.LinkProvider;
using WebAPI.Rest.Bootstrap.Interfaces.Mapping;

namespace WebAPI.Rest.Bootstrap.Core.ActionFilters
{
    public class StrapRequestModel: ActionFilterAttribute
    {
        private readonly ILinkGenerator _linkGenerator;
        private readonly IMapper _mapper;
        private readonly IManageContractConstructors _contractConstructors;
        private readonly IPopulateLinksForModel _linkProviders;
        private readonly IManageDataProviders _dataProviders;
        private readonly HttpConfiguration _configuration;

        public StrapRequestModel(ILinkGenerator linkGenerator, IMapper mapper, IManageContractConstructors contractConstructors, IPopulateLinksForModel linkProviders, IManageDataProviders dataProviders, HttpConfiguration configuration)
        {
            _linkGenerator = linkGenerator;
            _mapper = mapper;
            _contractConstructors = contractConstructors;
            _linkProviders = linkProviders;
            _dataProviders = dataProviders;
            _configuration = configuration;
        }

        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
 

        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var returnType = actionExecutedContext.ActionContext.ActionDescriptor.ReturnType;
            var innerType = returnType.GetGenericArguments().First();
            var destinationMap = AutoMapper.Mapper.GetAllTypeMaps().SingleOrDefault(map => map.DestinationType == innerType);
            if(destinationMap == null)
            {
                throw new ResponseMapNotFoundException(string.Format("No map was found to map a contract to {0}", innerType), innerType);
            }


            var contract = _contractConstructors.ConstructContractFromRouteData(destinationMap.SourceType, actionExecutedContext.ActionContext.ActionArguments);

            _dataProviders.FillModelFromProviders(contract.GetType(), contract);
            
            var response = _mapper.Map(contract, contract.GetType(), innerType);
            _linkProviders.Populate(response.GetType(), response);

            response = Explode(response);
            actionExecutedContext.Response.Content = new ObjectContent(response.GetType(), response, _configuration.Formatters.JsonFormatter);
        }

        private object Explode(object response)
        {
            var explodeAttribute = response.GetType().GetCustomAttributes(typeof (ExplodeAttribute), true).Cast<ExplodeAttribute>().SingleOrDefault();
            if (explodeAttribute == null) return response;

            var property = response.GetType().GetProperties().SingleOrDefault(prop => prop.Name.Equals(explodeAttribute.PropertyName, StringComparison.InvariantCultureIgnoreCase));
            if(property == null) throw new MissingMemberException(string.Format("Could not find property {0} to explode on {1}", explodeAttribute.PropertyName, response.GetType()));

            return property.GetValue(response, null);
        }
    }
}