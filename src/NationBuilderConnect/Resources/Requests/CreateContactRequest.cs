using NationBuilderConnect.Services.Parameters;
using Newtonsoft.Json;

namespace NationBuilderConnect.Resources.Requests
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