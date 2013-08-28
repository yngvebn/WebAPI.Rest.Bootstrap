using System;
using System.Collections.Generic;
using System.Linq;

namespace RestAPI.Core.RequestConstructors
{
    public class ManageContractConstructors : IManageContractConstructors
    {
        private readonly IEnumerable<IConstructContractFrom> _dataProviders;

        public ManageContractConstructors(IEnumerable<IConstructContractFrom> dataProviders)
        {
            _dataProviders = dataProviders;
        }

        public object ConstructContractFromRouteData(Type contractType, IDictionary<string, object> actionArguments)
        {
            dynamic dataProvider = _dataProviders.SingleOrDefault(c => typeof(IConstructContractFrom<>).MakeGenericType(contractType).IsInstanceOfType(c));
            if(dataProvider == null)
            {
                return Activator.CreateInstance(contractType);
            }
            return dataProvider.Construct(actionArguments);
        }
    }
}