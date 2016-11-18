using NationBuilderConnect.Model;
using Newtonsoft.Json;

namespace NationBuilderConnect.Client.Model.Responses
{
    /// <summary>
    ///     The response received from the server when getting an export's details
    /// </summary>
    public class ShowExportResponse
    {
        /// <summary>
        ///     The export
        /// </summary>
        [JsonProperty("export")]
        public Export Export { get; private set; }
    }
}