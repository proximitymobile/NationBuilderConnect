using NationBuilderConnect.Services.Parameters;
using Newtonsoft.Json;

namespace NationBuilderConnect.Resources.Requests
{
    public class CreateExportRequest
    {
        public CreateExportRequest(CreateExportParameters export)
        {
            Export = export;
        }

        [JsonProperty("export")]
        public CreateExportParameters Export { get; private set; }
    }
}