using NationBuilderConnect.Resources.Entities;
using Newtonsoft.Json;

namespace NationBuilderConnect.Resources.Responses
{
    public class ShowExportResponse
    {
        [JsonProperty("export")]
        public Export Export { get; private set; }
    }
}