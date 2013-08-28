using System.Text.RegularExpressions;

namespace RestAPI.Core
{
    public static class RouteHelpers
    {
        public static string Link(string relativeUrl, object routeValues)
        {

            relativeUrl = PopulateRelativeUrl(relativeUrl.ToLower(), routeValues);

            return relativeUrl;
        }


        private static string PopulateRelativeUrl(string relativeUrl, object routeValues)
        {
            string regexPattern = "{{{0}.*?}}";
            foreach (var property in routeValues.GetType().GetProperties())
            {
                var propertyValue = property.GetValue(routeValues, null);
                if(propertyValue != null)
                    relativeUrl = Regex.Replace(relativeUrl, string.Format(regexPattern, property.Name), propertyValue.ToString(), RegexOptions.IgnoreCase);
            }
            return relativeUrl;
        }
    }
}