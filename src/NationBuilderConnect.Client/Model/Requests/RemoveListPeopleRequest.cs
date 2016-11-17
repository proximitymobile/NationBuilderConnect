using System.Collections.Generic;
using Newtonsoft.Json;

namespace NationBuilderConnect.Client.Model.Requests
{
    public class RemoveListPeopleRequest
    {
        public RemoveListPeopleRequest(List<int> peopleIds)
        {
            PeopleIds = peopleIds;
        }

        [JsonProperty("people_ids")]
        public List<int> PeopleIds { get; private set; }
    }
}