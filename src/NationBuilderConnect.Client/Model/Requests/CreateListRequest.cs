using NationBuilderConnect.Client.Services.Parameters;
using Newtonsoft.Json;

namespace NationBuilderConnect.Client.Model.Requests
{
    /// <summary>
    ///     Request sent to the API to create a custom list
    /// </summary>
    public class CreateListRequest
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CreateListRequest" /> class
        /// </summary>
        /// <param name="list">The list details</param>
        public CreateListRequest(CreateListParameters list)
        {
            List = list;
        }

        /// <summary>
        ///     The list details
        /// </summary>
        [JsonProperty("list")]
        public CreateListParameters List { get; private set; }
    }
}