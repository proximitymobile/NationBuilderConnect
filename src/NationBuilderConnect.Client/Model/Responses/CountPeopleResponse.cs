using Newtonsoft.Json;

namespace NationBuilderConnect.Client.Model.Responses
{
    public class CountPeopleResponse
    {
        [JsonProperty("people_count")]
        public int Count { get; private set; }
    }
}