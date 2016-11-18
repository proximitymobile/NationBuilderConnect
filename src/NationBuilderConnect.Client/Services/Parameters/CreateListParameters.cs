using Newtonsoft.Json;

namespace NationBuilderConnect.Client.Services.Parameters
{
    /// <summary>
    ///     The values used to create a list
    /// </summary>
    public class CreateListParameters
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CreateListParameters" /> class.
        /// </summary>
        /// <param name="name">The name of the list</param>
        /// <param name="slug">A unique identifier for the list</param>
        /// <param name="authorId">The id of the author of the list</param>
        public CreateListParameters(string name, string slug, int authorId)
        {
            Name = name;
            Slug = slug;
            AuthorId = authorId;
        }

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
    }
}