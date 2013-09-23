using System;
using System.Collections.Generic;
using System.Web.Http.Controllers;
using WebAPI.Rest.Bootstrap.Interfaces.ContractConstructor;

namespace WebAPI.Rest.Bootstrap.Implementations.RequestConstructors
{
    public class MarkerClass: IConstructContractFrom<object>
    {
        public object Construct(IDictionary<string, object> actionArguments, HttpActionContext context)
        {
            throw new NotImplementedException("Should never be used");
        }
    }
}
