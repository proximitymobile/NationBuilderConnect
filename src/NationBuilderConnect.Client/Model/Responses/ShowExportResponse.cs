using NationBuilderConnect.Client.Model.Entities;
using Newtonsoft.Json;

namespace NationBuilderConnect.Client.Model.Responses
{
    public class ShowExportResponse
    {
        [JsonProperty("export")]
        public Export Export { get; private set; }
    }
}