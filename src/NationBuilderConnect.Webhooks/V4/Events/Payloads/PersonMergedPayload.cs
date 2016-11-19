using NationBuilderConnect.Model;
using Newtonsoft.Json;

namespace NationBuilderConnect.Webhooks.V4.Events.Payloads
{
    /// <summary>
    ///     Payload that is sent to our server from NationBuilder when 2 person records are merged
    /// </summary>
    public class PersonMergedPayload : ReadOnlyDataTransferObject, INationBuilderEventPayload
    {
        /// <summary>
        ///     Container for the person that the two records were merged into
        /// </summary>
        [JsonProperty("merged")]
        public PersonContainer MergedContainer { get; private set; }

        /// <summary>
        ///     Container for the record that was merged into the other one and then deleted
        /// </summary>
        [JsonProperty("deleted")]
        public PersonContainer DeletedContainer { get; private set; }

        /// <summary>
        ///     Person that the two records were merged into
        /// </summary>
        [JsonIgnore]
        public Person MergedPerson => MergedContainer?.Person;

        /// <summary>
        ///     Person that was merged into the other one and then deleted
        /// </summary>
        [JsonIgnore]
        public Person DeletedPerson => DeletedContainer?.Person;
    }
}