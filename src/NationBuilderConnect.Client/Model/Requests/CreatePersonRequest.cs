using NationBuilderConnect.Client.Utilities;
using NationBuilderConnect.Model;
using Newtonsoft.Json;

namespace NationBuilderConnect.Client.Model.Requests
{
    /// <summary>
    ///     Request sent to the API to create a person
    /// </summary>
    public class CreatePersonRequest : ITracksChanges
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CreatePersonRequest" /> class
        /// </summary>
        /// <param name="personUpdate">The values to use for the new person</param>
        public CreatePersonRequest(PersonUpdate personUpdate)
        {
            PersonUpdate = personUpdate;
        }

        /// <summary>
        ///     The values to use for the new person
        /// </summary>
        [JsonProperty("person")]
        public PersonUpdate PersonUpdate { get; private set; }
    }
}