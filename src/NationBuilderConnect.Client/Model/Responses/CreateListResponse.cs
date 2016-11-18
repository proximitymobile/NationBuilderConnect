using NationBuilderConnect.Model;
using Newtonsoft.Json;

namespace NationBuilderConnect.Client.Model.Responses
{
    /// <summary>
    ///     The response received from the server when creating a list
    /// </summary>
    public class CreateListResponse
    {
        /// <summary>
        ///     The list that was created
        /// </summary>
        [JsonProperty("list_resource")]
        public CustomList List { get; private set; }
    }
}