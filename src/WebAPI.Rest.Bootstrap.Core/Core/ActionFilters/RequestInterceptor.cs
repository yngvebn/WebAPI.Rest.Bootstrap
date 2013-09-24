using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;
using WebAPI.Rest.Bootstrap.Core.Attributes;
using WebAPI.Rest.Bootstrap.Core.Commands;
using WebAPI.Rest.Bootstrap.Core.Exceptions;
using WebAPI.Rest.Bootstrap.Core.Models;
using WebAPI.Rest.Bootstrap.Interfaces.ContractConstructor;
using WebAPI.Rest.Bootstrap.Interfaces.DataProvider;
using WebAPI.Rest.Bootstrap.Interfaces.LinkProvider;
using WebAPI.Rest.Bootstrap.Interfaces.Mapping;

namespace WebAPI.Rest.Bootstrap.Core.ActionFilters
{
    public class RequestInterceptor : ActionFilterAttribute
    {
        private readonly IMapper _mapper;
        private readonly IManageContractConstructors _contractConstructors;
        private readonly IPopulateLinksForModel _linkPopulator;
        private readonly ICommandExecutor _commandExecutor;
        private readonly IManageDataProviders _dataProviders;
        private readonly HttpConfiguration _configuration;

        public RequestInterceptor(IMapper mapper, IManageContractConstructors contractConstructors, IPopulateLinksForModel linkPopulator, ICommandExecutor commandExecutor, IManageDataProviders dataProviders, HttpConfiguration configuration)
        {
            _mapper = mapper;
            _contractConstructors = contractConstructors;
            _linkPopulator = linkPopulator;
            _commandExecutor = commandExecutor;
            _dataProviders = dataProviders;
            _configuration = configuration;
        }

        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {


        }

        public AutoMapper.TypeMap GetMapThatMapsFrom(Type sourceType)
        {
            return AutoMapper.Mapper.GetAllTypeMaps().SingleOrDefault(map => map.SourceType == sourceType);
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Request.Method == HttpMethod.Put || actionExecutedContext.Request.Method == HttpMethod.Post)
            {
                var arguments = actionExecutedContext.ActionContext.ActionArguments;
                object requestObject = FindObjects(arguments, false).SingleOrDefault().Value;
                var extraArguments = FindObjects(arguments, true);

                var returnType = actionExecutedContext.ActionContext.ActionDescriptor.ReturnType;
                var innerType = returnType.GetGenericArguments().First();

                var commandMap = GetMapThatMapsFrom(requestObject.GetType());
                var commandType = commandMap.DestinationType;
                var command = Activator.CreateInstance(commandType);
                AutoMapper.Mapper.Map(requestObject, command, requestObject.GetType(), commandType);
                command.TryToSetPropertiesFromDictionary(extraArguments);
                var result = _commandExecutor.ExecuteCommand(command);
                if(result.Status == CommandStatus.Executed)
                {
                    var destinationMap = AutoMapper.Mapper.GetAllTypeMaps().SingleOrDefault(map => map.DestinationType == innerType);
                    var returnObject = Activator.CreateInstance(innerType);
                    AutoMapper.Mapper.Map(result.Data, returnObject, destinationMap.SourceType, destinationMap.DestinationType);
                    _linkPopulator.Populate(innerType, returnObject);
                    actionExecutedContext.Response.Content = new ObjectContent(typeof(BaseApiResponse), returnObject as BaseApiResponse, _configuration.Formatters.JsonFormatter);
                }
                if(result.Status != CommandStatus.Executed)
                {
                    actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                        {
                            Content = new StringContent(result.Message)
                        };
                }

            }
            if (actionExecutedContext.Request.Method == HttpMethod.Get)
            {
                var returnType = actionExecutedContext.ActionContext.ActionDescriptor.ReturnType;
                var innerType = returnType.GetGenericArguments().First();
                var destinationMap = AutoMapper.Mapper.GetAllTypeMaps().SingleOrDefault(map => map.DestinationType == innerType);


                if (destinationMap == null)
                {
                    if (!Configuration.RequiresContractMapping)
                    {
                        AutoMapper.Mapper.CreateMap(innerType, innerType);
                        destinationMap = AutoMapper.Mapper.GetAllTypeMaps().SingleOrDefault(map => map.DestinationType == innerType);
                    }
                    else
                    {
                        throw new ResponseMapNotFoundException(
                         string.Format("No map was found to map a contract to {0}", innerType), innerType);
                    }
                }



                var contract = _contractConstructors.ConstructContractFromRouteData(destinationMap.SourceType, actionExecutedContext.ActionContext);

                _dataProviders.FillModelFromProviders(contract.GetType(), contract);

                var response = _mapper.Map(contract, contract.GetType(), innerType);
                _linkPopulator.Populate(response.GetType(), response);

                response = Explode(response);
                actionExecutedContext.Response.Content = new ObjectContent(response.GetType(), response, _configuration.Formatters.JsonFormatter);
            }
        }

        private Dictionary<string, object> FindObjects(Dictionary<string, object> arguments, bool isSystemType)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            foreach(var key in arguments.Keys)
            {
                
                if (arguments[key].GetType().Namespace.StartsWith("System") && isSystemType)
                {
                    dict.Add(key, arguments[key]);

                }
                if(!arguments[key].GetType().Namespace.StartsWith("System") && !isSystemType)
                {
                    dict.Add(key, arguments[key]);
                }
            }
            return dict;
        }

        private object Explode(object response)
        {
            var explodeAttribute = response.GetType().GetCustomAttributes(typeof(ExplodeAttribute), true).Cast<ExplodeAttribute>().SingleOrDefault();
            if (explodeAttribute == null) return response;

            var property = response.GetType().GetProperties().SingleOrDefault(prop => prop.Name.Equals(explodeAttribute.PropertyName, StringComparison.InvariantCultureIgnoreCase));
            if (property == null) throw new MissingMemberException(string.Format("Could not find property {0} to explode on {1}", explodeAttribute.PropertyName, response.GetType()));

            return property.GetValue(response, null);
        }
    }
}