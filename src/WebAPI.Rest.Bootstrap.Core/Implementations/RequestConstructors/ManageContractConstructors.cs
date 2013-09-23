using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Controllers;
using WebAPI.Rest.Bootstrap.Interfaces.ContractConstructor;

namespace WebAPI.Rest.Bootstrap.Implementations.RequestConstructors
{
    public class ManageContractConstructors : IManageContractConstructors
    {
        private readonly IEnumerable<IConstructContractFrom> _dataProviders;

        public ManageContractConstructors(IEnumerable<IConstructContractFrom> dataProviders)
        {
            _dataProviders = dataProviders;
        }

        public object ConstructContractFromRouteData(Type contractType, HttpActionContext actionContext)
        {
            dynamic dataProvider = _dataProviders.SingleOrDefault(c => typeof(IConstructContractFrom<>).MakeGenericType(contractType).IsInstanceOfType(c));
            var actionArguments = actionContext.ActionArguments;
            if(dataProvider == null)
            {
                return Activator.CreateInstance(contractType);
            }
            return dataProvider.Construct(actionArguments, actionContext);
        }
    }
}