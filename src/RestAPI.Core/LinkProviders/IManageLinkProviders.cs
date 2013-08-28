using System;

namespace RestAPI.Core.LinkProviders
{
    public interface IManageLinkProviders
    {
        void PopulateLinksForModel(Type modelType, object model);
    }
    
}