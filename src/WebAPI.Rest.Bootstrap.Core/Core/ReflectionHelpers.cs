using System;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI.Rest.Bootstrap.Core
{
    public static class ReflectionHelpers
    {

        public static void TryToSetPropertiesFromDictionary(this object instance, Dictionary<string, object> dict)
        {
            foreach (var property in instance.GetType().GetProperties())
            {
                if (dict.Any(pair => pair.Key.Equals(property.Name, StringComparison.InvariantCultureIgnoreCase)))
                {
                    var arg = dict.SingleOrDefault(pair => pair.Key.Equals(property.Name, StringComparison.InvariantCultureIgnoreCase));
                    property.SetValue(instance, arg.Value, null);
                }
            }
        }
    }
}