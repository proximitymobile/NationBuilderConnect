using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NationBuilderConnect.Model
{
    /// <summary>
    ///     Base class for class that can contain person custom fields
    /// </summary>
    public abstract class CustomFieldsContainer
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
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Value cannot be empty.", nameof(name));

            JToken value;
            return _customFields.TryGetValue(name, out value) ? (string) value : null;
        }

        /// <summary>
        ///     Sets the value of a custom field
        /// </summary>
        /// <param name="name">The name of the custom field to set</param>
        /// <param name="value">The value to set the custom field to</param>
        public void SetCustomField(string name, string value)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Value cannot be empty.", nameof(name));

            _customFields[name] = value;
        }
    }
}