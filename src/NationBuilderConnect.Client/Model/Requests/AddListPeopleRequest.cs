using System.Collections.Generic;
using Newtonsoft.Json;

namespace NationBuilderConnect.Client.Model.Requests
{
    public class AddListPeopleRequest
    {
        public AddListPeopleRequest(List<int> peopleIds)
        {
            PeopleIds = peopleIds;
        }

        [JsonProperty("people_ids")]
        public List<int> PeopleIds { get; private set; }
    }
}