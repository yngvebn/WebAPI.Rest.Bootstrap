using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;
using RestAPI.Core.Attributes;
using RestAPI.Core.DataProviders;
using RestAPI.Core.Exceptions;
using RestAPI.Core.LinkProviders;
using RestAPI.Core.Mapping;
using RestAPI.Core.RequestConstructors;

namespace RestAPI.Core.ActionFilters
{
    public class StrapRequestModel: ActionFilterAttribute
    {
        private readonly IGenerateLinkTo _generateLinkTo;
        private readonly IMapper _mapper;
        private readonly IManageContractConstructors _contractConstructors;
        private readonly IManageLinkProviders _linkProviders;
        private readonly IManageDataProviders _dataProviders;
        private readonly HttpConfiguration _configuration;

        public StrapRequestModel(IGenerateLinkTo generateLinkTo, IMapper mapper, IManageContractConstructors contractConstructors, IManageLinkProviders linkProviders, IManageDataProviders dataProviders, HttpConfiguration configuration)
        {
            _generateLinkTo = generateLinkTo;
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
            _linkProviders.PopulateLinksForModel(response.GetType(), response);

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