using System;
using System.Collections.Generic;
using System.Web.Http.Controllers;

namespace WebAPI.Rest.Bootstrap.Interfaces.ContractConstructor
{
    public interface IManageContractConstructors
    {
        object ConstructContractFromRouteData(Type contractType, HttpActionContext context);
    }
}