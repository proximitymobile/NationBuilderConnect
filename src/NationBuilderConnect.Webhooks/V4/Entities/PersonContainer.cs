using Newtonsoft.Json;

namespace NationBuilderConnect.Webhooks.V4.Entities
{
    /// <summary>
    ///     A class to assist with deserialization where a person is wrapped in another object
    /// </summary>
    public class PersonContainer
    {
        /// <summary>
        ///     The person
        /// </summary>
        [JsonProperty("person")]
        public Person Person { get; private set; }
    }
}