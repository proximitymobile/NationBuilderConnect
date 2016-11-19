using NationBuilderConnect.Model;
using Newtonsoft.Json;

namespace NationBuilderConnect.Client.Model.Responses
{
    /// <summary>
    ///     The response received from the server when a person is added
    /// </summary>
    public class AddPersonResponse
    {
        /// <summary>
        ///     The updated or created person
        /// </summary>
        [JsonProperty("person")]
        public Person Person { get; private set; }

        /// <summary>
        ///     The person's precinct
        /// </summary>
        [JsonProperty("precinct")]
        public Precinct Precinct { get; private set; }

        /// <summary>
        ///     Whether or not the person was created. If false, an existing person was updated
        /// </summary>
        public bool WasNewPersonCreated { get; internal set; }
    }
}