using System;
using System.Collections.Generic;

namespace RestAPI.Core.RequestConstructors
{
    public interface IManageContractConstructors
    {
        object ConstructContractFromRouteData(Type contractType, IDictionary<string, object> actionArguments);
    }
}