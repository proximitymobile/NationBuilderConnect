using Newtonsoft.Json;

namespace NationBuilderConnect.Model
{
    /// <summary>
    ///     A class to assist with deserialization where a person is wrapped in another object
    /// </summary>
    public class PersonContainer : JsonReadOnlyDto
    {
        /// <summary>
        ///     The person
        /// </summary>
        [JsonProperty("person")]
        public Person Person { get; private set; }
    }
}