using System;

namespace WebAPI.Rest.Bootstrap.Interfaces.DataProvider
{
    public interface IManageDataProviders
    {
        void FillModelFromProviders(Type modelType, dynamic model);
    }
    
}