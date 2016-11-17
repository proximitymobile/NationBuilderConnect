using NationBuilderConnect.Webhooks.V4.Entities;
using Newtonsoft.Json;

namespace NationBuilderConnect.Webhooks.V4.Events.Payloads
{
    /// <summary>
    ///     Payload that is sent to our server from NationBuilder when a person is changed
    /// </summary>
    public class PersonChangedPayload : INationBuilderEventPayload
    {
        /// <summary>
        ///     The person that was created or updated
        /// </summary>
        [JsonProperty("person")]
        public Person Person { get; private set; }
    }
}