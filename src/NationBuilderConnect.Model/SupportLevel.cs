namespace NationBuilderConnect.Model
{
    /// <summary>
    /// The support level of a person
    /// </summary>
    public enum SupportLevel : byte
    {
        /// <summary>
        /// Strong Supporter
        /// </summary>
        StrongSupporter = 1,

        /// <summary>
        /// Supporter
        /// </summary>
        Supporter = 2,

        /// <summary>
        /// Undecided
        /// </summary>
        Undecided = 3,

        /// <summary>
        /// Opposed
        /// </summary>
        Opposed = 4,

        /// <summary>
        /// StronglyOpposed
        /// </summary>
        StronglyOpposed = 5
    }
}