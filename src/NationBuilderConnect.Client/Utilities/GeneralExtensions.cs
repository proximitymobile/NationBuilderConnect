using System;
using System.Net;
using System.Reflection;

namespace NationBuilderConnect.Client.Utilities
{
    /// <summary>
    ///     Helpful extension methods
    /// </summary>
    public static class GeneralExtensions
    {
        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        ///     Whether or not the statusCode represents success
        /// </summary>
        /// <param name="statusCode">The status code</param>
        /// <returns>Whether or not the statusCode represents success</returns>
        public static bool IsSuccess(this HttpStatusCode statusCode)
        {
            return ((int) statusCode >= 200) && ((int) statusCode <= 299);
        }

        /// <summary>
        ///     Converts unix time to DateTime
        /// </summary>
        /// <param name="unixTime">A date in unix time</param>
        /// <returns>The DateTime</returns>
        public static DateTime ConvertUnixTimeToDateTime(this long unixTime)
        {
            return Epoch.AddSeconds(unixTime);
        }

        /// <summary>
        /// Gets an attribute from the given member info
        /// </summary>
        /// <typeparam name="TAttribute">The type of attribute</typeparam>
        /// <param name="member">The member</param>
        /// <returns>The attribute if found or null if not</returns>
        public static TAttribute GetAttribute<TAttribute>(this MemberInfo member) where TAttribute : Attribute
        {
#if NET40
            return Attribute.GetCustomAttribute(member, typeof (TAttribute)) as TAttribute;
#else
            return member.GetCustomAttribute<TAttribute>();
#endif
        }
    }
}