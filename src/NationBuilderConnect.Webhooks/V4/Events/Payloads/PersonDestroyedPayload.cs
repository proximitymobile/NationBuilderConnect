using NationBuilderConnect.Model;
using Newtonsoft.Json;

namespace NationBuilderConnect.Webhooks.V4.Events.Payloads
{
    /// <summary>
    ///     Payload that is sent to our server from NationBuilder when a person is destroyed
    /// </summary>
    public class PersonDestroyedPayload : INationBuilderEventPayload
    {
        /// <summary>
        ///     The person that was created or updated
        /// </summary>
        [JsonProperty("person")]
        public Person Person { get; private set; }
    }
}