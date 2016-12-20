using System;
using System.Collections.Generic;
using System.Linq;
using NationBuilderConnect.Model;
using Newtonsoft.Json;

namespace NationBuilderConnect.Client.Tools.Export
{
    /// <summary>
    ///     Base class for read only data transfer objects that may have extra fields that we haven't handled
    /// </summary>
    public abstract class CsvRecord : IHasReadableCustomFields
    {
        [JsonExtensionData] private readonly IDictionary<string, string> _customFields =
            new Dictionary<string, string>();

        /// <inheritDoc/>
        public string GetCustomField(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Value cannot be empty.", nameof(name));

            string value;
            return _customFields.TryGetValue(name, out value) ? value : null;
        }

        /// <inheritDoc/>
        public bool TryGetCustomField(string name, out string value)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Value cannot be empty.", nameof(name));
            return _customFields.TryGetValue(name, out value);
        }

        /// <inheritDoc/>
        public IEnumerable<string> GetCustomFieldNames()
        {
            return _customFields.Select(f => f.Key);
        }

        internal void SetCustomField(string name, string value)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Value cannot be empty.", nameof(name));

            _customFields[name] = value;
        }
    }
}