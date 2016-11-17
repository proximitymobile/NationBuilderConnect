using NationBuilderConnect.Client.Model.Entities;
using Newtonsoft.Json;

namespace NationBuilderConnect.Client.Model.Responses
{
    public class CreateListResponse
    {
        [JsonProperty("list_resource")]
        public CustomList List { get; private set; }
    }
}