using System.Collections.Generic;

namespace NationBuilderConnect.Model
{
    /// <summary>
    ///     Interface for class that has readable custom fields
    /// </summary>
    public interface IHasReadableCustomFields
    {
        /// <summary>
        ///     Returns the value for the custom field with the given name, or null of it is not found
        /// </summary>
        /// <param name="name">The custom field name</param>
        /// <returns>The value for the custom field or null if not found</returns>
        string GetCustomField(string name);

        /// <summary>
        ///     Tries to get the custom field with the given name
        /// </summary>
        /// <param name="name">The custom field name</param>
        /// <param name="value">The value that is found</param>
        /// <returns>True if the field was found, false if not</returns>
        bool TryGetCustomField(string name, out string value);

        /// <summary>
        ///     Returns the names of the custom fields that have been loaded
        /// </summary>
        /// <returns></returns>
        IEnumerable<string> GetCustomFieldNames();
    }
}