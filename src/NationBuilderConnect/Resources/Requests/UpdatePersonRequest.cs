using NationBuilderConnect.Resources.Entities;
using NationBuilderConnect.Utilities;
using Newtonsoft.Json;

namespace NationBuilderConnect.Resources.Requests
{
    public class UpdatePersonRequest : ITracksChanges
    {
        public UpdatePersonRequest(PersonUpdate personUpdate)
        {
            PersonUpdate = personUpdate;
        }

        [JsonProperty("person")]
        public PersonUpdate PersonUpdate { get; private set; }
    }
}