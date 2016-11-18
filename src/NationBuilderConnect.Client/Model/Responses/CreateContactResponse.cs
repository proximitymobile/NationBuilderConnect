using NationBuilderConnect.Model;
using Newtonsoft.Json;

namespace NationBuilderConnect.Client.Model.Responses
{
    /// <summary>
    ///     The response received from the server when creating a person contact
    /// </summary>
    public class CreateContactResponse
    {
        /// <summary>
        ///     The contact that was created
        /// </summary>
        [JsonProperty("contact")]
        public Contact Contact { get; private set; }
    }
}