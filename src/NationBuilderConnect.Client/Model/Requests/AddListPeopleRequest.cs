using System.Collections.Generic;
using Newtonsoft.Json;

namespace NationBuilderConnect.Client.Model.Requests
{
    /// <summary>
    ///     Request sent to the API to add people to a custom list
    /// </summary>
    public class AddListPeopleRequest
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="AddListPeopleRequest" /> class
        /// </summary>
        /// <param name="peopleIds">The list of people IDs to add to the list</param>
        public AddListPeopleRequest(List<int> peopleIds)
        {
            PeopleIds = peopleIds;
        }

        /// <summary>
        ///     The list of people IDs to add to the list
        /// </summary>
        [JsonProperty("people_ids")]
        public List<int> PeopleIds { get; private set; }
    }
}