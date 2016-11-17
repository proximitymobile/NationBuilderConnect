using NationBuilderConnect.Webhooks.V4.Events.Payloads;
using Newtonsoft.Json;

namespace NationBuilderConnect.Webhooks.V4.Events
{
    /// <summary>
    ///     The base class for all webhook events
    /// </summary>
    /// <typeparam name="TPayload">The event payload</typeparam>
    public abstract class NationBuilderWebhookEvent<TPayload> where TPayload : class, INationBuilderEventPayload
    {
        /// <summary>
        ///     The slug of the nation in which the event took place
        /// </summary>
        [JsonProperty("nation_slug")]
        public string NationSlug { get; private set; }

        /// <summary>
        ///     The shared secret
        /// </summary>
        [JsonProperty("token")]
        public string Token { get; private set; }

        /// <summary>
        ///     The webhook version
        /// </summary>
        [JsonProperty("version")]
        public short Version { get; private set; }

        /// <summary>
        ///     The payload (details) for the event
        /// </summary>
        [JsonProperty("payload")]
        public TPayload Payload { get; private set; }
    }
}