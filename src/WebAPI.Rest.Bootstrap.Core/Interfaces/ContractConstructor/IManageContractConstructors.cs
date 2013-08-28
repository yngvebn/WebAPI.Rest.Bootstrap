using System;
using System.Collections.Generic;

namespace WebAPI.Rest.Bootstrap.Interfaces.ContractConstructor
{
    public interface IManageContractConstructors
    {
        object ConstructContractFromRouteData(Type contractType, IDictionary<string, object> actionArguments);
    }
}