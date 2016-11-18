using NationBuilderConnect.Client.Services.Parameters;
using Newtonsoft.Json;

namespace NationBuilderConnect.Client.Model.Requests
{
    /// <summary>
    ///     Request sent to the API to create and run an export
    /// </summary>
    public class CreateExportRequest
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CreateExportRequest" /> class
        /// </summary>
        /// <param name="export">The export details</param>
        public CreateExportRequest(CreateExportParameters export)
        {
            Export = export;
        }

        /// <summary>
        ///     The export details
        /// </summary>
        [JsonProperty("export")]
        public CreateExportParameters Export { get; private set; }
    }
}