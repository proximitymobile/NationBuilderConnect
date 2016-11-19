using NationBuilderConnect.Model;
using Newtonsoft.Json;

namespace NationBuilderConnect.Client.Model.Responses
{
    /// <summary>
    ///     The response received from the server when a person is created
    /// </summary>
    public class CreatePersonResponse
    {
        /// <summary>
        ///     The person that was created
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