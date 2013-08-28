using System;

namespace WebAPI.Rest.Bootstrap.Interfaces.LinkProvider
{
    public interface IPopulateLinksForModel
    {
        void Populate(Type modelType, object model);
    }
    
}