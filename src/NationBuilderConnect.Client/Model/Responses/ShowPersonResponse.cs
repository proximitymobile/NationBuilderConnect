using NationBuilderConnect.Model;
using Newtonsoft.Json;

namespace NationBuilderConnect.Client.Model.Responses
{
    /// <summary>
    ///     The response received from the server when getting a person's details
    /// </summary>
    public class ShowPersonResponse
    {
        /// <summary>
        ///     The person
        /// </summary>
        [JsonProperty("person")]
        public Person Person { get; private set; }

        /// <summary>
        ///     The person's precinct
        /// </summary>
        [JsonProperty("precinct")]
        public PersonPrecinct Precinct { get; private set; }
    }
}