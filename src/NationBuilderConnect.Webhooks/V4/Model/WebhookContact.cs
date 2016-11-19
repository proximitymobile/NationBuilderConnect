using NationBuilderConnect.Model;
using Newtonsoft.Json;

namespace NationBuilderConnect.Webhooks.V4.Model
{
    /// <summary>
    ///     Details about a contact with a person in your nation
    /// </summary>
    public class WebhookContact : ReadOnlyDataTransferObject
    {
        /// <summary>
        ///     The ID of the method through which the contact was made. For possible values use the Contact Methods API.
        /// </summary>
        [JsonProperty("contact_method_id")]
        public int MethodId { get; private set; }

        /// <summary>
        ///     The name of the method through which the contact was made. For possible values use the Contact Methods API.
        /// </summary>
        [JsonProperty("contact_method_name")]
        public string MethodName { get; private set; }

        /// <summary>
        ///     The status ID of the contact. For possible values use the Contact Statuses API.
        /// </summary>
        [JsonProperty("contact_status_id")]
        public int StatusId { get; private set; }

        /// <summary>
        ///     The status name of the contact. For possible values use the Contact Statuses API.
        /// </summary>
        [JsonProperty("contact_status_name")]
        public string StatusName { get; private set; }

        /// <summary>
        ///     The contact type ID. For possible values use the Contact Types API.
        /// </summary>
        [JsonProperty("call_type_id")]
        public int TypeId { get; private set; }

        /// <summary>
        ///     The contact type name. For possible values use the Contact Types API.
        /// </summary>
        [JsonProperty("call_type_name")]
        public string TypeName { get; private set; }

        /// <summary>
        ///     the level of support this person has for your nation, expressed as a number between 1 and 5, 1 being Strong
        ///     support, 5 meaning strong opposition, and 3 meaning undecided.
        /// </summary>
        [JsonProperty("support_level")]
        public byte? SupportLevel { get; set; }

        /// <summary>
        ///     the priority level associated with this person
        /// </summary>
        [JsonProperty("priority_level")]
        public byte? PriorityLevel { get; set; }

        /// <summary>
        ///     The person who was contacted
        /// </summary>
        [JsonProperty("person")]
        public Person PersonContacted { get; private set; }

        /// <summary>
        ///     The person who authored the contact
        /// </summary>
        [JsonProperty("author")]
        public Person Author { get; private set; }
    }
}