using NationBuilderConnect.Client.Model.Entities;
using Newtonsoft.Json;

namespace NationBuilderConnect.Client.Model.Responses
{
    public class ShowPersonResponse
    {
        [JsonProperty("person")]
        public Person Person { get; private set; }

        [JsonProperty("precinct")]
        public PersonPrecinct Precint { get; private set; }
    }
}