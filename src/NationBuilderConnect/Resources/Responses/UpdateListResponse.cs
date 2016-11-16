using NationBuilderConnect.Resources.Entities;
using Newtonsoft.Json;

namespace NationBuilderConnect.Resources.Responses
{
    public class UpdateListResponse
    {
        [JsonProperty("list_resource")]
        public CustomList List { get; private set; }
    }
}