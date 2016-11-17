using NationBuilderConnect.Client.Services.Parameters;
using Newtonsoft.Json;

namespace NationBuilderConnect.Client.Model.Requests
{
    public class CreateListRequest
    {
        public CreateListRequest(CreateListParameters list)
        {
            List = list;
        }

        [JsonProperty("list")]
        public CreateListParameters List { get; private set; }
    }
}