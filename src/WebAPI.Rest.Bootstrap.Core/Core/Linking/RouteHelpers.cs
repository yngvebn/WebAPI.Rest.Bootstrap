using System;
using System.Text.RegularExpressions;
using WebAPI.Rest.Bootstrap.Implementations.LinkProviders;

namespace WebAPI.Rest.Bootstrap.Core.Linking
{
    internal static class RouteHelpers
    {
        public static string Link(string relativeUrl, object routeValues, LinkArgumentStyle linkArgumentStyle)
        {

            relativeUrl = PopulateRelativeUrl(relativeUrl.ToLower(), routeValues, linkArgumentStyle);

            return relativeUrl;
        }


        private static string PopulateRelativeUrl(string relativeUrl, object routeValues, LinkArgumentStyle linkArgumentStyle)
        {
            string regexPattern = "{{{0}.*?}}";
            foreach (var property in routeValues.GetType().GetProperties())
            {
                var propertyValue = property.GetValue(routeValues, null);
                if(propertyValue != null)
                    relativeUrl = Regex.Replace(relativeUrl, string.Format(regexPattern, property.Name), propertyValue.ToString(), RegexOptions.IgnoreCase);
            }
            foreach(Match match in Regex.Matches(relativeUrl, @"\{(?<name>(.+))\}"))
            {
                string argument = CreateArgumentStyle(match.Groups["name"].Value, linkArgumentStyle);
                relativeUrl = relativeUrl.Replace(match.Value, argument);
            }
            return relativeUrl;
        }

        private static string CreateArgumentStyle(string value, LinkArgumentStyle linkArgumentStyle)
        {
            switch (linkArgumentStyle)
            {
                case LinkArgumentStyle.Normal:
                    return string.Format("{{{0}}}", value);
                    break;
                case LinkArgumentStyle.Angular:
                    return string.Format(":{0}", value);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("linkArgumentStyle");
            }
        }
    }
}