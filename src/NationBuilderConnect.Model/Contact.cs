using System;
using Newtonsoft.Json;

namespace NationBuilderConnect.Model
{
    /// <summary>
    ///     Details about a contact with a person in your nation
    /// </summary>
    public class Contact : ReadOnlyDataTransferObject
    {
        /// <summary>
        ///     id of the contact type. For possible values use the Contact Types API.
        /// </summary>
        [JsonProperty("type_id")]
        public int? TypeId { get; private set; }

        /// <summary>
        ///     the method through which the contact was made. For possible values use the Contact Methods API.
        /// </summary>
        [JsonProperty("method")]
        public string Method { get; private set; }

        /// <summary>
        ///     id of the person who sent the contact.
        /// </summary>
        [JsonProperty("sender_id")]
        public int SenderId { get; private set; }

        /// <summary>
        ///     id of the person who made the contact.
        /// </summary>
        [JsonProperty("author_id")]
        public int AuthorId { get; private set; }

        /// <summary>
        ///     id of the person who receives the contact.
        /// </summary>
        [JsonProperty("person_id")]
        public int? PersonId { get; private set; }

        /// <summary>
        ///     status of the contact. For possible values use the Contact Statuses API.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; private set; }

        /// <summary>
        ///     id of the broadcaster on whose behalf the sender made the contact
        /// </summary>
        [JsonProperty("broadcaster_id")]
        public int? BroadcasterId { get; private set; }

        /// <summary>
        ///     note about the content of the contact
        /// </summary>
        [JsonProperty("note")]
        public string Note { get; private set; }

        /// <summary>
        ///     timestamp representing when the contact was created
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; private set; }

        /// <summary>
        ///     virtual capital currency. This will default to 0 if not provided by the client.
        /// </summary>
        [JsonProperty("capital_in_cents")]
        public int CapitalInCents { get; private set; }

        /// <summary>
        ///     id of the path on which the contact is logged.
        /// </summary>
        [JsonProperty("path_id")]
        public int? PathId { get; private set; }

        /// <summary>
        ///     id of the path step on which the contact is logged.
        /// </summary>
        [JsonProperty("step_id")]
        public int? StepId { get; private set; }
    }
}