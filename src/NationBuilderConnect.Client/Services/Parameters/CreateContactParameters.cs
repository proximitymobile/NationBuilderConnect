using Newtonsoft.Json;

namespace NationBuilderConnect.Client.Services.Parameters
{
    public class CreateContactParameters
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CreateContactParameters" /> class.
        /// </summary>
        /// <param name="typeId">Id of the contact type. For possible values use the Contact Types API.</param>
        /// <param name="method">The method through which the contact was made. For possible values use the Contact Methods API.</param>
        /// <param name="authorId">Id of the person who made the contact.</param>
        public CreateContactParameters(int typeId, string method, int authorId)
        {
            TypeId = typeId;
            Method = method;
            AuthorId = authorId;
            SenderId = authorId;
        }

        /// <summary>
        ///     Id of the contact type. For possible values use the Contact Types API.
        /// </summary>
        [JsonProperty("type_id")]
        public int TypeId { get; private set; }

        /// <summary>
        ///     The method through which the contact was made. For possible values use the Contact Methods API.
        /// </summary>
        [JsonProperty("method")]
        public string Method { get; private set; }

        /// <summary>
        ///     Id of the person who made the contact.
        /// </summary>
        [JsonProperty("author_id")]
        public int AuthorId { get; private set; }

        /// <summary>
        ///     Status of the contact. For possible values use the Contact Statuses API.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        ///     Id of the person who made the contact.
        /// </summary>
        [JsonProperty("sender_id")]
        public int SenderId { get; private set; }

        /// <summary>
        ///     Id of the broadcaster on whose behalf the sender made the contact
        /// </summary>
        [JsonProperty("broadcaster_id")]
        public int? BroadcasterId { get; set; }

        /// <summary>
        ///     Note about the content of the contact
        /// </summary>
        [JsonProperty("note")]
        public string Note { get; set; }

        /// <summary>
        ///     Virtual capital currency. This will default to 0 if not provided by the client.
        /// </summary>
        [JsonProperty("capital_in_cents")]
        public int? CapitalInCents { get; set; }
    }
}