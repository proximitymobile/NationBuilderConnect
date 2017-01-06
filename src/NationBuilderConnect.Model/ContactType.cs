using Newtonsoft.Json;

namespace NationBuilderConnect.Model
{
    public class ContactType
    {
        [JsonProperty("id")]
        public int Id { get; private set; }

        [JsonProperty("name")]
        public string Name { get; private set; }
    }
}