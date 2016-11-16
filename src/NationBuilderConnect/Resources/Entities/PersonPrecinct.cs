using Newtonsoft.Json;

namespace NationBuilderConnect.Resources.Entities
{
    public class PersonPrecinct
    {
        [JsonProperty("id")]
        public int Id { get; private set; }

        [JsonProperty("code")]
        public string Code { get; private set; }

        [JsonProperty("name")]
        public string Name { get; private set; }
    }
}