using NationBuilderConnect.Client.Services.Parameters;
using Newtonsoft.Json;

namespace NationBuilderConnect.Client.Model.Requests
{
    public class UpdateListRequest
    {
        public UpdateListRequest(UpdateListParameters list)
        {
            List = list;
        }

        [JsonProperty("list")]
        public UpdateListParameters List { get; private set; }
    }
}