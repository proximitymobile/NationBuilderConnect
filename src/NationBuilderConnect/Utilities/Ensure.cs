using System;
using System.Collections.Generic;
using System.Linq;

namespace NationBuilderConnect.Utilities
{
    public static class Ensure
    {
        public static void IsNotNull<T>(T value, string paramName) where T : class
        {
            if (value == null) throw new ArgumentNullException(paramName);
        }

        public static void IsNotNullOrEmpty(string value, string paramName)
        {
            if (value == null) throw new ArgumentNullException(paramName);
            if (value.Length == 0) throw new ArgumentException("Value cannot be empty.", paramName);
        }

        public static void IsNotNullOrWhitespace(string value, string paramName)
        {
            if (value == null) throw new ArgumentNullException(paramName);
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Value cannot be empty.", paramName);
        }

        public static void DoesNotContainNullOrWhitespace(List<string> values, string paramName)
        {
            if (values == null) throw new ArgumentNullException(paramName);
            if (values.Any(string.IsNullOrWhiteSpace)) throw new ArgumentException("No values can be empty.", paramName);
        }

        public static void IsValidPageSize(int pageSize)
        {
            if(pageSize <= 0) throw new ArgumentException("Page size (limit) must be greater than 0");
        }
    }
}