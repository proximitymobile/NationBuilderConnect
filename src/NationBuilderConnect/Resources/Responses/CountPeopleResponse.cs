using Newtonsoft.Json;

namespace NationBuilderConnect.Resources.Responses
{
    public class CountPeopleResponse
    {
        [JsonProperty("people_count")]
        public int Count { get; private set; }
    }
}