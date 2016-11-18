using NationBuilderConnect.Model.Utilities.Json;
using Newtonsoft.Json;

namespace NationBuilderConnect.Model
{
    /// <summary>
    ///     The sex of a person
    /// </summary>
    [JsonConverter(typeof (SexConverter))]
    public enum Sex
    {
        /// <summary>
        ///     Female
        /// </summary>
        Female = 1,

        /// <summary>
        ///     Male
        /// </summary>
        Male = 2,

        /// <summary>
        ///     Other
        /// </summary>
        Other = 3
    }
}