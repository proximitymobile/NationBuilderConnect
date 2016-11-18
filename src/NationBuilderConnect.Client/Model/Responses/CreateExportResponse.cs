using NationBuilderConnect.Model;
using Newtonsoft.Json;

namespace NationBuilderConnect.Client.Model.Responses
{
    /// <summary>
    ///     The response received from the server when creating an export
    /// </summary>
    public class CreateExportResponse
    {
        /// <summary>
        ///     The export that was created
        /// </summary>
        [JsonProperty("export")]
        public Export Export { get; private set; }
    }
}