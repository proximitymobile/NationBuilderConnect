using NationBuilderConnect.Client.Services.Parameters;
using Newtonsoft.Json;

namespace NationBuilderConnect.Client.Model.Requests
{
    /// <summary>
    ///     Request sent to the API to update a custom list
    /// </summary>
    public class UpdateListRequest
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="UpdateListRequest" /> class
        /// </summary>
        /// <param name="list">The updates for the list</param>
        public UpdateListRequest(UpdateListParameters list)
        {
            List = list;
        }

        /// <summary>
        ///     The updates for the list
        /// </summary>
        [JsonProperty("list")]
        public UpdateListParameters List { get; private set; }
    }
}