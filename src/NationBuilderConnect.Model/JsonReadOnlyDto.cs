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
    public abstract class JsonReadOnlyDto : IHasReadableCustomFields
    {
        [JsonExtensionData] private readonly IDictionary<string, JToken> _customFields =
            new Dictionary<string, JToken>();

        /// <inheritDoc/>
        public string GetCustomField(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Value cannot be empty.", nameof(name));

            JToken value;
            return _customFields.TryGetValue(name, out value) ? (string) value : null;
        }

        /// <inheritDoc/>
        public bool TryGetCustomField(string name, out string value)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Value cannot be empty.", nameof(name));

            JToken token;
            var valueFound = _customFields.TryGetValue(name, out token);
            value = valueFound ? (string) token : null;
            return valueFound;
        }

        /// <inheritDoc/>
        public IEnumerable<string> GetCustomFieldNames()
        {
            return _customFields.Select(f => f.Key);
        }
    }
}