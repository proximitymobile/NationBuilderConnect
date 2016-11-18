using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NationBuilderConnect.Model
{
    /// <summary>
    ///     Base class for class that can contain readonly person custom fields
    /// </summary>
    public abstract class CustomFieldsReadOnlyContainer
    {
        [JsonExtensionData] private readonly IDictionary<string, JToken> _customFields =
            new Dictionary<string, JToken>();

        /// <summary>
        ///     Returns the value for the custom field with the given name, or null of it is not found
        /// </summary>
        /// <param name="name">The custom field name</param>
        /// <returns>The value for the custom field or null if not found</returns>
        public string GetCustomField(string name)
        {
            if(string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Value cannot be empty.", nameof(name));

            JToken value;
            return _customFields.TryGetValue(name, out value) ? (string) value : null;
        }
    }
}