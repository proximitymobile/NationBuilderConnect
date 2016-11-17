using Newtonsoft.Json;

namespace NationBuilderConnect.Client.Model
{
    /// <summary>
    ///     Error details returned from the server
    /// </summary>
    public class ApiErrorDetails
    {
        /// <summary>
        ///     A code describing the error
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; private set; }

        /// <summary>
        ///     The error message
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; private set; }

        /// <summary>
        ///     Parameters relating to the error
        /// </summary>
        [JsonProperty("parameters")]
        public string[] Parameters { get; private set; }

        /// <summary>
        ///     Validation errors
        /// </summary>
        [JsonProperty("validation_errors")]
        public string[] ValidationErrors { get; private set; }
    }
}