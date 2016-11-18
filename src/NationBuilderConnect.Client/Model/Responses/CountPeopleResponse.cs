using Newtonsoft.Json;

namespace NationBuilderConnect.Client.Model.Responses
{
    /// <summary>
    ///     The response received from the server when counting people
    /// </summary>
    public class CountPeopleResponse
    {
        /// <summary>
        ///     The person count
        /// </summary>
        [JsonProperty("people_count")]
        public int Count { get; private set; }
    }
}