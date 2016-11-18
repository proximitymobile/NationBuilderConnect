namespace NationBuilderConnect.Model
{
    /// <summary>
    ///     The type of signup for an entity in the system
    /// </summary>
    public enum SignUpType : byte
    {
        /// <summary>
        ///     A person
        /// </summary>
        Person = 0,

        /// <summary>
        ///     An organization
        /// </summary>
        Organization = 1
    }
}