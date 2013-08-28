using System;

namespace RestAPI.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ExplodeAttribute: Attribute
    {
        public string PropertyName { get; set; }

        public ExplodeAttribute(string propertyName)
        {
            PropertyName = propertyName;
        }
    }
}