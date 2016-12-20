using Newtonsoft.Json;

namespace NationBuilderConnect.Model
{
    /// <summary>
    ///     A person's precinct
    /// </summary>
    public class Precinct : JsonReadOnlyDto
    {
        /// <summary>
        ///     The precinct ID
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; private set; }

        /// <summary>
        ///     The precinct code
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; private set; }

        /// <summary>
        ///     The precinct name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; private set; }
    }
}