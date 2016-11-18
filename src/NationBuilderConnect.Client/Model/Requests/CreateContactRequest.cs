using NationBuilderConnect.Client.Services.Parameters;
using Newtonsoft.Json;

namespace NationBuilderConnect.Client.Model.Requests
{
    /// <summary>
    ///     Request sent to the API to add a contact for a person
    /// </summary>
    public class CreateContactRequest
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CreateContactRequest" /> class
        /// </summary>
        /// <param name="contact">The values to use for the contact</param>
        public CreateContactRequest(CreateContactParameters contact)
        {
            Contact = contact;
        }

        /// <summary>
        ///     The values to use for the contact
        /// </summary>
        [JsonProperty("contact")]
        public CreateContactParameters Contact { get; private set; }
    }
}