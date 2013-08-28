using System;

namespace RestAPI.Core.DataProviders
{
    public interface IManageDataProviders
    {
        void FillModelFromProviders(Type modelType, dynamic model);
    }
    
}