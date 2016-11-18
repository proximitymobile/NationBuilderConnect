using System.Collections.Generic;
using Newtonsoft.Json;

namespace NationBuilderConnect.Client.Model.Requests
{
    /// <summary>
    ///     Request sent to the API to remove people from a custom list
    /// </summary>
    public class RemoveListPeopleRequest
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="RemoveListPeopleRequest" /> class
        /// </summary>
        /// <param name="peopleIds">The people IDs to remove from the list</param>
        public RemoveListPeopleRequest(List<int> peopleIds)
        {
            PeopleIds = peopleIds;
        }

        /// <summary>
        ///     The people IDs to remove from the list
        /// </summary>
        [JsonProperty("people_ids")]
        public List<int> PeopleIds { get; private set; }
    }
}