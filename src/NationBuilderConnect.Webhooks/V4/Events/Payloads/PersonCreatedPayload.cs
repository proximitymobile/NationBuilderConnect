using NationBuilderConnect.Model;
using Newtonsoft.Json;

namespace NationBuilderConnect.Webhooks.V4.Events.Payloads
{
    /// <summary>
    ///     Payload that is sent to our server from NationBuilder when a person is created
    /// </summary>
    public class PersonCreatedPayload : ReadOnlyDataTransferObject, INationBuilderEventPayload
    {
        /// <summary>
        ///     The person that was created
        /// </summary>
        [JsonProperty("person")]
        public Person Person { get; private set; }
    }
}