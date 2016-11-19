using NationBuilderConnect.Model;
using Newtonsoft.Json;

namespace NationBuilderConnect.Client.Model.Responses
{
    /// <summary>
    ///     The response received from the server when matching a person
    /// </summary>
    public class MatchPersonResponse
    {
        /// <summary>
        ///     The matched person
        /// </summary>
        [JsonProperty("person")]
        public Person Person { get; private set; }

        /// <summary>
        ///     The person's precinct
        /// </summary>
        [JsonProperty("precinct")]
        public Precinct Precinct { get; private set; }
    }
}