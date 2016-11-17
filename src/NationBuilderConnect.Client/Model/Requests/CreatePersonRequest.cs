using NationBuilderConnect.Client.Model.Entities;
using NationBuilderConnect.Client.Utilities;
using Newtonsoft.Json;

namespace NationBuilderConnect.Client.Model.Requests
{
    public class CreatePersonRequest : ITracksChanges
    {
        public CreatePersonRequest(PersonUpdate personUpdate)
        {
            PersonUpdate = personUpdate;
        }

        [JsonProperty("person")]
        public PersonUpdate PersonUpdate { get; private set; }
    }
}