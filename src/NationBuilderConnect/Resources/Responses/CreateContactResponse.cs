using NationBuilderConnect.Resources.Entities;
using Newtonsoft.Json;

namespace NationBuilderConnect.Resources.Responses
{
    public class CreateContactResponse
    {
        [JsonProperty("contact")]
        public Contact Contact { get; private set; }
    }
}