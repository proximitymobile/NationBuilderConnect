using NationBuilderConnect.Client.Model.Entities;
using Newtonsoft.Json;

namespace NationBuilderConnect.Client.Model.Responses
{
    public class UpdateListResponse
    {
        [JsonProperty("list_resource")]
        public CustomList List { get; private set; }
    }
}