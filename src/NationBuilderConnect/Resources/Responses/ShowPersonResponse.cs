using NationBuilderConnect.Resources.Entities;
using Newtonsoft.Json;

namespace NationBuilderConnect.Resources.Responses
{
    public class ShowPersonResponse
    {
        [JsonProperty("person")]
        public Person Person { get; private set; }

        [JsonProperty("precinct")]
        public PersonPrecinct Precint { get; private set; }
    }
}