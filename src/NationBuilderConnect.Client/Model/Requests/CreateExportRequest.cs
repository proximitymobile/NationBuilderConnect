using NationBuilderConnect.Client.Services.Parameters;
using Newtonsoft.Json;

namespace NationBuilderConnect.Client.Model.Requests
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