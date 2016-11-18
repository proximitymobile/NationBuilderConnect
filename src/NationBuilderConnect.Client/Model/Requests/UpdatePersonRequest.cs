using NationBuilderConnect.Client.Utilities;
using NationBuilderConnect.Model;
using Newtonsoft.Json;

namespace NationBuilderConnect.Client.Model.Requests
{
    /// <summary>
    ///     Request sent to the API to update a person
    /// </summary>
    public class UpdatePersonRequest : ITracksChanges
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="UpdatePersonRequest" /> class
        /// </summary>
        /// <param name="personUpdate"></param>
        public UpdatePersonRequest(PersonUpdate personUpdate)
        {
            PersonUpdate = personUpdate;
        }

        /// <summary>
        ///     The person update details
        /// </summary>
        [JsonProperty("person")]
        public PersonUpdate PersonUpdate { get; private set; }
    }
}