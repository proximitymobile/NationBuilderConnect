using System;
using System.Collections.Generic;
using System.Linq;

namespace NationBuilderConnect.Client.Utilities
{
    /// <summary>
    ///     Class for validating parameters
    /// </summary>
    public static class Ensure
    {
        /// <summary>
        ///     Throws an exception if a value is null
        /// </summary>
        /// <typeparam name="T">The type of the value</typeparam>
        /// <param name="value">The value</param>
        /// <param name="paramName">The name of the variable holding the value</param>
        public static void IsNotNull<T>(T value, string paramName) where T : class
        {
            if (value == null) throw new ArgumentNullException(paramName);
        }

        /// <summary>
        ///     Throws an exception if a value is null or empty
        /// </summary>
        /// <param name="value">The value</param>
        /// <param name="paramName">The name of the variable holding the value</param>
        public static void IsNotNullOrEmpty(string value, string paramName)
        {
            if (value == null) throw new ArgumentNullException(paramName);
            if (value.Length == 0) throw new ArgumentException("Value cannot be empty.", paramName);
        }

        /// <summary>
        ///     Throws an exception if a value is null or whitespace
        /// </summary>
        /// <param name="value">The value</param>
        /// <param name="paramName">The name of the variable holding the value</param>
        public static void IsNotNullOrWhitespace(string value, string paramName)
        {
            if (value == null) throw new ArgumentNullException(paramName);
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Value cannot be empty.", paramName);
        }

        /// <summary>
        ///     Throws an exception if a any values are null or whitespace
        /// </summary>
        /// <param name="values">The values</param>
        /// <param name="paramName">The name of the variable holding the values</param>
        public static void DoesNotContainNullOrWhitespace(List<string> values, string paramName)
        {
            if (values == null) throw new ArgumentNullException(paramName);
            if (values.Any(string.IsNullOrWhiteSpace))
                throw new ArgumentException("No values can be empty.", paramName);
        }

        /// <summary>
        ///     Throws an exception if the given page size is invalid
        /// </summary>
        /// <param name="pageSize">The page size</param>
        public static void IsValidPageSize(short pageSize)
        {
            if (pageSize <= 0) throw new ArgumentException("Page size (limit) must be greater than 0");
        }

        /// <summary>
        ///     Throws an exception if the given page size is not null and is invalid
        /// </summary>
        /// <param name="pageSize">The page size</param>
        public static void IsValidExplicitPageSize(short? pageSize)
        {
            if (pageSize <= 0) throw new ArgumentException("Page size (limit) must be greater than 0");
        }
    }
}