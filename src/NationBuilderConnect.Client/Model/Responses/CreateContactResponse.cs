using NationBuilderConnect.Client.Model.Entities;
using Newtonsoft.Json;

namespace NationBuilderConnect.Client.Model.Responses
{
    public class CreateContactResponse
    {
        [JsonProperty("contact")]
        public Contact Contact { get; private set; }
    }
}