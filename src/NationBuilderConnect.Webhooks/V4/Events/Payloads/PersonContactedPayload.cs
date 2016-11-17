using NationBuilderConnect.Webhooks.V4.Entities;
using Newtonsoft.Json;

namespace NationBuilderConnect.Webhooks.V4.Events.Payloads
{
    /// <summary>
    ///     Payload that is sent to our server from NationBuilder when a person is contacted
    /// </summary>
    public class PersonContactedPayload : INationBuilderEventPayload
    {
        /// <summary>
        ///     Details about the contact
        /// </summary>
        [JsonProperty("person_call")]
        public Contact Contact { get; private set; }
    }
}