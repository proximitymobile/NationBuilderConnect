namespace NationBuilderConnect.Model
{
    /// <summary>
    ///     Interface for class that has writeable custom fields
    /// </summary>
    public interface IHasWriteableCustomFields
    {
        /// <summary>
        ///     Sets the value of a custom field
        /// </summary>
        /// <param name="name">The name of the custom field to set</param>
        /// <param name="value">The value to set the custom field to</param>
        void SetCustomField(string name, string value);
    }
}