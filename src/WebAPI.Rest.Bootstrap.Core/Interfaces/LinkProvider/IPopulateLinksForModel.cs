using System;
using WebAPI.Rest.Bootstrap.Implementations.LinkProviders;

namespace WebAPI.Rest.Bootstrap.Interfaces.LinkProvider
{
    public interface IPopulateLinksForModel
    {
        void Populate(Type modelType, object model, LinkArgumentStyle linkArgumentStyle);
    }
    
}