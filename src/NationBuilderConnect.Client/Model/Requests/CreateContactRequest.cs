using NationBuilderConnect.Client.Services.Parameters;
using Newtonsoft.Json;

namespace NationBuilderConnect.Client.Model.Requests
{
    public class CreateContactRequest
    {
        public CreateContactRequest(CreateContactParameters contact)
        {
            Contact = contact;
        }

        [JsonProperty("contact")]
        public CreateContactParameters Contact { get; private set; }
    }
}