using System.Collections.Generic;

namespace RestAPI.Core.RequestConstructors
{
    public interface IConstructContractFrom
    {

    }

    public interface IConstructContractFrom<T> : IConstructContractFrom
    {
        T Construct(IDictionary<string, object> actionArguments);
    }
}