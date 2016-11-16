using NationBuilderConnect.Services.Parameters;
using Newtonsoft.Json;

namespace NationBuilderConnect.Resources.Requests
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