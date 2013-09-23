using System.Collections.Generic;
using System.Web.Http.Controllers;

namespace WebAPI.Rest.Bootstrap.Interfaces.ContractConstructor
{
    public interface IConstructContractFrom
    {

    }

    public interface IConstructContractFrom<T> : IConstructContractFrom
    {
        T Construct(IDictionary<string, object> actionArguments, HttpActionContext context);
    }
}