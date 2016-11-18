using NationBuilderConnect.Model;
using Newtonsoft.Json;

namespace NationBuilderConnect.Client.Model.Responses
{
    /// <summary>
    ///     Response received when a custom list is updated
    /// </summary>
    public class UpdateListResponse
    {
        /// <summary>
        ///     The updated list
        /// </summary>
        [JsonProperty("list_resource")]
        public CustomList List { get; private set; }
    }
}