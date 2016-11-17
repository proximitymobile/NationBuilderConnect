using System;
using System.Net;
using System.Reflection;

namespace NationBuilderConnect.Client.Utilities.Extensions
{
    public static class GeneralExtensions
    {
        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static bool IsSuccess(this HttpStatusCode statusCode)
        {
            return ((int) statusCode >= 200) && ((int) statusCode <= 299);
        }

        public static DateTime AsUnixTimeToDateTime(this long unixTime)
        {
            return Epoch.AddSeconds(unixTime);
        }

        public static TAttribute GetAttribute<TAttribute>(this MemberInfo property) where TAttribute : Attribute
        {
#if NET40
            return Attribute.GetCustomAttribute(property, typeof(TAttribute)) as TAttribute;
#else
            return property.GetCustomAttribute<TAttribute>();
#endif
        }
    }
}