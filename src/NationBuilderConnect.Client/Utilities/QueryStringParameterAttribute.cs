using System;

namespace NationBuilderConnect.Client.Utilities
{
    /// <summary>
    ///     An attribute that tells us a property should be put in the request query string
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class QueryStringParameterAttribute : Attribute
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="QueryStringParameterAttribute" /> class
        /// </summary>
        /// <param name="key">The key to use in the query string</param>
        public QueryStringParameterAttribute(string key)
        {
            Key = key;
        }

        /// <summary>
        ///     The key to use in the query string
        /// </summary>
        public string Key { get; private set; }
    }
}