using System;

namespace RestAPI.Core.Exceptions
{
    public class ActionNotFoundForModel : Exception
    {
        public ActionNotFoundForModel(Type linkResourceType, Type onModelType)
            : base(string.Format("No route found for {0} when generating links on {1}", linkResourceType, onModelType))
        {
        }

        public ActionNotFoundForModel(Type linkResourceType)
            : base(string.Format("No route found for {0}", linkResourceType))
        {
        }

    }
}