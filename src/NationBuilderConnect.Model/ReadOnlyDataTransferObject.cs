using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NationBuilderConnect.Model
{
    /// <summary>
    ///     Base class for read only data transfer objects that may have extra fields that we haven't handled
    /// </summary>
    public abstract class ReadOnlyDataTransferObject
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
        ///     Tries to get the custom field with the given name
        /// </summary>
        /// <param name="name">The custom field name</param>
        /// <param name="value">The value that is found</param>
        /// <returns>True if the field was found, false if not</returns>
        public bool TryGetCustomField(string name, out string value)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Value cannot be empty.", nameof(name));

            JToken token;
            var valueFound = _customFields.TryGetValue(name, out token);
            value = valueFound ? (string) token : null;
            return valueFound;
        }

        /// <summary>
        ///     Returns the names of the custom fields that have been loaded
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetCustomFieldNames()
        {
            return _customFields.Select(f => f.Key);
        }
    }
}