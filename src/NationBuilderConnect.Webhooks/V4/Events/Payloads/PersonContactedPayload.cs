using NationBuilderConnect.Model;
using NationBuilderConnect.Webhooks.V4.Model;
using Newtonsoft.Json;

namespace NationBuilderConnect.Webhooks.V4.Events.Payloads
{
    /// <summary>
    ///     Payload that is sent to our server from NationBuilder when a person is contacted
    /// </summary>
    public class PersonContactedPayload : JsonReadOnlyDto, INationBuilderEventPayload
    {
        /// <summary>
        ///     Details about the contact
        /// </summary>
        [JsonProperty("person_call")]
        public WebhookContact Contact { get; private set; }
    }
}