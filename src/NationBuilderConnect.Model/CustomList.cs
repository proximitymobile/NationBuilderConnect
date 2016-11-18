using Newtonsoft.Json;

namespace NationBuilderConnect.Model
{
    /// <summary>
    ///     Details about a custom list of people
    /// </summary>
    public class CustomList
    {
        /// <summary>
        ///     The Id of the list
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; private set; }

        /// <summary>
        ///     The name of the list
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; private set; }

        /// <summary>
        ///     A unique identifier for the list
        /// </summary>
        [JsonProperty("slug")]
        public string Slug { get; private set; }

        /// <summary>
        ///     The id of the author of the list
        /// </summary>
        [JsonProperty("author_id")]
        public int AuthorId { get; private set; }

        /// <summary>
        ///     The number of people in the list.
        /// </summary>
        [JsonProperty("count")]
        public int Count { get; private set; }
    }
}