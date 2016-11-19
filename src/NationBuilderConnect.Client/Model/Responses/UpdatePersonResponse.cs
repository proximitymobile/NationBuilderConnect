using NationBuilderConnect.Model;
using Newtonsoft.Json;

namespace NationBuilderConnect.Client.Model.Responses
{
    /// <summary>
    ///     The response received from the server when updating a person
    /// </summary>
    public class UpdatePersonResponse
    {
        /// <summary>
        ///     The updated person
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